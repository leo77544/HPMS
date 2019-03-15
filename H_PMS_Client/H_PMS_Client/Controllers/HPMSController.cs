using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiHelper;
using H_PMS_Model;
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
    }
}