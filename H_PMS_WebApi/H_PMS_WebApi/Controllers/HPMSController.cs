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
        [HttpGet]
        public Employee Login(string emp, string pwd)
        {
            return Alan.Login(emp, pwd);
        }

        #endregion

        #region 车位管理

        [HttpGet]
        public ParkBase GetPBMax()
        {
            return Alan.GetPBMax();
        }

        [HttpPost]
        public int AddParkBase(ParkBase p)
        {
            return Alan.AddParkBase(p);
        }
        [HttpGet]
        public List<ParkBase> GetParkBases()
        {
            // 类型 面积  价钱
            return Alan.GetParkBases();
        }
        [HttpDelete]
        public int DelParkBase(int id)
        {
            return Alan.DelParkBase(id);
        }
        [HttpPut]
        public int UptParkBase(ParkBase p)
        {
            return Alan.UptParkBase(p);
        }
        #endregion

        #region 车位租出信息
        [HttpPost]
        public int AddPark(Park p)
        {
            return Alan.AddPark(p);
        }
        [HttpGet]
        public List<Park> GetParks()
        {
            // 车位类型 车主  车位编号
            return Alan.GetParks();
        }
        [HttpDelete]
        public int DelPark(int id)
        {
            return Alan.DelPark(id);
        }
        [HttpPut]
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
        [HttpGet]
        public List<GetEmp> GetEmployees(string EName = "", int DId = -1)
        {
            return Kevin.GetEmployees(EName, DId);
        }
        /// <summary>
        /// 员工添加
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddEmp(Employee employee)
        {
            return Kevin.AddEmp(employee);
        }
        /// <summary>
        /// 根据ID获取Emp对象
        /// </summary>
        /// <param name="EId"></param>
        /// <returns></returns>
        [HttpGet]
        public Employee GetEmployeeByEId(int EId)
        {
            return Kevin.GetEmployeeByEId(EId);
        }
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut]
        public int PutEmpByEId(Employee employee)
        {
            return Kevin.PutEmpByEId(employee);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        [HttpDelete]
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
        [HttpPost]
        public int AddRepair(Repair repair)
        {
            return Kevin.AddRepair(repair);
        }
        /// <summary>
        /// 更改报修单据
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        [HttpPut]
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
        [HttpPost]
        public int AddVisitor(Visitor visitor)
        {
            return Kevin.AddVisitor(visitor);
        }
        /// <summary>
        /// 访客离开登记
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        [HttpPut]
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
        [HttpPost]
        public int AddPatrol(Patrol patrol)
        {
            return Kevin.AddPatrol(patrol);
        }

        #endregion

        #endregion

        #region Michael

        #region 房屋信息
        /// <summary>
        /// 根据条件查询房屋信息
        /// </summary>
        /// <param name="PlotName">区域名称</param>
        /// <param name="BulidName">单元号</param>
        /// <param name="HouseType">户型</param>
        /// <param name="HouseArea">占地面积</param>
        /// <param name="HouseState">状态-空闲 入住 招租 待修</param>
        /// <returns></returns>
        [HttpGet]
        public List<HouseInfo> GetHouseInfosByConditions(string PlotName = "", string BulidName = "", string HouseType = "", string HouseArea = "", string HouseState = "")
        {
            return Michael.GetHouseInfosByConditions(PlotName, BulidName, HouseType, HouseArea, HouseState);
        }

        /// <summary>
        /// 修改房屋状态
        /// </summary>
        /// <param name="HouseId">房屋Id</param>
        /// <param name="HouseState">房屋状态</param>
        /// <returns></returns>
        [HttpPut]
        public int ChangeHouseState(int HouseId, string HouseState)
        {
            return Michael.ChangeHouseState(HouseId, HouseState);
        }

        /// <summary>
        /// 住户登记 房主、家庭成员、房客、访客
        /// </summary>
        /// <param name="TheHost"></param>
        /// <returns></returns>
        [HttpPost]
        public int HostRegister(string HostName, string HostPhone, string IDCard, string Role, int HouseId)
        {
            return Michael.HostRegister(HostName, HostPhone, IDCard, Role, HouseId);
        }

        /// <summary>
        /// 住户查询
        /// </summary>
        /// <param name="HouseId">房屋Id</param>
        /// <param name="HostName">住户姓名</param>
        /// <returns></returns>
        [HttpGet]
        public List<HostInfo> GetHostInfosByConditions(int HouseId = 0, string HostName = "")
        {
            return Michael.GetHostInfosByConditions(HouseId, HostName);
        }
        #endregion

        #region 投诉建议
        /// <summary>
        /// 根据条件查询投诉信息
        /// </summary>
        /// <param name="CBName">投诉住户名</param>
        /// <param name="CRemark">投诉状态-受理待处理 处理待反馈 需再处理 归档</param>
        /// <returns></returns>
        [HttpGet]
        public List<Complain> GetComplainsByConditions(string CBName = "", string CRemark = "")
        {
            return Michael.GetComplainsByConditions(CBName, CRemark);
        }

        /// <summary>
        /// 添加投诉信息
        /// </summary>
        /// <param name="TheComplain"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddComplain(Complain TheComplain)
        {
            return Michael.AddComplain(TheComplain);
        }

        /// <summary> 
        /// 投诉跟进
        /// </summary>
        /// <param name="CSId">投诉记录Id</param>
        /// <param name="Ccontent">投诉详情</param>
        /// <param name="CRemark">投诉状态</param>
        /// <returns></returns>
        [HttpPut]
        public int FollowComplain(int CSId, string Ccontent, string CRemark)
        {
            return Michael.FollowComplain(CSId, Ccontent, CRemark);
        }
        #endregion

        #endregion

    }
}
