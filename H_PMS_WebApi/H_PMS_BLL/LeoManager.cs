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
        /// ����շ���Ϣ
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
      static  public int AddDataMoney(DataMoney m)
        {

            return LeoService.AddDataMoney(m);
         }
        /// <summary>
        /// �鿴�ɷ���Ϣ
        /// </summary>
        /// <returns></returns>
        static public List<DataMoney> GetDataMoney()
        {
            return LeoService.GetDataMoney();
        }
        /// <summary>
        /// �鿴������Ϣ
        /// </summary>
        /// <returns></returns>
        static public List<RecordInfo> GetRecordInfo()
        {
            return LeoService.GetRecordInfo();
        }
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public DataTable GetDayCount(string str)
        {
            return LeoService.GetDayCount( str);
        }
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public DataTable GetMonthCount(string str)
        {
            return LeoService.GetMonthCount(str);

        }
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public DataTable GetYearCount(string str)
        {
            return LeoService.GetYearCount(str);

        }
    }
}

