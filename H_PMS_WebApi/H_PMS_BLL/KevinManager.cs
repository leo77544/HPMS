using H_PMS_DAL;
using H_PMS_Model;
using System;
using System.Collections.Generic;

namespace H_PMS_BLL
{
    public class KevinManager
    {
        KevinService service = new KevinService();

        #region 员工管理
        /// <summary>
        /// 员工显示，查询
        /// </summary>
        /// <param name="EName"></param>
        /// <param name="DId"></param>
        /// <returns></returns>
        public List<GetEmp> GetEmployees(string EName = "", int DId = -1)
        {
            return service.GetEmployees(EName,DId);
        }
        /// <summary>
        /// 员工添加
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int AddEmp(Employee employee)
        {
            return service.AddEmp(employee);
        }
        /// <summary>
        /// 根据ID获取Emp对象
        /// </summary>
        /// <param name="EId"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeByEId(int EId)
        {
            return service.GetEmployeeByEId(EId);
        }
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int PutEmpByEId(Employee employee)
        {
            return service.PutEmpByEId(employee);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int DelEmpByEId(int EmployeeId)
        {
            return service.DelEmpByEId(EmployeeId);
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
            return service.AddRepair(repair);
        }
        /// <summary>
        /// 报修明细
        /// </summary>
        /// <returns></returns>
        public List<Repair> GetRepairs(int lx)
        {
            return service.GetRepairs(lx);
        }
        /// <summary>
        /// 获取户主信息
        /// </summary>
        /// <param name="PlotName"></param>
        /// <param name="BulidName"></param>
        /// <param name="HouseNumber"></param>
        /// <returns></returns>
        public string GetHouseInfoByHouse(string PlotName, string BulidName, string HouseNumber)
        {
            return service.GetHouseInfoByHouse(PlotName, BulidName, HouseNumber);
        }
        /// <summary>
        /// 更改报修单据
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        public int PutRepair(Repair repair)
        {
            return service.PutRepair(repair);
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
            return service.AddVisitor(visitor);
        }
        /// <summary>
        /// 根据ID获取访客信息
        /// </summary>
        /// <param name="VId"></param>
        /// <returns></returns>
        public string GetFangKeById(int VId)
        {
            return service.GetFangKeById(VId);
        }
        /// <summary>
        /// 访客离开登记
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public int PutVisitor(Visitor visitor)
        {
            return service.PutVisitor(visitor);
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
            return service.AddPatrol(patrol);
        }
        #endregion

    }
}

