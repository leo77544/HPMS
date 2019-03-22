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
        /// �����������У�����Id
        /// </summary>
        public int RepairId
        {
          get { return repairId;}
          set { repairId=value;}
        }
        private string hostName;
        /// <summary>
        /// ס������
        /// </summary>
        public string HostName
        {
            get { return hostName; }
            set { hostName = value; }
        }
        private int houseId;
        /// <summary>
        /// ����Id
        /// </summary>
        public int HouseId
        {
            get { return houseId; }
            set { houseId = value; }
        }
        private string reNumber;
        /// <summary>
        /// ���ݱ��	
        /// </summary>
        public string ReNumber
        {
          get { return reNumber;}
          set { reNumber=value;}
        }
        private string maintainName;
        /// <summary>
        /// ά����Ա
        /// </summary>
        public string MaintainName
        {
          get { return maintainName;}
          set { maintainName=value;}
        }
        private DateTime rSTime;
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime RSTime
        {
          get { return rSTime;}
          set { rSTime=value;}
        }
        private DateTime maintainTime;
        /// <summary>
        /// ά������
        /// </summary>
        public DateTime MaintainTime
        {
          get { return maintainTime;}
          set { maintainTime=value;}
        }
        private Single servePrice;
        /// <summary>
        /// �������
        /// </summary>
        public Single ServePrice
        {
          get { return servePrice;}
          set { servePrice=value;}
        }
        private Single goodsPrice;
        /// <summary>
        /// ���Ϸ���
        /// </summary>
        public Single GoodsPrice
        {
          get { return goodsPrice;}
          set { goodsPrice=value;}
        }
        private Single priceSum;
        /// <summary>
        /// ���úϼ�
        /// </summary>
        public Single PriceSum
        {
          get { return priceSum;}
          set { priceSum=value;}
        }
        private string estimate;
        /// <summary>
        /// ����
        /// </summary>
        public string Estimate
        {
          get { return estimate;}
          set { estimate=value;}
        }
        private string reRemark;
        /// <summary>
        /// ��������
        /// </summary>
        public string ReRemark
        {
          get { return reRemark;}
          set { reRemark=value;}
        }
    }
}
