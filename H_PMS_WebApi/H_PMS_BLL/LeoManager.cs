using H_PMS_DAL;
using H_PMS_Model;
using System;
using System.Collections.Generic;


namespace H_PMS_BLL
{
   public class LeoManager
   {
        /// <summary>
        /// 添加收费信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
      static  public int AddDataMoney(DataMoney m)
        {

            return LeoService.AddDataMoney(m);
         }
        /// <summary>
        /// 查看缴费信息
        /// </summary>
        /// <returns></returns>
        static public List<DataMoney> GetDataMoney()
        {
            return LeoService.GetDataMoney();
        }
        /// <summary>
        /// 查看报表信息
        /// </summary>
        /// <returns></returns>
        static public List<RecordInfo> GetRecordInfo()
        {
            return LeoService.GetRecordInfo();
        }

    }
}

