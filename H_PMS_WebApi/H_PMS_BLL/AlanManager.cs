using System;
using System.Collections.Generic;
using H_PMS_DAL;
using H_PMS_Model;


namespace H_PMS_BLL
{
   public class AlanManager
   {
        public ParkBase GetPBMax()
        {
            return dal.GetPBMax();
        }
        #region ��¼
        AlanService dal = new AlanService();
        public Employee Login(string emp, string pwd)
        {
            return dal.Login(emp, pwd);
        }

        #endregion

        #region ��λ����

        public int AddParkBase(ParkBase p)
        {
            return dal.AddParkBase(p);
        }

        public List<Park> GetParkBases()
        {
            // ���� ���  ��Ǯ
            return dal.GetParkBases();
        }

        public int DelParkBase(int id)
        {
            return dal.DelParkBase(id);
        }

        public int UptParkBase(ParkBase p)
        {
            return dal.UptParkBase(p);
        }

        public List<HostInfo> ChaHost(string name, string idcard)
        {
            return dal.ChaHost(name, idcard);
        }

        public int UptPBState(ParkBase p)
        {
            return dal.UptPBState(p);
        }

        public int DelIdCard(string idcard)
        {
            return dal.DelIdCard(idcard);
        }

        public int UptRemark(Park p)
        {
            return dal.UptRemark(p);
        }

        public ParkBase GetPlace(string place)
        {
            return dal.GetPlace(place);
        }

        public ParkBase GetNumber(string number)
        {
            return dal.GetNumber(number);
        }
        #endregion

        #region ��λ�����Ϣ
        public int AddPark(Park p)
        {
            return dal.AddPark(p);
        }

        public List<Park> GetParks()
        {
            // ��λ���� ����  ��λ���
            return dal.GetParks();
        }

        public int DelPark(int id)
        {
            return dal.DelPark(id);
        }

        public int UptPark(Park p)
        {
            return dal.UptPark(p);
        }

        #endregion


    }
}

