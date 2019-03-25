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
        #region 添加收费信息
        /// <summary>
        /// 添加收费信息
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
            return result;

        }
        #endregion

        #region 查看缴费信息
        /// <summary>
        /// 查看缴费信息
        /// </summary>
        /// <returns></returns>
        static public List<DataMoney> GetDataMoney()
        {
            return JsonConvert.DeserializeObject<List<DataMoney>>(JsonConvert.SerializeObject(DBHelper.GetDataTable("select * from DataMoney order by Dmid desc ")));
        }
        #endregion

        #region 查看报表信息
        /// <summary>
        /// 查看报表信息
        /// </summary>
        /// <returns></returns>
        static public List<RecordInfo> GetRecordInfo()
        {
            return JsonConvert.DeserializeObject<List<RecordInfo>>(JsonConvert.SerializeObject(DBHelper.GetDataTable("select * from RecordInfo order by RIId desc ")));
        } 
        #endregion

        /// <summary>
        /// 查询当日
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public DataTable GetDayCount(string str)
        {
            return JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(DBHelper.GetDataTable($"select year(TjStime) year, month(TjStime) month, day(TjStime) day, sum(CostPricce) sum from RecordInfo group by year(TjStime), month(TjStime), day(TjStime) having year(TjStime) = year('{str}') and month(TjStime) = month('{str}') and day(TjStime) = day('{str}')")));
        }
        /// <summary>
        /// 查询当月
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public DataTable GetMonthCount(string str)
        {
            return JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(DBHelper.GetDataTable($"select year(TjStime) year, month(TjStime) month,sum(CostPricce) sum from RecordInfo group by year(TjStime), month(TjStime) having year(TjStime) = year('{str}') and month(TjStime) = month('{str}')")));
        }
        /// <summary>
        /// 查询当年
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public DataTable GetYearCount(string str)
        {
            return JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(DBHelper.GetDataTable($"select year(TjStime) year,  sum(CostPricce) sum from RecordInfo group by year(TjStime) having year(TjStime) = year('{str}')")));
        }
    }
}

