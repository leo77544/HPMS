using System;
using System.Collections.Generic;
using H_PMS_DAL;
using H_PMS_Model;


namespace H_PMS_BLL
{
    public class MichaelManager
    {
        MichaelService MDAL = new MichaelService();

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
            return MDAL.GetHouseInfosByConditions(PlotName, BulidName, HouseType, HouseArea, HouseState);
        }

        /// <summary>
        /// �޸ķ���״̬
        /// </summary>
        /// <param name="HouseId">����Id</param>
        /// <param name="HouseState">����״̬</param>
        /// <returns></returns>
        public int ChangeHouseState(int HouseId, string HouseState)
        {
            return MDAL.ChangeHouseState(HouseId, HouseState);
        }

        /// <summary>
        /// ס���Ǽ� ��������ͥ��Ա�����͡��ÿ�
        /// </summary>
        /// <param name="TheHost"></param>
        /// <returns></returns>
        public int HostRegister(string HostName, string HostPhone, string IDCard, string Role, int HouseId)
        {
            return MDAL.HostRegister(HostName, HostPhone, IDCard, Role, HouseId);
        }

        /// <summary>
        /// ס����ѯ
        /// </summary>
        /// <param name="HouseId">����Id</param>
        /// <param name="HostName">ס������</param>
        /// <returns></returns>
        public List<HostInfo> GetHostInfosByConditions(int HouseId = 0, string HostName = "")
        {
            return MDAL.GetHostInfosByConditions(HouseId, HostName);
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
            return MDAL.GetComplainsByConditions(CBName, CRemark);
        }

        /// <summary>
        /// ���Ͷ����Ϣ
        /// </summary>
        /// <param name="TheComplain"></param>
        /// <returns></returns>
        public int AddComplain(Complain TheComplain)
        {
            return MDAL.AddComplain(TheComplain);
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
            return MDAL.FollowComplain(CSId, Ccontent, CRemark);
        }
        #endregion
    }
}

