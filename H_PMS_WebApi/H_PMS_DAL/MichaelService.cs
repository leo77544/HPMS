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
        #region ������Ϣ
        /// <summary>
        /// ����������ѯ������Ϣ
        /// </summary>
        /// <param name="PlotName">��������</param>
        /// <param name="BulidName">��Ԫ��</param>
        /// <param name="HouseType">����</param>
        /// <param name="HouseArea">ռ�����</param>
        /// <param name="HouseState">״̬-���� ��ס ���� ����</param>
        /// <returns></returns>
        public List<HouseInfo> GetHouseInfosByConditions(string PlotName = "", string BulidName = "", string HouseType = "", string HouseArea = "", string HouseState = "")
        {
            string SqlStr = "select * from HouseInfo where 1=1";
            if (PlotName != "")
            {
                SqlStr += "and PlotName = '" + PlotName + "'";
            }
            if (BulidName != "")
            {
                SqlStr += "and BulidName = '" + BulidName + "'";
            }
            if (HouseType != "")
            {
                SqlStr += "and HouseType = '" + HouseType + "'";
            }
            if (HouseArea != "")
            {
                SqlStr += "and HouseArea = '" + HouseArea + "'";
            }
            if (HouseState != "")
            {
                SqlStr += "and HouseState = '" + HouseState + "'";
            }
            return JsonConvert.DeserializeObject<List<HouseInfo>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(SqlStr)));
        }

        /// <summary>
        /// �޸ķ���״̬
        /// </summary>
        /// <param name="HouseId">����Id</param>
        /// <param name="HouseState">����״̬</param>
        /// <returns></returns>
        public int ChangeHouseState(int HouseId, string HouseState)
        {
            return DBHelper.ExecuteNonQuery("update HouseInfo set HouseState = '" + HouseState + "' where HouseId = " + HouseId + "");
        }

        /// <summary>
        /// ס���Ǽ� ��������ͥ��Ա�����͡��ÿ�
        /// </summary>
        /// <param name="TheHost"></param>
        /// <returns></returns>
        public int HostRegister(HostInfo TheHost)
        {
            return DBHelper.ExecuteNonQuery("insert into HostInfo values('" + TheHost.HostName + "','" + TheHost.HostPhone + "','" + TheHost.IDCard + "','" + TheHost.Role + "',getdate(),'" + TheHost.MoveEtime + "','" + TheHost.Remark + "'," + TheHost.HouseId + ")");
        }

        /// <summary>
        /// ס����ѯ
        /// </summary>
        /// <param name="HouseId">����Id</param>
        /// <param name="HostName">ס������</param>
        /// <returns></returns>
        public List<HostInfo> GetHostInfosByConditions(int HouseId = 0, string HostName = "")
        {
            string SqlStr = "select * from HostInfo where 1 = 1";
            if (HouseId != 0)
            {
                SqlStr += "and HouseId = " + HouseId + "";
            }
            else
            {
                SqlStr += "and HostName like '%" + HostName + "%'";
            }
            return JsonConvert.DeserializeObject<List<HostInfo>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(SqlStr)));
        }
        #endregion

        #region Ͷ�߽���
        /// <summary>
        /// ����������ѯͶ����Ϣ
        /// </summary>
        /// <param name="CBName">Ͷ��ס����</param>
        /// <param name="CRemark">Ͷ��״̬-��������� ��������� ���ٴ��� �鵵</param>
        /// <returns></returns>
        public List<Complain> GetComplainsByConditions(string CBName = "", string CRemark = "")
        {
            string SqlStr = "select * from Complain where 1 = 1";
            if (CBName != "")
            {
                SqlStr += "CBName = '" + CBName + "'";
            }
            if (CRemark != "")
            {
                SqlStr += "CRemark = '" + CRemark + "'";
            }
            return JsonConvert.DeserializeObject<List<Complain>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(SqlStr)));
        }

        /// <summary>
        /// ���Ͷ����Ϣ
        /// </summary>
        /// <param name="TheComplain"></param>
        /// <returns></returns>
        public int AddComplain(Complain TheComplain)
        {
            return DBHelper.ExecuteNonQuery("insert into Complain values('" + TheComplain.CBName + "','" + TheComplain.ReceptionEmp + "',getdate(),'" + TheComplain.Ccontent + "','���������')");
        }

        /// <summary> 
        /// Ͷ�߸���
        /// </summary>
        /// <param name="CSId">Ͷ�߼�¼Id</param>
        /// <param name="Ccontent">Ͷ������</param>
        /// <param name="CRemark">Ͷ��״̬</param>
        /// <returns></returns>
        public int FollowComplain(int CSId, string Ccontent, string CRemark)
        {
            return DBHelper.ExecuteNonQuery("update Complain set Ccontent = Ccontent+'" + Ccontent + "',CRemark = '" + CRemark + "' where CSId = " + CSId + "");
        } 
        #endregion
    }
}