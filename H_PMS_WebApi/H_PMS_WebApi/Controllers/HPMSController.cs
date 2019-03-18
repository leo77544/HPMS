using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using H_PMS_BLL;
using H_PMS_Model;

namespace H_PMS_WebApi.Controllers
{
    public class HPMSController : ApiController
    {
        AlanManager Alan = new AlanManager();
        LeoManager leo = new LeoManager();
        KevinManager Kevin = new KevinManager();
        MichaelManager Michael = new MichaelManager();
        
        #region Alan

        #region 登录
        public Employee Login(string emp, string pwd)
        {
            return Alan.Login(emp, pwd);
        }

        #endregion

        #region 车位管理

        public int AddParkBase(ParkBase p)
        {
            return Alan.AddParkBase(p);
        }

        public List<ParkBase> GetParkBases()
        {
            // 类型 面积  价钱
            return Alan.GetParkBases();
        }

        public int DelParkBase(int id)
        {
            return Alan.DelParkBase(id);
        }

        public int UptParkBase(ParkBase p)
        {
            return Alan.UptParkBase(p);
        }
        #endregion

        #region 车位租出信息
        public int AddPark(Park p)
        {
            return Alan.AddPark(p);
        }

        public List<Park> GetParks()
        {
            // 车位类型 车主  车位编号
            return Alan.GetParks();
        }

        public int DelPark(int id)
        {
            return Alan.DelPark(id);
        }

        public int UptPark(Park p)
        {
            return Alan.UptPark(p);
        }

        #endregion

        #endregion

        #region leo
        /// <summary>
        /// 添加收费信息
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
         public int AddDataMoney(DataMoney m)
        {
            return LeoManager.AddDataMoney(m);
        }

        /// <summary>
        /// 查看缴费信息
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
         public List<DataMoney> GetDataMoney()
        {
            return LeoManager.GetDataMoney();
        }
        /// <summary>
        /// 查看报表信息
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
         public List<RecordInfo> GetRecordInfo()
        {
            return LeoManager.GetRecordInfo();
        }
        #endregion

        #region Kevin

        #region 员工管理
        /// <summary>
        /// 员工显示，查询
        /// </summary>
        /// <param name="EName"></param>
        /// <param name="DId"></param>
        /// <returns></returns>
        public List<GetEmp> GetEmployees(string EName = "", int DId = -1)
        {
            return Kevin.GetEmployees(EName, DId);
        }
        /// <summary>
        /// 员工添加
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int AddEmp(Employee employee)
        {
            return Kevin.AddEmp(employee);
        }
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int PutEmpByEId(Employee employee)
        {
            return Kevin.PutEmpByEId(employee);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int DelEmpByEId(int EmployeeId)
        {
            return Kevin.DelEmpByEId(EmployeeId);
        }
        #endregion

        #region 报修管理
        /// <summary>
        /// 添加报修单据
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        public int AddRepair(Repair repair)
        {
            return Kevin.AddRepair(repair);
        }
        /// <summary>
        /// 更改报修单据
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        public int PutRepair(Repair repair)
        {
            return Kevin.PutRepair(repair);
        }
        #endregion

        #region 接待
        /// <summary>
        /// 添加接待客人
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public int AddVisitor(Visitor visitor)
        {
            return Kevin.AddVisitor(visitor);
        }
        /// <summary>
        /// 访客离开登记
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public int PutVisitor(Visitor visitor)
        {
            return Kevin.PutVisitor(visitor);
        }
        #endregion

        #region 值班-打卡

        /// <summary>
        /// 添加值班
        /// </summary>
        /// <param name="patrol"></param>
        /// <returns></returns>
        public int AddPatrol(Patrol patrol)
        {
            return Kevin.AddPatrol(patrol);
        }

        #endregion

        #endregion

        #region Michael

        #endregion

    }
}
