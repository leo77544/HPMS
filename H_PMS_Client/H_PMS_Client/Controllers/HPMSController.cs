using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiHelper;
using H_PMS_Model;
using Newtonsoft.Json;

namespace H_PMS_Client.Controllers
{
    public class HPMSController : Controller
    {
        // GET: HPMS
        public ActionResult Index()
        {
            //   ApiResult.GetAPIResult();
            return View();
        }

        #region Kevin

        #region 员工操作

        /// <summary>
        /// 员工显示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult K_GetEmp()
        {
            string json = ApiResult.GetAPIResult("GetEmployees", "get");
            List<GetEmp> list = JsonConvert.DeserializeObject<List<GetEmp>>(json);
            ViewBag.getEmp = list;
            return PartialView();
        }
        /// <summary>
        /// 员工入职页面
        /// </summary>
        /// <returns></returns>
        public ActionResult K_AddEmp()
        {
            return PartialView();
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int K_CreateEmp(string emp)
        {
            Employee employee = JsonConvert.DeserializeObject<Employee>(emp);
            string json = ApiResult.GetAPIResult("AddEmp", "post", employee);
            if (json != "")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 修改员工页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void K_PutEmpById(int id)
        {
            Employee employee = JsonConvert.DeserializeObject<Employee>(ApiResult.GetAPIResult("GetEmployeeByEId/?EId=" + id, "get"));
            ViewBag.PutEmpById = employee;
        }
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int K_PutEmp(string emp)
        {
            Employee employee = JsonConvert.DeserializeObject<Employee>(emp);
            string json = ApiResult.GetAPIResult("PutEmpByEId", "put", employee);
            if (json != "")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 根据ID删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int K_DelEmp(int id)
        {
            string json = ApiResult.GetAPIResult("DelEmpByEId/EmployeeId=" + id, "delete");
            if (json != "")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        #endregion

        #endregion



        /// <summary>
        /// 缴费管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Charge()
        {
            return PartialView("_Charge");
        }
        /// <summary>
        /// 缴费记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ChargeRecord()
        {

            //GetDataMoney();
            List<DataMoney> list = JsonConvert.DeserializeObject<List<DataMoney>>(ApiResult.GetAPIResult("GetDataMoney", "get"));
            return PartialView("_ChargeRecord", list);
        }

        #region Alan

        #region 新增

        public ActionResult PBAddIndex()
        {
            return PartialView();
        }
        [HttpPost]
        public int PBAddIndex(string stingP)
        {
            int n = 0;

            ParkBase p = JsonConvert.DeserializeObject<ParkBase>(stingP);

            string json = WebApiHelper.ApiResult.GetAPIResult("GetPBMax", "get");
            ParkBase emp = JsonConvert.DeserializeObject<ParkBase>(json);

            if (emp.PBNumber == null)
            {
                n = -1;
            }
            else
            {
                int number = int.Parse(emp.PBNumber.Substring(1, 5));
                if (p.PBType == "地下停车场")
                {
                    p.PBNumber = "D" + number;
                }
                else
                {
                    p.PBNumber = "H" + number;
                }
                p.Remark = "空闲";
                n = int.Parse(ApiResult.GetAPIResult("AddParkBase", "post", p));

            }
            return n;
        }


        #endregion

        List<ParkBase> ParkBaselist = new List<ParkBase>();
        public ActionResult PBShow(string type = "请选择类型", string area = "请选择区域", string state = "请选择状态")
        {
            ParkBaselist = JsonConvert.DeserializeObject<List<ParkBase>>(ApiResult.GetAPIResult("GetParkBaseByAll?type=" + type + "&area=" + area + "&state=" + state, "get"));
            ViewBag.list = ParkBaselist;
            return PartialView();
        }
        public string GetParkBase(string type, string area, string state)
        {
            List<ParkBase> list = new List<ParkBase>();
            if (type == "请选择类型" && area == "请选择区域" && state == "请选择状态")
            {
                 list = ParkBaselist;
            }
            else
            {
                list = ParkBaselist.Where(m => m.PBType == type && m.PBPlace.Contains(area) && m.Remark == state).ToList();
            }
            return JsonConvert.SerializeObject(list);

        }
        #region 删除

        public int DelParkBase(int Id)
        {
            int n = int.Parse(ApiResult.GetAPIResult("AddParkBase?id=" + Id, "delete"));
            return n;
        }

        #endregion

        #region 登录

        public ActionResult Login()
        {
            if (Session["TheU"] is null)
            {
                return View();
            }
            else
            {
                Session["TheU"] = null;
                return View();
            }
        }
        public int LoginUser(string name, string pwd)
        {
            string json = WebApiHelper.ApiResult.GetAPIResult("Login?emp=" + name + "&pwd=" + pwd, "get");
            Employee emp = JsonConvert.DeserializeObject<Employee>(json);

            if (emp != null)
            {
                Session["TheU"] = emp;
                return 1;
            }
            else
            {
                return -1;
            }
        }

        #endregion
        public ActionResult ParkShow()
        {
            return PartialView();
        }
        #endregion

        #region Michael

        /// <summary>
        /// 住户登记视图
        /// </summary>
        /// <returns></returns>
        public ActionResult HousePView()
        {
            return PartialView();
        }

        /// <summary>
        /// 根据条件查询房屋信息
        /// </summary>
        /// <param name="PlotName">区域名称</param>
        /// <param name="BulidName">单元号</param>
        /// <param name="HouseType">户型</param>
        /// <param name="HouseArea">占地面积</param>
        /// <param name="HouseState">状态-空闲 入住 招租 待修</param>
        /// <returns></returns>
        //public List<HouseInfo> GetHouseInfosByConditions(string PlotName, string BulidName, string HouseType, string HouseArea, string HouseState)
        public string GetHouseInfosByConditions(string PlotName, string BulidName, string HouseType, string HouseArea, string HouseState)
        {
            //return JsonConvert.DeserializeObject<List<HouseInfo>>(ApiResult.GetAPIResult("GetHouseInfosByConditions?PlotName=" + PlotName + "&BulidName=" + BulidName + "&HouseType=" + HouseType + "&HouseArea=" + HouseArea + "&HouseState=" + HouseState + "", "get"));
            return ApiResult.GetAPIResult("GetHouseInfosByConditions?PlotName=" + PlotName + "&BulidName=" + BulidName + "&HouseType=" + HouseType + "&HouseArea=" + HouseArea + "&HouseState=" + HouseState + "", "get");
        }

        #endregion
    }
}