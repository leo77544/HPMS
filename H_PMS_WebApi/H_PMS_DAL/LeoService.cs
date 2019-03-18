using System;
using System.Collections.Generic;
using ConnHelper;
using H_PMS_Model;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace H_PMS_DAL
{
    public class LeoService
    {
        #region ����շ���Ϣ
        /// <summary>
        /// ����շ���Ϣ
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        static public int AddDataMoney(DataMoney m)
        {
            SqlParameter DMNumber = new SqlParameter("@DMNumber", SqlDbType.VarChar);
            DMNumber.Value = m.DMNumber;
            SqlParameter HostName = new SqlParameter("@HostName", SqlDbType.VarChar);
            HostName.Value = m.HostName;
            SqlParameter DMSTime = new SqlParameter("@DMSTime", SqlDbType.DateTime);
            DMSTime.Value = m.DMSTime;
            SqlParameter DMName = new SqlParameter("@DMName", SqlDbType.VarChar);
            DMName.Value = m.DMName;
            SqlParameter DMWay = new SqlParameter("@DMWay", SqlDbType.VarChar);
            DMWay.Value = m.DMWay;
            SqlParameter DMType = new SqlParameter("@DMType", SqlDbType.VarChar);
            DMType.Value = m.DMType;
            SqlParameter DMSum = new SqlParameter("@DMSum", SqlDbType.Float);
            DMSum.Value = m.DMSum;
            SqlParameter Remark = new SqlParameter("@Remark", SqlDbType.VarChar);
            Remark.Value = m.Remark;
            SqlParameter pcode = new SqlParameter("@Code", SqlDbType.Int);
            pcode.Direction = ParameterDirection.Output;
            SqlParameter[] para = { DMNumber, HostName, DMSTime, DMName, DMWay, DMType, DMSum, Remark, pcode };
            int result = DBHelperProc.ExecuteNonQuery("P_dataMomey", para);
            return Convert.ToInt32(pcode) + result;

        }
        #endregion

        #region �鿴�ɷ���Ϣ
        /// <summary>
        /// �鿴�ɷ���Ϣ
        /// </summary>
        /// <returns></returns>
        static public List<DataMoney> GetDataMoney()
        {
            return JsonConvert.DeserializeObject<List<DataMoney>>(JsonConvert.SerializeObject(DBHelper.GetDataTable("select * from DataMoney")));
        }
        #endregion

        #region �鿴������Ϣ
        /// <summary>
        /// �鿴������Ϣ
        /// </summary>
        /// <returns></returns>
        static public List<RecordInfo> GetRecordInfo()
        {
            return JsonConvert.DeserializeObject<List<RecordInfo>>(JsonConvert.SerializeObject(DBHelper.GetDataTable("select * from RecordInfo")));
        } 
        #endregion

    }
}

