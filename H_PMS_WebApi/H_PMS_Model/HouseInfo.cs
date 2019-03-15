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
        /// 主键，自增列，员工Id
        /// </summary>
        public int HouseId
        {
          get { return houseId;}
          set { houseId=value;}
        }
        private string plotName;
        /// <summary>
        /// 小区名称
        /// </summary>
        public string PlotName
        {
          get { return plotName;}
          set { plotName=value;}
        }
        private string bulidName;
        /// <summary>
        /// 单元号
        /// </summary>
        public string BulidName
        {
          get { return bulidName;}
          set { bulidName=value;}
        }
        private string houseNumber;
        /// <summary>
        /// 房屋号
        /// </summary>
        public string HouseNumber
        {
          get { return houseNumber;}
          set { houseNumber=value;}
        }
        private string houseType;
        /// <summary>
        /// 房型
        /// </summary>
        public string HouseType
        {
          get { return houseType;}
          set { houseType=value;}
        }
        private string houseArea;
        /// <summary>
        /// 面积
        /// </summary>
        public string HouseArea
        {
          get { return houseArea;}
          set { houseArea=value;}
        }
        private string houseState;
        /// <summary>
        /// 状态
        /// </summary>
        public string HouseState
        {
          get { return houseState;}
          set { houseState=value;}
        }
        private string remark;
        /// <summary>
        /// 备用
        /// </summary>
        public string Remark
        {
          get { return remark;}
          set { remark=value;}
        }
    }
}
