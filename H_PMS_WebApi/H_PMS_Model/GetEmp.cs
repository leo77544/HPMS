using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_PMS_Model
{
    public class GetEmp
    {
        private int employeeId;
        /// <summary>
        /// 主键，自增列，员工ID
        /// </summary>
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        private string eName;
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string EName
        {
            get { return eName; }
            set { eName = value; }
        }
        private string eSex;
        /// <summary>
        /// 性别
        /// </summary>
        public string ESex
        {
            get { return eSex; }
            set { eSex = value; }
        }
        private int eAge;
        /// <summary>
        /// 年龄
        /// </summary>
        public int EAge
        {
            get { return eAge; }
            set { eAge = value; }
        }
        private Single eSalary;
        /// <summary>
        /// 薪资
        /// </summary>
        public Single ESalary
        {
            get { return eSalary; }
            set { eSalary = value; }
        }
        private DateTime eStartTime;
        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime EStartTime
        {
            get { return eStartTime; }
            set { eStartTime = value; }
        }
        private string dName;
        /// <summary>
        /// 职务名称
        /// </summary>
        public string DName
        {
            get { return dName; }
            set { dName = value; }
        }
    }
}
