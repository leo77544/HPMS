using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class RecordInfo
    {
        private int rIId;
        /// <summary>
        /// �����������У�����Id
        /// </summary>
        public int RIId
        {
          get { return rIId;}
          set { rIId=value;}
        }
        private string costName;
        /// <summary>
        /// ��������
        /// </summary>
        public string CostName
        {
          get { return costName;}
          set { costName=value;}
        }
        private Single costPricce;
        /// <summary>
        /// ���ý��
        /// </summary>
        public Single CostPricce
        {
          get { return costPricce;}
          set { costPricce=value;}
        }
        private string sZState;
        /// <summary>
        /// ��֧״̬
        /// </summary>
        public string SZState
        {
          get { return sZState;}
          set { sZState=value;}
        }
        private DateTime tjStime;
        /// <summary>
        /// ͳ������
        /// </summary>
        public DateTime TjStime
        {
          get { return tjStime;}
          set { tjStime=value;}
        }
    }
}
