using ConnHelper;
using H_PMS_Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace H_PMS_DAL
{
    public class KevinService
    {

        #region 员工管理
        /// <summary>
        /// 员工显示，查询
        /// </summary>
        /// <param name="EName"></param>
        /// <param name="DId"></param>
        /// <returns></returns>
        public List<GetEmp> GetEmployees(string EName = "", int DId = -1)
        {
            string sql = $"select e.EmployeeId,e.EName,e.ESex,e.EAge,e.ESalary,e.EStartTime,d.DName from Employee e join Duty d on e.DId=d.DutyId where EName like '%{EName}%' and DId!=0 ";
            if (DId != -1)
            {
                sql += " and DId=" + DId;
            }
            sql += " order by e.EmployeeId desc";
            List<GetEmp> list = JsonConvert.DeserializeObject<List<GetEmp>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(sql)));
            return list;
        }
        /// <summary>
        /// 员工添加
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int AddEmp(Employee employee)
        {
            return DBHelper.ExecuteNonQuery($"insert into Employee values('{employee.EName}','{employee.ESex}','{employee.EAge}','{employee.ESalary}','{employee.EStartTime}','{employee.DId}')");
        }
        /// <summary>
        /// 根据ID获取Emp对象
        /// </summary>
        /// <param name="EId"></param>
        /// <returns></returns>
        public Employee GetEmployeeByEId(int EId)
        {
            return JsonConvert.DeserializeObject<List<Employee>>(JsonConvert.SerializeObject(DBHelper.GetDataTable("select * from Employee where EmployeeId=" + EId)))[0];
        }
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int PutEmpByEId(Employee employee)
        {
            return DBHelper.ExecuteNonQuery($"updata Employee set EName='{employee.EName}' and ESex='{employee.ESex}' and EAge='{employee.EAge}' and ESalary='{employee.ESalary}' and EStartTime='{employee.EStartTime}' and DId='{employee.DId}' where EmployeeId={employee.EmployeeId}");
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int DelEmpByEId(int EmployeeId)
        {
            return DBHelper.ExecuteNonQuery("delete from Employee where EmployeeId=" + EmployeeId);
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
            int n = DBHelper.ExecuteNonQuery($"insert into Repair values('{repair.HostName}','{repair.HouseId}','{repair.ReNumber}','{repair.MaintainName}','{repair.RSTime}','{repair.MaintainTime}','{repair.ServePrice}','{repair.GoodsPrice}','{repair.PriceSum}','{repair.Estimate}','{repair.ReRemark}')");
            if (n > 0)
            {
                n += DBHelper.ExecuteNonQuery("update HouseInfo set HouseState='待修' where HouseId=" + repair.HouseId);
            }
            return n;
        }
        /// <summary>
        /// 报修明细
        /// </summary>
        /// <returns></returns>
        public List<Repair> GetRepairs(int lx)
        {
            string sql = "select * from repair where 1=1 ";
            if (lx == 1)
            {
                sql += " and Estimate = '尚未解决'";
            }
            else if (lx == 2)
            {
                sql += " and Estimate = '完美解决'";
            }
            else if (lx == 3)
            {
                sql += " and Estimate = '等待审核'";
            }
            else if (lx == 4)
            {
                sql += " and Estimate = '尚有瑕疵'";
            }
            sql += " order by RepairId desc";
            return JsonConvert.DeserializeObject<List<Repair>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(sql)));
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
            List<HouseInfo> list = JsonConvert.DeserializeObject<List<HouseInfo>>(JsonConvert.SerializeObject(DBHelper.GetDataTable($"select * from HouseInfo where PlotName='{PlotName}' and BulidName='{BulidName}' and HouseNumber='{HouseNumber}' and HouseState!='待修'")));
            if (list.Count == 0)
            {
                return "该房间没有住户";
            }
            else
            {
                HouseInfo house = list[0];
                List<HostInfo> listh = JsonConvert.DeserializeObject<List<HostInfo>>(JsonConvert.SerializeObject(DBHelper.GetDataTable($"select * from HostInfo where HouseId='{house.HouseId}'")));
                if (listh.Count == 0)
                {
                    return "该房间没有住户";
                }
                else
                {
                    HostInfo host = listh[0];
                    string jg = house.HouseId + "-" + host.HostName + "-" + house.HouseState;
                    return jg;
                }
            }
        }
        /// <summary>
        /// 更改报修单据
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        public int PutRepair(Repair repair)
        {
            string getHouseState = repair.ReRemark.Substring(2);
            int n = DBHelper.ExecuteNonQuery($"updata Repair set HostName='{repair.HostName}' and HouseId='{repair.HouseId}' and  MaintainName='{repair.MaintainName}' and RSTime='{repair.RSTime}' and MaintainTime='{repair.MaintainTime}' and ServePrice='{repair.ServePrice}' and GoodsPrice='{repair.GoodsPrice}' and PriceSum='{repair.PriceSum}' and Estimate='{repair.Estimate}' and ReRemark='{repair.ReRemark}' where RepairId={repair.RepairId}");
            if (n > 0)
            {
                n += DBHelper.ExecuteNonQuery("update HouseInfo set HouseState='" + getHouseState + "' where HouseId=" + repair.HouseId);
            }
            if (n >= 2)
            {
                return n;
            }
            else
            {
                return 0;
            }
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
            return DBHelper.ExecuteNonQuery($"insert into Visitor values('{visitor.VisitorName}','{visitor.HostName}','{visitor.StartTime}','{visitor.EndTime}')");
        }
        /// <summary>
        /// 访客离开登记
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public int PutVisitor(Visitor visitor)
        {
            return DBHelper.ExecuteNonQuery($"update Visitor set EndTime='{visitor.EndTime}' where Visitorid={visitor.Visitorid}");
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
            return DBHelper.ExecuteNonQuery($"insert into Patrol values('{patrol.EmployeeId}','{patrol.PatrolRport}','{patrol.PatrolArea}','{patrol.StartTime}','{patrol.EndTime}')");
        }
        #endregion

    }
}

