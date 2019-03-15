using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class HouseInfo
    {
        private int houseId;
        /// <summary>
        /// �����������У�Ա��Id
        /// </summary>
        public int HouseId
        {
          get { return houseId;}
          set { houseId=value;}
        }
        private string plotName;
        /// <summary>
        /// С������
        /// </summary>
        public string PlotName
        {
          get { return plotName;}
          set { plotName=value;}
        }
        private string bulidName;
        /// <summary>
        /// ��Ԫ��
        /// </summary>
        public string BulidName
        {
          get { return bulidName;}
          set { bulidName=value;}
        }
        private string houseNumber;
        /// <summary>
        /// ���ݺ�
        /// </summary>
        public string HouseNumber
        {
          get { return houseNumber;}
          set { houseNumber=value;}
        }
        private string houseType;
        /// <summary>
        /// ����
        /// </summary>
        public string HouseType
        {
          get { return houseType;}
          set { houseType=value;}
        }
        private string houseArea;
        /// <summary>
        /// ���
        /// </summary>
        public string HouseArea
        {
          get { return houseArea;}
          set { houseArea=value;}
        }
        private string houseState;
        /// <summary>
        /// ״̬
        /// </summary>
        public string HouseState
        {
          get { return houseState;}
          set { houseState=value;}
        }
        private string remark;
        /// <summary>
        /// ����
        /// </summary>
        public string Remark
        {
          get { return remark;}
          set { remark=value;}
        }
    }
}
