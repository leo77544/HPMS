using H_PMS_DAL;
using H_PMS_Model;
using System;
using System.Collections.Generic;
using System.Data;

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
        /// <summary>
        /// 查询当日
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public DataTable GetDayCount(string str)
        {
            return LeoService.GetDayCount( str);
        }
        /// <summary>
        /// 查询当月
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public DataTable GetMonthCount(string str)
        {
            return LeoService.GetMonthCount(str);

        }
        /// <summary>
        /// 查询当年
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public DataTable GetYearCount(string str)
        {
            return LeoService.GetYearCount(str);

        }
    }
}

