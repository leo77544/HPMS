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
            if (PlotName != "��ѡ������")
            {
                SqlStr += "and PlotName = '" + PlotName + "'";
            }
            if (BulidName != "��ѡ��Ԫ")
            {
                SqlStr += "and BulidName = '" + BulidName + "'";
            }
            if (HouseType != "��ѡ����")
            {
                SqlStr += "and HouseType = '" + HouseType + "'";
            }
            if (HouseArea != "��ѡ�����")
            {
                SqlStr += "and HouseArea = '" + HouseArea + "'";
            }
            if (HouseState != "��ѡ��״̬")
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
            if (HouseState == "����")
            {
                DBHelper.ExecuteNonQuery("update HostInfo set MoveEtime = getdate() where HouseId = " + HouseId + "");
            }
            return DBHelper.ExecuteNonQuery("update HouseInfo set HouseState = '" + HouseState + "' where HouseId = " + HouseId + "");
        }

        /// <summary>
        /// ס���Ǽ� ��������ͥ��Ա�����͡��ÿ�
        /// </summary>
        /// <param name="TheHost"></param>
        /// <returns></returns>
        public int HostRegister(string HostName, string HostPhone, string IDCard, string Role, int HouseId)
        {
            if (DBHelper.ExecuteScalar("select count(IDCard) from HostInfo where IDCard = '" + IDCard + "' and MoveEtime != '1900-01-01 00:00:00.000'") > 0)
            {
                return -1;
            }
            DBHelper.ExecuteNonQuery("update HouseInfo set HouseState = '��ס' where HouseId = " + HouseId + "");
            return DBHelper.ExecuteNonQuery("insert into HostInfo values('" + HostName + "','" + HostPhone + "','" + IDCard + "','" + Role + "',getdate(),'',''," + HouseId + ")");
        }

        /// <summary>
        /// ס����ѯ
        /// </summary>
        /// <param name="HouseId">����Id</param>
        /// <param name="HostName">ס������</param>
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
            if (HostRole != "��ѡ��ס�����")
            {
                SqlStr += "and Role = '" + HostRole + "'";
            }
            return JsonConvert.DeserializeObject<List<HostInfo>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(SqlStr)));
        }
        #endregion

        #region Ͷ�߽���
        /// <summary>
        /// ����������ѯͶ����Ϣ
        /// </summary>
        /// <param name="CBName">Ͷ��ס����</param>
        /// <param name="CRemark">Ͷ��״̬-�ȴ����� �ȴ����� ���ٴ��� �����鵵</param>
        /// <returns></returns>
        public List<Complain> GetComplainsByConditions(string PlotName = "", string BulidName = "", string CBName = "", string CRemark = "")
        {
            string SqlStr = "select * from Complain where 1 = 1";
            if (PlotName != "��ѡ������")
            {
                SqlStr += "and CBName like '%" + PlotName + "%'";
            }
            if (BulidName != "��ѡ��Ԫ")
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
        /// ���Ͷ����Ϣ
        /// </summary>
        /// <param name="TheComplain"></param>
        /// <returns></returns>
        public int AddComplain(string CBName, string ReceptionEmp, string Ccontent)
        {
            return DBHelper.ExecuteNonQuery("insert into Complain values('" + CBName + "','" + ReceptionEmp + "',getdate(),'" + Ccontent + "','�ȴ�����')");
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