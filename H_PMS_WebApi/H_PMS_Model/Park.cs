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
        /// �����������У���λʹ��Id
        /// </summary>
        public int ParkId
        {
          get { return parkId;}
          set { parkId=value;}
        }
        private string parkNumber;
        /// <summary>
        /// ��λId
        /// </summary>
        public string ParkNumber
        {
          get { return parkNumber;}
          set { parkNumber=value;}
        }
        private int hostId;
        /// <summary>
        /// ����id
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
        private DateTime inRentSTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime InRentSTime
        {
          get { return inRentSTime;}
          set { inRentSTime=value;}
        }
        private DateTime outRentSTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime OutRentSTime
        {
          get { return outRentSTime;}
          set { outRentSTime=value;}
        }
        private string carType;
        /// <summary>
        /// ������
        /// </summary>
        public string CarType
        {
          get { return carType;}
          set { carType=value;}
        }
        private string carNumber;
        /// <summary>
        /// ���ƺ�
        /// </summary>
        public string CarNumber
        {
          get { return carNumber;}
          set { carNumber=value;}
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
    }
}