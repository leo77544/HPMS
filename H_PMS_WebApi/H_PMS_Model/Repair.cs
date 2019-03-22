using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class Repair
    {
        private int repairId;
        /// <summary>
        /// 主键，自增列，报修Id
        /// </summary>
        public int RepairId
        {
          get { return repairId;}
          set { repairId=value;}
        }
        private string hostName;
        /// <summary>
        /// 住户名称
        /// </summary>
        public string HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }
        private int houseId;
        /// <summary>
        /// 房屋Id
        /// </summary>
        public int HouseId
        {
            get { return houseId; }
            set { houseId = value; }
        }
        private string reNumber;
        /// <summary>
        /// 单据编号	
        /// </summary>
        public string ReNumber
        {
          get { return reNumber;}
          set { reNumber=value;}
        }
        private string maintainName;
        /// <summary>
        /// 维修人员
        /// </summary>
        public string MaintainName
        {
          get { return maintainName;}
          set { maintainName=value;}
        }
        private DateTime rSTime;
        /// <summary>
        /// 报修日期
        /// </summary>
        public DateTime RSTime
        {
          get { return rSTime;}
          set { rSTime=value;}
        }
        private DateTime maintainTime;
        /// <summary>
        /// 维修日期
        /// </summary>
        public DateTime MaintainTime
        {
          get { return maintainTime;}
          set { maintainTime=value;}
        }
        private Single servePrice;
        /// <summary>
        /// 服务费用
        /// </summary>
        public Single ServePrice
        {
          get { return servePrice;}
          set { servePrice=value;}
        }
        private Single goodsPrice;
        /// <summary>
        /// 物料费用
        /// </summary>
        public Single GoodsPrice
        {
          get { return goodsPrice;}
          set { goodsPrice=value;}
        }
        private Single priceSum;
        /// <summary>
        /// 费用合计
        /// </summary>
        public Single PriceSum
        {
          get { return priceSum;}
          set { priceSum=value;}
        }
        private string estimate;
        /// <summary>
        /// 评价
        /// </summary>
        public string Estimate
        {
          get { return estimate;}
          set { estimate=value;}
        }
        private string reRemark;
        /// <summary>
        /// 报修内容
        /// </summary>
        public string ReRemark
        {
          get { return reRemark;}
          set { reRemark=value;}
        }
    }
}
