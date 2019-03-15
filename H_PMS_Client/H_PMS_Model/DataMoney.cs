using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class DataMoney
    {
        private int dMId;
        /// <summary>
        /// �����������У��շ�Id
        /// </summary>
        public int DMId
        {
          get { return dMId;}
          set { dMId=value;}
        }
        private string dMNumber;
        /// <summary>
        /// �շѱ��
        /// </summary>
        public string DMNumber
        {
          get { return dMNumber;}
          set { dMNumber=value;}
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
        private DateTime dMSTime;
        /// <summary>
        /// �ɷ�����
        /// </summary>
        public DateTime DMSTime
        {
          get { return dMSTime;}
          set { dMSTime=value;}
        }
        private string dMName;
        /// <summary>
        /// �շ���Ա
        /// </summary>
        public string DMName
        {
          get { return dMName;}
          set { dMName=value;}
        }
        private string dMWay;
        /// <summary>
        /// �ɷѷ�ʽ
        /// </summary>
        public string DMWay
        {
          get { return dMWay;}
          set { dMWay=value;}
        }
        private string dMType;
        /// <summary>
        /// �ɷ����
        /// </summary>
        public string DMType
        {
          get { return dMType;}
          set { dMType=value;}
        }
        private Single dMSum;
        /// <summary>
        /// �ɷ��ܶ�
        /// </summary>
        public Single DMSum
        {
          get { return dMSum;}
          set { dMSum=value;}
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
