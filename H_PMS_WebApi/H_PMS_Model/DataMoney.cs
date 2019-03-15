using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class DataMoney
    {
        private int dMId;
        /// <summary>
        /// 主键，自增列，收费Id
        /// </summary>
        public int DMId
        {
          get { return dMId;}
          set { dMId=value;}
        }
        private string dMNumber;
        /// <summary>
        /// 收费编号
        /// </summary>
        public string DMNumber
        {
          get { return dMNumber;}
          set { dMNumber=value;}
        }
        private string hostName;
        /// <summary>
        /// 住户名称
        /// </summary>
        public string HostName
        {
          get { return hostName;}
          set { hostName=value;}
        }
        private DateTime dMSTime;
        /// <summary>
        /// 缴费日期
        /// </summary>
        public DateTime DMSTime
        {
          get { return dMSTime;}
          set { dMSTime=value;}
        }
        private string dMName;
        /// <summary>
        /// 收费人员
        /// </summary>
        public string DMName
        {
          get { return dMName;}
          set { dMName=value;}
        }
        private string dMWay;
        /// <summary>
        /// 缴费方式
        /// </summary>
        public string DMWay
        {
          get { return dMWay;}
          set { dMWay=value;}
        }
        private string dMType;
        /// <summary>
        /// 缴费类别
        /// </summary>
        public string DMType
        {
          get { return dMType;}
          set { dMType=value;}
        }
        private Single dMSum;
        /// <summary>
        /// 缴费总额
        /// </summary>
        public Single DMSum
        {
          get { return dMSum;}
          set { dMSum=value;}
        }
        private string remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
          get { return remark;}
          set { remark=value;}
        }
    }
}
