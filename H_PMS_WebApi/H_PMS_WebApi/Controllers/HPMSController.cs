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

        #endregion

        #region leo
        /// <summary>
        /// 添加收费信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        static public int AddDataMoney(DataMoney m)
        {
            return LeoManager.AddDataMoney(m);
        }

        /// <summary>
        /// 查看缴费信息
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        static public List<DataMoney> GetDataMoney()
        {
            return LeoManager.GetDataMoney();
        }
        /// <summary>
        /// 查看报表信息
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        static public List<RecordInfo> GetRecordInfo()
        {
            return LeoManager.GetRecordInfo();
        }
        #endregion

        #region Kevin

        #endregion

        #region Michael

        #endregion
    }
}
