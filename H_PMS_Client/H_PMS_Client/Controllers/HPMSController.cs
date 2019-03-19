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

        public ActionResult PBAddIndex()
        {
            return PartialView();
        }
        public ActionResult PBShow()
        {
            return PartialView();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public int Login(string name, string pwd)
        {
            string json = WebApiHelper.ApiResult.GetAPIResult("Login/?account=" + name + "&pwd=" + pwd, "get");
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

    }
}