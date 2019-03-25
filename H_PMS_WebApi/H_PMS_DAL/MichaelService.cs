using System;
using System.Collections.Generic;
using ConnHelper;
using H_PMS_Model;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace H_PMS_DAL
{
    public class MichaelService
    {
        #region 房屋信息
        /// <summary>
        /// 根据条件查询房屋信息
        /// </summary>
        /// <param name="PlotName">区域名称</param>
        /// <param name="BulidName">单元号</param>
        /// <param name="HouseType">户型</param>
        /// <param name="HouseArea">占地面积</param>
        /// <param name="HouseState">状态-空闲 入住 招租 待修</param>
        /// <returns></returns>
        public List<HouseInfo> GetHouseInfosByConditions(string PlotName = "", string BulidName = "", string HouseType = "", string HouseArea = "", string HouseState = "")
        {
            string SqlStr = "select * from HouseInfo where 1=1";
            if (PlotName != "请选择区域")
            {
                SqlStr += "and PlotName = '" + PlotName + "'";
            }
            if (BulidName != "请选择单元")
            {
                SqlStr += "and BulidName = '" + BulidName + "'";
            }
            if (HouseType != "请选择户型")
            {
                SqlStr += "and HouseType = '" + HouseType + "'";
            }
            if (HouseArea != "请选择面积")
            {
                SqlStr += "and HouseArea = '" + HouseArea + "'";
            }
            if (HouseState != "请选择状态")
            {
                SqlStr += "and HouseState = '" + HouseState + "'";
            }
            return JsonConvert.DeserializeObject<List<HouseInfo>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(SqlStr)));
        }

        /// <summary>
        /// 修改房屋状态
        /// </summary>
        /// <param name="HouseId">房屋Id</param>
        /// <param name="HouseState">房屋状态</param>
        /// <returns></returns>
        public int ChangeHouseState(int HouseId, string HouseState)
        {
            if (HouseState == "空闲")
            {
                DBHelper.ExecuteNonQuery("update HostInfo set MoveEtime = getdate() where HouseId = " + HouseId + "");
            }
            return DBHelper.ExecuteNonQuery("update HouseInfo set HouseState = '" + HouseState + "' where HouseId = " + HouseId + "");
        }

        /// <summary>
        /// 住户登记 房主、家庭成员、房客、访客
        /// </summary>
        /// <param name="TheHost"></param>
        /// <returns></returns>
        public int HostRegister(string HostName, string HostPhone, string IDCard, string Role, int HouseId)
        {
            if (DBHelper.ExecuteScalar("select count(IDCard) from HostInfo where IDCard = '" + IDCard + "' and MoveEtime != '1900-01-01 00:00:00.000'") > 0)
            {
                return -1;
            }
            DBHelper.ExecuteNonQuery("update HouseInfo set HouseState = '入住' where HouseId = " + HouseId + "");
            return DBHelper.ExecuteNonQuery("insert into HostInfo values('" + HostName + "','" + HostPhone + "','" + IDCard + "','" + Role + "',getdate(),'',''," + HouseId + ")");
        }

        /// <summary>
        /// 住户查询
        /// </summary>
        /// <param name="HouseId">房屋Id</param>
        /// <param name="HostName">住户姓名</param>
        /// <returns></returns>
        public List<HostInfo> GetHostInfosByConditions(int HouseId = 0, string HostName = "", string HostRole = "")
        {
            string SqlStr = "select * from HostInfo where MoveEtime = '1900-01-01 00:00:00.000'";
            if (HouseId != 0)
            {
                SqlStr += "and HouseId = " + HouseId + "";
            }
            if (HostName != "")
            {
                SqlStr += "and HostName like '%" + HostName + "%'";
            }
            if (HostRole != "请选择住户身份")
            {
                SqlStr += "and Role = '" + HostRole + "'";
            }
            return JsonConvert.DeserializeObject<List<HostInfo>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(SqlStr)));
        }
        #endregion

        #region 投诉建议
        /// <summary>
        /// 根据条件查询投诉信息
        /// </summary>
        /// <param name="CBName">投诉住户名</param>
        /// <param name="CRemark">投诉状态-等待处理 等待反馈 需再处理 结束归档</param>
        /// <returns></returns>
        public List<Complain> GetComplainsByConditions(string PlotName = "", string BulidName = "", string CBName = "", string CRemark = "")
        {
            string SqlStr = "select * from Complain where 1 = 1";
            if (PlotName != "请选择区域")
            {
                SqlStr += "and CBName like '%" + PlotName + "%'";
            }
            if (BulidName != "请选择单元")
            {
                SqlStr += "and CBName like '%" + BulidName + "%'";
            }
            if (CBName != "")
            {
                SqlStr += "and CBName like '%" + CBName + "%'";
            }
            if (CRemark != "")
            {
                SqlStr += " and CRemark = '" + CRemark + "'";
            }
            return JsonConvert.DeserializeObject<List<Complain>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(SqlStr)));
        }

        /// <summary>
        /// 添加投诉信息
        /// </summary>
        /// <param name="TheComplain"></param>
        /// <returns></returns>
        public int AddComplain(string CBName, string ReceptionEmp, string Ccontent)
        {
            return DBHelper.ExecuteNonQuery("insert into Complain values('" + CBName + "','" + ReceptionEmp + "',getdate(),'" + Ccontent + "','等待处理')");
        }

        /// <summary> 
        /// 投诉跟进
        /// </summary>
        /// <param name="CSId">投诉记录Id</param>
        /// <param name="Ccontent">投诉详情</param>
        /// <param name="CRemark">投诉状态</param>
        /// <returns></returns>
        public int FollowComplain(int CSId, string Ccontent, string CRemark)
        {
            return DBHelper.ExecuteNonQuery("update Complain set Ccontent = Ccontent+'" + Ccontent + "',CRemark = '" + CRemark + "' where CSId = " + CSId + "");
        }
        #endregion
    }
}