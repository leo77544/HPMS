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
        private int pBId;
        /// <summary>
        /// ��λId
        /// </summary>
        public int PBId
        {
            get { return pBId; }
            set { pBId = value; }
        }
        private string hostId;
        /// <summary>
        /// ����id
        /// </summary>
        public string HostId
        {
            get { return hostId; }
            set { hostId = value; }
        }
        private string inRentSTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string InRentSTime
        {
          get { return inRentSTime;}
          set { inRentSTime=value;}
        }
        private string outRentSTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string OutRentSTime
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
        private string iDCard;
        /// <summary>
        /// ���֤
        /// </summary>
        public string IDCard
        {
            get { return iDCard; }
            set { iDCard = value; }
        }

        #region ����


        private string pBNumber;
        /// <summary>
        /// ��λ���
        /// </summary>
        public string PBNumber
        {
            get { return pBNumber; }
            set { pBNumber = value; }
        }
        private string pBArea;
        /// <summary>
        /// ��λ���
        /// </summary>
        public string PBArea
        {
            get { return pBArea; }
            set { pBArea = value; }
        }
        private string pBType;
        /// <summary>
        /// ��λ����
        /// </summary>
        public string PBType
        {
            get { return pBType; }
            set { pBType = value; }
        }
        private string pBPrice;
        /// <summary>
        /// ��λ��Ǯ
        /// </summary>
        public string PBPrice
        {
            get { return pBPrice; }
            set { pBPrice = value; }
        }
        private string pBPlace;
        /// <summary>
        /// ��λλ��
        /// </summary>
        public string PBPlace
        {
            get { return pBPlace; }
            set { pBPlace = value; }
        }
        private string remark2;
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark2
        {
            get { return remark2; }
            set { remark2 = value; }
        }
        #endregion
    }
}
