using System;
using System.Collections.Generic;
using ConnHelper;
using H_PMS_Model;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Linq;

namespace H_PMS_DAL
{
    public class AlanService
    {
        #region 登录

        public Employee Login(string emp, string pwd)
        {
            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(JsonConvert.SerializeObject(DBHelper.GetDataTable("select * from Employee where EName='" + emp + "' and ESex='" + pwd + "'")));
            return list.FirstOrDefault();
        }

        public ParkBase GetPBMax()
        {
            List<ParkBase> list = JsonConvert.DeserializeObject<List<ParkBase>>(JsonConvert.SerializeObject(DBHelper.GetDataTable("select  PBNumber from  ParkBase where PBId =(select  max(PBId) from  ParkBase)")));
            return list.FirstOrDefault();
        }

        #endregion

        #region 车位管理

        public int AddParkBase(ParkBase p)
        {
            string sql = string.Format("insert into ParkBase values('{0}','{1}','{2}','{3}','{4}','{5}')", p.PBNumber, p.PBArea, p.PBType, p.PBPrice, p.PBPlace, p.Remark);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public List<Park> GetParkBases()
        {
            // 类型 面积  价钱
            string sql = "select HostId,InRentSTime,OutRentSTime,CarType,CarNumber,PBNumber,PBArea,PBType,IDCard,PBPrice,PBPlace,b.Remark as Remark2,a.Remark as Remark from Park a full join ParkBase b on  a.PBId=b.PBId ";
            DataTable dt = DBHelper.GetDataTable(sql);
            List<Park> list = JsonConvert.DeserializeObject<List<Park>>(JsonConvert.SerializeObject(dt));
            return list;
        }

        public int DelParkBase(int id)
        {
            string sql = "delete from ParkBase where PBId =" + id;
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int UptParkBase(ParkBase p)
        {
            string sql = string.Format("update ParkBase set PBNumber='{0}',PBArea='{1}',PBType='{2}',PBPrice='{3}',PBPlace='{4}',Remark='{5}' where PBId='{6}'", p.PBNumber, p.PBArea, p.PBType, p.PBPrice, p.PBPlace, p.Remark, p.PBId);
            return DBHelper.ExecuteNonQuery(sql);
        }
        #endregion

        #region 车位租出信息
        public int AddPark(Park p)
        {
            string sql = string.Format("insert into Park values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", p.PBId, p.HostId, p.InRentSTime, p.OutRentSTime, p.CarType, p.CarNumber,p.Remark);
            return DBHelper.ExecuteNonQuery(sql);
        }

        public List<Park> GetParks()
        {
            // 车位类型 车主  车位编号
            string sql = "select * from Park";
            DataTable dt = DBHelper.GetDataTable(sql);
            return JsonConvert.DeserializeObject<List<Park>>(JsonConvert.SerializeObject(dt));
        }

        public int DelPark(int id)
        {
            string sql = "delete from Park where ParkId =" + id;
            return DBHelper.ExecuteNonQuery(sql);
        }

        public int UptPark(Park p)
        {
            string sql = string.Format("update Park set PBId='{0}',HostId='{1}',InRentSTime='{2}',OutRentSTime='{3}',CarType='{4}',CarNumber='{5}',Remark='{6}' where ParkId='{7}'", p.PBId, p.HostId, p.InRentSTime, p.OutRentSTime, p.CarType, p.CarNumber, p.Remark, p.ParkId);
            return DBHelper.ExecuteNonQuery(sql);
        }

        #endregion
    }
}

