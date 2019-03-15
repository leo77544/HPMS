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
        /// �����������У�����ID
        /// </summary>
        public int HostId
        {
          get { return hostId;}
          set { hostId=value;}
        }
        private string hostName;
        /// <summary>
        /// ס������
        /// </summary>
        public string HostName
        {
          get { return hostName;}
          set { hostName=value;}
        }
        private string hostPhone;
        /// <summary>
        /// ס���绰
        /// </summary>
        public string HostPhone
        {
          get { return hostPhone;}
          set { hostPhone=value;}
        }
        private string iDCard;
        /// <summary>
        /// ���֤
        /// </summary>
        public string IDCard
        {
          get { return iDCard;}
          set { iDCard=value;}
        }
        private string role;
        /// <summary>
        /// ���
        /// </summary>
        public string Role
        {
          get { return role;}
          set { role=value;}
        }
        private DateTime moveStime;
        /// <summary>
        /// Ǩ������
        /// </summary>
        public DateTime MoveStime
        {
          get { return moveStime;}
          set { moveStime=value;}
        }
        private DateTime moveEtime;
        /// <summary>
        /// Ǩ������
        /// </summary>
        public DateTime MoveEtime
        {
          get { return moveEtime;}
          set { moveEtime=value;}
        }
        private string remark;
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
          get { return remark;}
          set { remark=value;}
        }
        private int houseId;
        /// <summary>
        /// ����Id
        /// </summary>
        public int HouseId
        {
          get { return houseId;}
          set { houseId=value;}
        }
    }
}
