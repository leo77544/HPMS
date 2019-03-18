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
        public int Login(string name ,string pwd)
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