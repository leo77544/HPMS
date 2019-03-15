using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class HostInfo
    {
        private int hostId;
        /// <summary>
        /// 主键，自增列，户主ID
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
        private string hostPhone;
        /// <summary>
        /// 住户电话
        /// </summary>
        public string HostPhone
        {
          get { return hostPhone;}
          set { hostPhone=value;}
        }
        private string iDCard;
        /// <summary>
        /// 身份证
        /// </summary>
        public string IDCard
        {
          get { return iDCard;}
          set { iDCard=value;}
        }
        private string role;
        /// <summary>
        /// 身份
        /// </summary>
        public string Role
        {
          get { return role;}
          set { role=value;}
        }
        private DateTime moveStime;
        /// <summary>
        /// 迁入日期
        /// </summary>
        public DateTime MoveStime
        {
          get { return moveStime;}
          set { moveStime=value;}
        }
        private DateTime moveEtime;
        /// <summary>
        /// 迁出日期
        /// </summary>
        public DateTime MoveEtime
        {
          get { return moveEtime;}
          set { moveEtime=value;}
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
        private int houseId;
        /// <summary>
        /// 房屋Id
        /// </summary>
        public int HouseId
        {
          get { return houseId;}
          set { houseId=value;}
        }
    }
}
