using ConnHelper;
using H_PMS_Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace H_PMS_DAL
{
    public class KevinService
    {

        #region Ա������
        /// <summary>
        /// Ա����ʾ����ѯ
        /// </summary>
        /// <param name="EName"></param>
        /// <param name="DId"></param>
        /// <returns></returns>
        public List<GetEmp> GetEmployees(string EName = "", int DId = -1)
        {
            string sql = $"select e.EmployeeId,e.EName,e.ESex,e.EAge,e.ESalary,e.EStartTime,d.DName from Employee e join Duty d on e.DId=d.DutyId where EName like '%{EName}%' and DId!=0 ";
            if (DId != -1)
            {
                sql += " and DId=" + DId;
            }
            List<GetEmp> list = JsonConvert.DeserializeObject<List<GetEmp>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(sql)));
            return list;
        }
        /// <summary>
        /// Ա�����
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int AddEmp(Employee employee)
        {
            return DBHelper.ExecuteNonQuery($"insert into Employee values('{employee.EName}','{employee.ESex}','{employee.EAge}','{employee.ESalary}','{employee.EStartTime}','{employee.DId}')");
        }
        /// <summary>
        /// ����ID��ȡEmp����
        /// </summary>
        /// <param name="EId"></param>
        /// <returns></returns>
        public Employee GetEmployeeByEId(int EId)
        {
            return JsonConvert.DeserializeObject<List<Employee>>(JsonConvert.SerializeObject(DBHelper.GetDataTable("select * from Employee where EmployeeId=" + EId)))[0];
        }
        /// <summary>
        /// �޸�Ա��
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int PutEmpByEId(Employee employee)
        {
            return DBHelper.ExecuteNonQuery($"updata Employee set EName='{employee.EName}' and ESex='{employee.ESex}' and EAge='{employee.EAge}' and ESalary='{employee.ESalary}' and EStartTime='{employee.EStartTime}' and DId='{employee.DId}' where EmployeeId={employee.EmployeeId}");
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int DelEmpByEId(int EmployeeId)
        {
            return DBHelper.ExecuteNonQuery("delete from Employee where EmployeeId=" + EmployeeId);
        }

        #endregion

        #region ���޹���
        /// <summary>
        /// ��ӱ��޵���
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        public int AddRepair(Repair repair)
        {
            return DBHelper.ExecuteNonQuery($"insert into Repair values('{repair.HostName}','{repair.HouseId}','{repair.ReNumber}','{repair.MaintainName}','{repair.RSTime}','{repair.MaintainTime}','{repair.ServePrice}','{repair.GoodsPrice}','{repair.PriceSum}','{repair.Estimate}','{repair.ReRemark}')");
        }
        /// <summary>
        /// ������ϸ
        /// </summary>
        /// <returns></returns>
        public List<Repair> GetRepairs()
        {
            return JsonConvert.DeserializeObject<List<Repair>>(JsonConvert.SerializeObject(DBHelper.GetDataTable("select * from repair")));
        }
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="PlotName"></param>
        /// <param name="BulidName"></param>
        /// <param name="HouseNumber"></param>
        /// <param name="HouseType"></param>
        /// <returns></returns>
        public string GetHouseInfoByHouse(string PlotName, string BulidName, string HouseNumber, string HouseType)
        {
            HouseInfo house = JsonConvert.DeserializeObject<HouseInfo>(JsonConvert.SerializeObject(DBHelper.GetDataTable($"select * from HouseInfo where PlotName='{PlotName}' and BulidName='{BulidName}' and HouseNumber='{HouseNumber}' and HouseType='{HouseType}'")));
            HostInfo host = JsonConvert.DeserializeObject<HostInfo>(JsonConvert.SerializeObject(DBHelper.GetDataTable($"select * from HostInfo where HouseId='{house.HouseId}'")));
            string jg = house.HouseId + "-" + host.HostName;
            return jg;
        }
        /// <summary>
        /// ���ı��޵���
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        public int PutRepair(Repair repair)
        {
            return DBHelper.ExecuteNonQuery($"updata Repair set HostName='{repair.HostName}' and HouseId='{repair.HouseId}' and  MaintainName='{repair.MaintainName}' and RSTime='{repair.RSTime}' and MaintainTime='{repair.MaintainTime}' and ServePrice='{repair.ServePrice}' and GoodsPrice='{repair.GoodsPrice}' and PriceSum='{repair.PriceSum}' and Estimate='{repair.Estimate}' and ReRemark='{repair.ReRemark}' where RepairId={repair.RepairId}");
        }
        #endregion

        #region �Ӵ�
        /// <summary>
        /// ��ӽӴ�����
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public int AddVisitor(Visitor visitor)
        {
            return DBHelper.ExecuteNonQuery($"insert into Visitor values('{visitor.VisitorName}','{visitor.HostName}','{visitor.StartTime}','{visitor.EndTime}')");
        }
        /// <summary>
        /// �ÿ��뿪�Ǽ�
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public int PutVisitor(Visitor visitor)
        {
            return DBHelper.ExecuteNonQuery($"update Visitor set EndTime='{visitor.EndTime}' where Visitorid={visitor.Visitorid}");
        }
        #endregion

        #region ֵ��-��

        /// <summary>
        /// ���ֵ��
        /// </summary>
        /// <param name="patrol"></param>
        /// <returns></returns>
        public int AddPatrol(Patrol patrol)
        {
            return DBHelper.ExecuteNonQuery($"insert into Patrol values('{patrol.EmployeeId}','{patrol.PatrolRport}','{patrol.PatrolArea}','{patrol.StartTime}','{patrol.EndTime}')");
        }
        #endregion

    }
}

