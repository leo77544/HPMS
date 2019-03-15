using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class Duty
    {
        private int dutyId;
        /// <summary>
        /// 主键，自增列，职务Id
        /// </summary>
        public int DutyId
        {
          get { return dutyId;}
          set { dutyId=value;}
        }
        private string dName;
        /// <summary>
        /// 职务名称
        /// </summary>
        public string DName
        {
          get { return dName;}
          set { dName=value;}
        }
    }
}
