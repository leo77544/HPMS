using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_PMS_BLL;
using H_PMS_Model;

namespace H_PMS_WebApi.Controllers
{
    public class HPMSController : ApiController
    {
        AlanManager Alan = new AlanManager();
        LeoManager leo = new LeoManager();
        KevinManager Kevin = new KevinManager();
        MichaelManager Michael = new MichaelManager();

        #region Alan

        #region 登录
        public Employee Login(string emp, string pwd)
        {
            return Alan.Login(emp, pwd);
        }

        #endregion

        #region 车位管理

        public int AddParkBase(ParkBase p)
        {
            return Alan.AddParkBase(p);
        }

        public List<ParkBase> GetParkBases()
        {
            // 类型 面积  价钱
            return Alan.GetParkBases();
        }

        public int DelParkBase(int id)
        {
            return Alan.DelParkBase(id);
        }

        public int UptParkBase(ParkBase p)
        {
            return Alan.UptParkBase(p);
        }
        #endregion

        #region 车位租出信息
        public int AddPark(Park p)
        {
            return Alan.AddPark(p);
        }

        public List<Park> GetParks()
        {
            // 车位类型 车主  车位编号
            return Alan.GetParks();
        }

        public int DelPark(int id)
        {
            return Alan.DelPark(id);
        }

        public int UptPark(Park p)
        {
            return Alan.UptPark(p);
        }

        #endregion

        #endregion

        #region leo
        /// <summary>
        /// 添加收费信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        static public int AddDataMoney(DataMoney m)
        {
            return LeoManager.AddDataMoney(m);
        }
        #endregion

        #region Kevin

        #endregion

        #region Michael

        #endregion
    }
}
