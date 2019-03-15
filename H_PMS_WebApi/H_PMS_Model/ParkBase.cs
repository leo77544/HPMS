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
        /// �����������У���λId
        /// </summary>
        public int PBId
        {
          get { return pBId;}
          set { pBId=value;}
        }
        private string pBNumber;
        /// <summary>
        /// ��λ���
        /// </summary>
        public string PBNumber
        {
          get { return pBNumber;}
          set { pBNumber=value;}
        }
        private string pBArea;
        /// <summary>
        /// ��λ���
        /// </summary>
        public string PBArea
        {
          get { return pBArea;}
          set { pBArea=value;}
        }
        private string pBType;
        /// <summary>
        /// ��λ����
        /// </summary>
        public string PBType
        {
          get { return pBType;}
          set { pBType=value;}
        }
        private string pBPrice;
        /// <summary>
        /// ��λ��Ǯ
        /// </summary>
        public string PBPrice
        {
          get { return pBPrice;}
          set { pBPrice=value;}
        }
        private string pBPlace;
        /// <summary>
        /// ��λλ��
        /// </summary>
        public string PBPlace
        {
          get { return pBPlace;}
          set { pBPlace=value;}
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
