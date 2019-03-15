using System;
using System.Collections.Generic;
using System.Text;

namespace H_PMS_Model
{
    [Serializable]
    public class Employee
    {
        private int employeeId;
        /// <summary>
        /// �����������У�Ա��ID
        /// </summary>
        public int EmployeeId
        {
          get { return employeeId;}
          set { employeeId=value;}
        }
        private string eName;
        /// <summary>
        /// Ա������
        /// </summary>
        public string EName
        {
          get { return eName;}
          set { eName=value;}
        }
        private string eSex;
        /// <summary>
        /// �Ա�
        /// </summary>
        public string ESex
        {
          get { return eSex;}
          set { eSex=value;}
        }
        private int eAge;
        /// <summary>
        /// ����
        /// </summary>
        public int EAge
        {
          get { return eAge;}
          set { eAge=value;}
        }
        private Single eSalary;
        /// <summary>
        /// н��
        /// </summary>
        public Single ESalary
        {
          get { return eSalary;}
          set { eSalary=value;}
        }
        private DateTime eStartTime;
        /// <summary>
        /// ��ְ����
        /// </summary>
        public DateTime EStartTime
        {
          get { return eStartTime;}
          set { eStartTime=value;}
        }
        private int dId;
        /// <summary>
        /// ְ��Id
        /// </summary>
        public int DId
        {
          get { return dId;}
          set { dId=value;}
        }
    }
}
