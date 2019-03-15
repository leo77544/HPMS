using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class ParkBase
    {
        private int pBId;
        /// <summary>
        /// 主键，自增列，车位Id
        /// </summary>
        public int PBId
        {
          get { return pBId;}
          set { pBId=value;}
        }
        private string pBNumber;
        /// <summary>
        /// 车位编号
        /// </summary>
        public string PBNumber
        {
          get { return pBNumber;}
          set { pBNumber=value;}
        }
        private string pBArea;
        /// <summary>
        /// 车位面积
        /// </summary>
        public string PBArea
        {
          get { return pBArea;}
          set { pBArea=value;}
        }
        private string pBType;
        /// <summary>
        /// 车位类型
        /// </summary>
        public string PBType
        {
          get { return pBType;}
          set { pBType=value;}
        }
        private string pBPrice;
        /// <summary>
        /// 车位价钱
        /// </summary>
        public string PBPrice
        {
          get { return pBPrice;}
          set { pBPrice=value;}
        }
        private string pBPlace;
        /// <summary>
        /// 车位位置
        /// </summary>
        public string PBPlace
        {
          get { return pBPlace;}
          set { pBPlace=value;}
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
