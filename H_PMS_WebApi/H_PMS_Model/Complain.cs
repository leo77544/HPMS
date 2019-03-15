using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class Complain
    {
        private int cSId;

        public int CSId
        {
          get { return cSId;}
          set { cSId=value;}
        }
        private string cBName;

        public string CBName
        {
          get { return cBName;}
          set { cBName=value;}
        }
        private string receptionEmp;

        public string ReceptionEmp
        {
          get { return receptionEmp;}
          set { receptionEmp=value;}
        }
        private DateTime cSTime;

        public DateTime CSTime
        {
          get { return cSTime;}
          set { cSTime=value;}
        }
        private string ccontent;

        public string Ccontent
        {
          get { return ccontent;}
          set { ccontent=value;}
        }
        private string cRemark;

        public string CRemark
        {
          get { return cRemark;}
          set { cRemark=value;}
        }
    }
}
