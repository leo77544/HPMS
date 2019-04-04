using System;
using System.Collections.Generic;
using System.Data;
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
        public List<Park> GetParkBases()
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
        [HttpDelete]
        public int DelIdCard(string idcard)
        {
            return Alan.DelIdCard(idcard);
        }
        [HttpPut]
        public int UptRemark(Park p)
        {
            return Alan.UptRemark(p);
        }
        [HttpGet]
        public ParkBase GetPlace(string place)
        {
            return Alan.GetPlace(place);
        }
        [HttpGet]
        public ParkBase GetNumber(string number)
        {
            return Alan.GetNumber(number);
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
        [HttpGet]
        public List<HostInfo> ChaHost(string name, string idcard)
        {
            return Alan.ChaHost(name, idcard);
        }
        [HttpPut]
        public int UptPBState(ParkBase p)
        {
            return Alan.UptPBState(p);
        }
       
        #endregion

        #endregion

        #region leo

            #region 添加收费信息
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
            #endregion

            #region 查看缴费信息
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
            #endregion

            #region 分页查看缴费信息
            /// <summary>
            /// 分页查看缴费信息
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public PageList SelectDataMoney(int page, int size)
            {
                List<DataMoney> list = LeoManager.GetDataMoney();

                PageList pageList = new PageList();

                pageList.TotalCount = list.Count;

                pageList.TotalPage = list.Count % size > 0 ? list.Count / size + 1 : list.Count / size;

                pageList.list = list.Skip((page - 1) * size).Take(size).ToList().OrderByDescending(m => m.DMId).ToList();
                return pageList;
            } 
            #endregion

            #region 查看报表信息
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

            #region 分页查看报表信息
            /// <summary>
            /// 分页查看报表信息
            /// </summary>
            /// <returns></returns>
            [HttpGet]
            public PageList SelectRecord(int page, int size)
            {
                List<RecordInfo> list = LeoManager.GetRecordInfo();

                PageList pageList = new PageList();

                pageList.TotalCount = list.Count;

                pageList.TotalPage = list.Count % size > 0 ? list.Count / size + 1 : list.Count / size;

                pageList.relist = list.Skip((page - 1) * size).Take(size).ToList().OrderByDescending(m => m.RIId).ToList();
                return pageList;
            } 
            #endregion

            #region 查询当日
            /// <summary>
            /// 查询当日
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            /// 
            [HttpGet]
            public DataTable GetDayCount(string str)
            {
                return LeoManager.GetDayCount(str);
            } 
            #endregion

            #region 查询当月
            /// <summary>
            /// 查询当月
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            /// 
            [HttpGet]

            public DataTable GetMonthCount(string str)
            {
                return LeoManager.GetMonthCount(str);

            } 
            #endregion

            #region 查询当年
            /// <summary>
            /// 查询当年
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            /// 
            [HttpGet]

            public DataTable GetYearCount(string str)
            {
                return LeoManager.GetYearCount(str);

            } 
            #endregion

            #region 查询年明细
            /// <summary>
            /// 查询年明细
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            /// 
            [HttpGet]

            public DataTable GetYeardetail(string str)
            {
                return LeoManager.GetYeardetail(str);
            }
            #endregion

            #region 查询月明细
            /// <summary>
            /// 查询月明细
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            /// 
            [HttpGet]
            public DataTable GetMonthdetail(string str)
            {
                return LeoManager.GetMonthdetail(str);

            }

            /// <summary>
            /// 查询年份明细
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            /// 
            [HttpGet]
             public DataTable GetYearsdetail()
            {
                return LeoManager.GetYearsdetail();
            }
        #endregion


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
        public List<Employee> GetEmployeeByEId(int EId)
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
        /// 报修明细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Repair> GetRepairs(int lx)
        {
            return Kevin.GetRepairs(lx);
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
            return Kevin.GetHouseInfoByHouse(PlotName, BulidName, HouseNumber);
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
        /// 根据ID获取访客信息
        /// </summary>
        /// <param name="VId"></param>
        /// <returns></returns>
        public string GetFangKeById(int VId)
        {
            return Kevin.GetFangKeById(VId);
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
        public List<HostInfo> GetHostInfosByConditions(int HouseId = 0, string HostName = "", string HostRole = "")
        {
            return Michael.GetHostInfosByConditions(HouseId, HostName, HostRole);
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
        public List<Complain> GetComplainsByConditions(string PlotName = "", string BulidName = "", string HouseNumber = "", string HostName = "", string CRemark = "")
        {
            return Michael.GetComplainsByConditions(PlotName, BulidName, HouseNumber, HostName, CRemark);
        }

        /// <summary>
        /// 根据房屋信息获取住户
        /// </summary>
        /// <param name="PlotName">区域</param>
        /// <param name="BulidName">单元</param>
        /// <param name="HouseNumber">房屋</param>
        /// <returns></returns>
        public List<HostInfo> GetHostInfosByHouseInfo(string PlotName, string BulidName, string HouseNumber)
        {
            return Michael.GetHostInfosByHouseInfo(PlotName, BulidName, HouseNumber);
        }

        /// <summary>
        /// 添加投诉信息
        /// </summary>
        /// <param name="TheComplain"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddComplain(string CBName, string ReceptionEmp, string Ccontent)
        {
            return Michael.AddComplain(CBName, ReceptionEmp, Ccontent);
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
