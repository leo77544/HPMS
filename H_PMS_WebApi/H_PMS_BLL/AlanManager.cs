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
        #region 登录
        AlanService dal = new AlanService();
        public Employee Login(string emp, string pwd)
        {
            return dal.Login(emp, pwd);
        }

        #endregion

        #region 车位管理

        public int AddParkBase(ParkBase p)
        {
            return dal.AddParkBase(p);
        }

        public List<ParkBase> GetParkBases()
        {
            // 类型 面积  价钱
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
        #endregion

        #region 车位租出信息
        public int AddPark(Park p)
        {
            return dal.AddPark(p);
        }

        public List<Park> GetParks()
        {
            // 车位类型 车主  车位编号
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

        public List<ParkBase> GetParkBaseByAll(string type, string area, string state)
        {
            return dal.GetParkBaseByAll(type, area, state);
        }

    }
}

