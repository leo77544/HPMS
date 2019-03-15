using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class RecordInfo
    {
        private int rIId;
        /// <summary>
        /// 主键，自增列，出库Id
        /// </summary>
        public int RIId
        {
          get { return rIId;}
          set { rIId=value;}
        }
        private string costName;
        /// <summary>
        /// 费用名称
        /// </summary>
        public string CostName
        {
          get { return costName;}
          set { costName=value;}
        }
        private Single costPricce;
        /// <summary>
        /// 费用金额
        /// </summary>
        public Single CostPricce
        {
          get { return costPricce;}
          set { costPricce=value;}
        }
        private string sZState;
        /// <summary>
        /// 收支状态
        /// </summary>
        public string SZState
        {
          get { return sZState;}
          set { sZState=value;}
        }
        private DateTime tjStime;
        /// <summary>
        /// 统计日期
        /// </summary>
        public DateTime TjStime
        {
          get { return tjStime;}
          set { tjStime=value;}
        }
    }
}
