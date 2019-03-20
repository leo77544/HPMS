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

        public ActionResult PBAddIndex()
        {
            return PartialView();
        }
        public ActionResult PBShow()
        {
            List<ParkBase> list = JsonConvert.DeserializeObject<List<ParkBase>>(ApiResult.GetAPIResult("GetParkBases", "get"));
            ViewBag.list = list;
            return PartialView();
        }
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

        #region Michael

        /// <summary>
        /// 住户登记视图
        /// </summary>
        /// <returns></returns>
        public ActionResult HousePView()
        {
            return PartialView();
        }

        #endregion
    }
}