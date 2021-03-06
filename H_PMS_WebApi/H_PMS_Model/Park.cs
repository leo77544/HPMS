using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class Park
    {
        private int parkId;
        /// <summary>
        /// 主键，自增列，车位使用Id
        /// </summary>
        public int ParkId
        {
          get { return parkId;}
          set { parkId=value;}
        }
        private string parkNumber;
        /// <summary>
        /// 车位Id
        /// </summary>
        public string ParkNumber
        {
          get { return parkNumber;}
          set { parkNumber=value;}
        }
        private int hostId;
        /// <summary>
        /// 车主id
        /// </summary>
        public int HostId
        {
          get { return hostId;}
          set { hostId=value;}
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
        private DateTime inRentSTime;
        /// <summary>
        /// 入租时间
        /// </summary>
        public DateTime InRentSTime
        {
          get { return inRentSTime;}
          set { inRentSTime=value;}
        }
        private DateTime outRentSTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime OutRentSTime
        {
          get { return outRentSTime;}
          set { outRentSTime=value;}
        }
        private string carType;
        /// <summary>
        /// 车类型
        /// </summary>
        public string CarType
        {
          get { return carType;}
          set { carType=value;}
        }
        private string carNumber;
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNumber
        {
          get { return carNumber;}
          set { carNumber=value;}
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
