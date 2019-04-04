﻿using System;
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
        //  [HttpPost]

        // GET: HPMS
        public ActionResult Index()
        {
            //   ApiResult.GetAPIResult();
            //GetDayRecord(str);
            //GetMonthRecord(str);
            //GetYearRecord(str);
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
            return PartialView();
        }
        /// <summary>
        /// 根据职务获取员工
        /// </summary>
        /// <param name="DId"></param>
        /// <returns></returns>
        public string GetEmpByDId(string EName, string DId)
        {
            string json = ApiResult.GetAPIResult("GetEmployees/?EName=" + EName + "&DId=" + DId, "get");
            json = JsonConvert.SerializeObject(json);
            return json;
        }
        /// <summary>
        /// 根据ID获取EMP
        /// </summary>
        /// <param name="EId"></param>
        /// <returns></returns>
        public string GetEmployeeByEId(string EId)
        {
            List<Employee> emp = JsonConvert.DeserializeObject<List<Employee>>(ApiResult.GetAPIResult("GetEmployeeByEId/?EId=" + EId, "get"));
            string json = JsonConvert.SerializeObject(emp);
            return json;
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
        public ActionResult K_PutEmpById(string id)
        {
            return PartialView();
        }
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public int K_PutEmp(string emp)
        {
            Employee employee = JsonConvert.DeserializeObject<Employee>(emp);
            Employee empsession = Session["TheU"] as Employee;
            Guid TheToken = JsonConvert.DeserializeObject<Guid>(ApiResult.GetAPIResult("GetToken/?Name=" + empsession.EName + "&Pwd=" + empsession.ESex, "get"));
            string json = ApiResult.GetAPIResult("PutEmpByEId/?TokenGuid=" + TheToken + "&TokenDateTime=" + DateTime.Now.ToString() + "", "put", employee);
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
            string json = ApiResult.GetAPIResult("DelEmpByEId/?EmployeeId=" + id, "delete");
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

        #region 报修
        /// <summary>
        /// 添加报修名单
        /// </summary>
        /// <returns></returns>
        public ActionResult K_AddRepair()
        {
            // GetEmpByRep();
            return PartialView();
        }
        /// <summary>
        /// 技工报告页面
        /// </summary>
        /// <returns></returns>
        public ActionResult K_JiGongBaoGao()
        {
            return PartialView();
        }
        /// <summary>
        /// 归档页面
        /// </summary>
        /// <returns></returns>
        public ActionResult K_WanMeiGuiDang()
        {
            return PartialView();
        }
        /// <summary>
        /// 获取技工的信息
        /// </summary>
        public string GetEmpByRep()
        {
            List<GetEmp> list = JsonConvert.DeserializeObject<List<GetEmp>>(ApiResult.GetAPIResult("GetEmployees/?DId=5", "get"));
            return JsonConvert.SerializeObject(list);
        }
        /// <summary>
        /// 添加报修信息
        /// </summary>
        /// <param name="rep"></param>
        /// <returns></returns>
        public string AddRepByEName(string rep)
        {
            Repair repair = JsonConvert.DeserializeObject<Repair>(rep);
            return ApiResult.GetAPIResult("AddRepair", "post", repair);
        }
        /// <summary>
        /// 获取所有报修明细
        /// </summary>
        /// <returns></returns>
        public ActionResult K_GetRepair()
        {
            return PartialView();
        }
        List<Repair> repList = new List<Repair>();
        /// <summary>
        ///  根据下拉列表查询
        /// </summary>
        /// <param name="lx"></param>
        public string GetRepByLX(int lx)
        {
            repList = JsonConvert.DeserializeObject<List<Repair>>(ApiResult.GetAPIResult("GetRepairs/?lx=" + lx, "get"));
            return JsonConvert.SerializeObject(repList);
        }
        /// <summary>
        /// 获取房屋ID及户主
        /// </summary>
        /// <param name="PlotName"></param>
        /// <param name="BulidName"></param>
        /// <param name="HouseNumber"></param>
        /// <param name="HouseType"></param>
        /// <returns></returns>
        public string GetHouseInfoByHouse(string PlotName, string BulidName, string HouseNumber)
        {
            string json = ApiResult.GetAPIResult("GetHouseInfoByHouse/?PlotName=" + PlotName + "&BulidName=" + BulidName + "&HouseNumber=" + HouseNumber, "get");
            return json;
        }
        /// <summary>
        /// 修改报修明细
        /// </summary>
        /// <param name="rep"></param>
        /// <returns></returns>
        public string PutRepBuREP(string rep)
        {
            Repair repair = JsonConvert.DeserializeObject<Repair>(rep);
            return ApiResult.GetAPIResult("PutRepair", "put", repair);
        }
        #endregion 



        #endregion

        #region leo
        /// <summary>
        /// 缴费管理
        /// </summary>
        /// <returns></returns>
        public ActionResult JiaoFei()
        {
            return PartialView("_JiaoFei");
        }
        /// <summary>
        /// 缴费记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ChargeRecord()
        {
            return PartialView("_ChargeRecord");
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="m"></param>
        public string AddDataMoney(string m)
        {
            DataMoney da = JsonConvert.DeserializeObject<DataMoney>(m);
            return ApiResult.GetAPIResult("AddDataMoney", "post", da);

        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public string DataIndex(int page, int size)
        {
            return ApiResult.GetAPIResult("SelectDataMoney?page=" + page + "&size=" + size, "get");
        }
        /// <summary>
        /// 账单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult BillManage()
        {
            return PartialView("_BillManage");
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public string Recordlist(int page, int size)
        {
            return ApiResult.GetAPIResult("SelectRecord?page=" + page + "&size=" + size, "get");
        }
        /// <summary>
        /// 收支管理
        /// </summary>
        /// <returns></returns>
        public ActionResult InComeManage()
        {
            return PartialView("_InComeManage");
        }

        /// <summary>
        /// 日统计
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetDayRecord(string str)
        {
            return JsonConvert.SerializeObject(ApiResult.GetAPIResult("GetDayCount?str=" + str, "get"));
        }

        /// <summary>
        /// 月统计
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetMonthRecord(string str)
        {
            return JsonConvert.SerializeObject(ApiResult.GetAPIResult("GetMonthCount?str=" + str, "get"));
        }
        /// <summary>
        /// 年统计
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetYearRecord(string str)
        {

            return JsonConvert.SerializeObject(ApiResult.GetAPIResult("GetYearCount?str=" + str, "get"));
        }
        /// <summary>
        /// 查询年明细
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetYeardetail(string str)
        {
            return JsonConvert.SerializeObject(ApiResult.GetAPIResult("GetYeardetail?str=" + str, "get"));
        }
        /// <summary>
        /// 查询月明细
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetMonthdetail(string str)
        {
            return JsonConvert.SerializeObject(ApiResult.GetAPIResult("GetMonthdetail?str=" + str, "get"));
        }

        /// <summary>
        /// 查询年度明细
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetYearsdetail()
        {
            return JsonConvert.SerializeObject(ApiResult.GetAPIResult("GetYearsdetail", "get"));
        }


        #endregion

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
                string s = WebApiHelper.ApiResult.GetAPIResult("GetPlace", "get");
                ParkBase place = JsonConvert.DeserializeObject<ParkBase>(s);
                if (place != null)
                {
                    n = -2;
                }
                else
                {

                    string nbm2 = emp.PBNumber.Substring(1, 4);
                    int number = int.Parse(nbm2) + 1;
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
            }
            return n;
        }


        #endregion

        public ActionResult PBShow()
        {
            List<Park> Parklist = JsonConvert.DeserializeObject<List<Park>>(ApiResult.GetAPIResult("GetParkBases", "get"));
            int day = 0;

            DateTime now = Convert.ToDateTime(DateTime.Now);
            foreach (var item in Parklist)
            {
                

                DateTime start = Convert.ToDateTime(item.InRentSTime);
                start = Convert.ToDateTime(start.Date.ToShortDateString());
                DateTime end = Convert.ToDateTime(item.InRentSTime);
                end = Convert.ToDateTime(end.Date.ToShortDateString());

                if (end < now)
                {
                    int n = int.Parse(ApiResult.GetAPIResult("DelIdCard?idcard=" + item.IDCard, "delete"));
                    Park p = Parklist.FirstOrDefault(m => m.PBNumber == item.PBNumber);
                    int n2 = int.Parse(ApiResult.GetAPIResult("UptRemark", "put", p));
                    Parklist = JsonConvert.DeserializeObject<List<Park>>(ApiResult.GetAPIResult("GetParkBases", "get"));
                }
                else
                {
                    TimeSpan sp = end.Subtract(start);
                    day = sp.Days;

                    if (day > 2 && item.Remark == "代缴费")
                    {
                        int n = int.Parse(ApiResult.GetAPIResult("DelIdCard?idcard=" + item.IDCard, "delete"));
                        Park p = Parklist.FirstOrDefault(m => m.PBNumber == item.PBNumber);
                        int n2 = int.Parse(ApiResult.GetAPIResult("UptRemark", "put", p));
                        if (n2 > 0 && n > 0)
                        {
                            Parklist = JsonConvert.DeserializeObject<List<Park>>(ApiResult.GetAPIResult("GetParkBases", "get"));
                        }
                    }
                }
            }

            ViewBag.list = Parklist;
            return PartialView();
        }
        /// <summary>
        /// 多条件查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="area"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetParkBase(string type, string area, string state)
        {
            List<Park> Parklist = JsonConvert.DeserializeObject<List<Park>>(ApiResult.GetAPIResult("GetParkBases", "get"));
            List<Park> list = new List<Park>();
            if (type != "请选择类型")
            {
                if (area != "请选择区域")
                {
                    if (state != "请选择状态")
                    {
                        list = Parklist.Where(m => m.PBType == type && m.PBPlace.Contains(area) && m.Remark == state).ToList();
                    }
                    else
                    {
                        list = Parklist.Where(m => m.PBType == type && m.PBPlace.Contains(area)).ToList();
                    }
                }
                else
                {
                    if (state != "请选择状态")
                    {
                        list = Parklist.Where(m => m.PBType == type && m.Remark == state).ToList();
                    }
                    else
                    {
                        list = Parklist.Where(m => m.PBType == type).ToList();
                    }
                }
            }
            else
            {
                if (area != "请选择区域")
                {
                    if (state != "请选择状态")
                    {
                        list = Parklist.Where(m => m.PBPlace.Contains(area) && m.Remark == state).ToList();
                    }
                    else
                    {
                        list = Parklist.Where(m => m.PBPlace.Contains(area)).ToList();
                    }
                }
                else
                {
                    if (state != "请选择状态")
                    {
                        list = Parklist.Where(m => m.Remark == state).ToList();
                    }
                    else
                    {
                        list = Parklist;
                    }
                }
            }


            return JsonConvert.SerializeObject(list);
        }

        public int AddPark(string park)
        {
           
            Park p = JsonConvert.DeserializeObject<Park>(park);

            string s = WebApiHelper.ApiResult.GetAPIResult("GetNumber?number="+p.PBNumber, "get");
            ParkBase num = JsonConvert.DeserializeObject<ParkBase>(s);

            p.InRentSTime = DateTime.Now.ToString("yyyy-MM-dd");
            int n = 0;
            p.PBId = num.PBId;
            p.Remark = "代缴费";
            string json = WebApiHelper.ApiResult.GetAPIResult("ChaHost?name=" + p.HostId + "&idcard=" + p.IDCard, "get");

            List<HostInfo> host = JsonConvert.DeserializeObject<List<HostInfo>>(json);
            if (host.Count == 0)
            {
                n = -1;
            }
            else
            {
                n = int.Parse(ApiResult.GetAPIResult("AddPark", "post", p));
                if (n > 0)
                {
                    n = int.Parse(ApiResult.GetAPIResult("UptPBState", "put", p));
                }
                else
                {
                    n = -2;
                }
            }
            return n;

        }

        public string GetPark(string number)
        {
            List<Park> Parklist = JsonConvert.DeserializeObject<List<Park>>(ApiResult.GetAPIResult("GetParkBases", "get"));
            List<Park> pl = Parklist;
            number = number.Trim();
            Park p = Parklist.FirstOrDefault(m => m.PBNumber == number);
            if (p.IDCard != null)
            {
                p.IDCard = p.IDCard.Substring(p.IDCard.Length - 4, 4);
            }
            if (p.InRentSTime != null)
            {
                p.InRentSTime = p.InRentSTime.Substring(0, 10);
            }
            if (p.OutRentSTime != null)
            {
                p.OutRentSTime = p.OutRentSTime.Substring(0, 10);
            }
            return JsonConvert.SerializeObject(p);
        }



        #region 删除

        public int DelParkBase(string Id)
        {
            int n = int.Parse(ApiResult.GetAPIResult("DelParkBase?id=" + Id, "delete"));
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

        #region 房屋管理

        /// <summary>
        /// 住户登记分部视图
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
        public string GetHouseInfosByConditions(string PlotName, string BulidName, string HouseType, string HouseArea, string HouseState)
        {
            return ApiResult.GetAPIResult("GetHouseInfosByConditions?PlotName=" + PlotName + "&BulidName=" + BulidName + "&HouseType=" + HouseType + "&HouseArea=" + HouseArea + "&HouseState=" + HouseState + "", "get");
        }

        /// <summary>
        /// 住户登记
        /// </summary>
        /// <param name="HostName"></param>
        /// <param name="HostPhone"></param>
        /// <param name="IDCard"></param>
        /// <param name="Role"></param>
        /// <param name="HouseId"></param>
        /// <returns></returns>
        public string HostRegister(string HostName, string HostPhone, string IDCard, string Role, string HouseId)
        {
            return ApiResult.GetAPIResult("HostRegister?HostName=" + HostName + "&HostPhone=" + HostPhone + "&IDCard=" + IDCard + "&Role=" + Role + "&HouseId=" + HouseId + "", "post");
        }

        /// <summary>
        /// 住户查询
        /// </summary>
        /// <param name="HouseId"></param>
        /// <param name="HostName"></param>
        /// <param name="HostRole"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public string GetHostInfosByConditions(string HouseId, string HostName, string HostRole, int PageIndex, int PageSize)
        {
            return JsonConvert.SerializeObject(JsonConvert.DeserializeObject<List<HostInfo>>(ApiResult.GetAPIResult("GetHostInfosByConditions?HouseId=" + HouseId + "&HostName=" + HostName + "&HostRole=" + HostRole + "", "get")).Skip(PageSize * (PageIndex - 1)).Take(PageSize).ToList());
        }

        /// <summary>
        /// 修改房屋状态
        /// </summary>
        /// <param name="HouseId"></param>
        /// <param name="HouseState"></param>
        /// <returns></returns>
        public string ChangeHouseState(string HouseId, string HouseState)
        {
            return ApiResult.GetAPIResult("ChangeHouseState?HouseId=" + HouseId + "&HouseState=" + HouseState + "", "put");
        }

        #region 根据身份证号获取基本信息
        public string CKIdCardNum(string IdCardNum)
        {
            List<string> ResultList = new List<string>();
            int[] NumArr = new int[18];
            int i = 0;
            foreach (char item in IdCardNum)
            {
                string TempStr = item.ToString();
                if (TempStr == "x" || TempStr == "X")
                {
                    NumArr[i] = 10;
                }
                else
                {
                    NumArr[i] = int.Parse(TempStr);
                }
                i++;
            }
            int MathResult = (NumArr[0] * 7 + NumArr[1] * 9 + NumArr[2] * 10 + NumArr[3] * 5 + NumArr[4] * 8 + NumArr[5] * 4 + NumArr[6] * 2 + NumArr[7] * 1 + NumArr[8] * 6 + NumArr[9] * 3 + NumArr[10] * 7 + NumArr[11] * 9 + NumArr[12] * 10 + NumArr[13] * 5 + NumArr[14] * 8 + NumArr[15] * 4 + NumArr[16] * 2) % 11;
            string CheckResult = "";
            switch (MathResult)
            {
                case 0: CheckResult = "1"; break;
                case 1: CheckResult = "0"; break;
                case 2: CheckResult = "10"; break;
                case 3: CheckResult = "9"; break;
                case 4: CheckResult = "8"; break;
                case 5: CheckResult = "7"; break;
                case 6: CheckResult = "6"; break;
                case 7: CheckResult = "5"; break;
                case 8: CheckResult = "4"; break;
                case 9: CheckResult = "3"; break;
                case 10: CheckResult = "2"; break;
                default: break;
            }
            if (CheckResult != NumArr[17].ToString())
            {
                return "身份证号码不合法";
            }
            string BirthStr = IdCardNum.Substring(6, 8);
            ResultList.Add("生辰：" + BirthStr.Substring(0, 4) + "年" + BirthStr.Substring(4, 2) + "月" + BirthStr.Substring(6, 2) + "日");
            string SexStr = IdCardNum.Substring(16, 1);
            string SexResult = Convert.ToInt32(SexStr) % 2 == 0 ? "女" : "男";
            ResultList.Add("性别：" + SexResult);
            string AreaStr = IdCardNum.Substring(0, 6);
            string AreaNorm = "前六位,地区;110000,北京市;110100,北京市市辖区;110101,北京市东城区;110102,北京市西城区;110103,北京市崇文区;110104,北京市宣武区;110105,北京市朝阳区;110106,北京市丰台区;110107,北京市石景山区;110108,北京市海淀区;110109,北京市门头沟区;110111,北京市房山区;110112,北京市通州区;110113,北京市顺义区;110200,北京市县;110221,北京市昌平县;110224,北京市大兴县;110226,北京市平谷县;110227,北京市怀柔县;110228,北京市密云县;110229,北京市延庆县;120000,天津市;120100,天津市市辖区;120101,天津市和平区;120102,天津市河东区;120103,天津市河西区;120104,天津市南开区;120105,天津市河北区;120106,天津市红桥区;120107,天津市塘沽区;120108,天津市汉沽区;120109,天津市大港区;120110,天津市东丽区;120111,天津市西青区;120112,天津市津南区;120113,天津市北辰区;120200,天津市县;120221,天津市宁河县;120222,天津市武清县;120223,天津市静海县;120224,天津市宝坻县;120225,天津市蓟县;130000,河北省;130100,河北省石家庄市;130101,河北省石家庄市市辖区;130102,河北省石家庄市长安区;130103,河北省石家庄市桥东区;130104,河北省石家庄市桥西区;130105,河北省石家庄市新华区;130106,河北省石家庄市郊区;130107,河北省石家庄市井陉矿区;130121,河北省石家庄市井陉县;130123,河北省石家庄市正定县;130124,河北省石家庄市栾城县;130125,河北省石家庄市行唐县;130126,河北省石家庄市灵寿县;130127,河北省石家庄市高邑县;130128,河北省石家庄市深泽县;130129,河北省石家庄市赞皇县;130130,河北省石家庄市无极县;130131,河北省石家庄市平山县;130132,河北省石家庄市元氏县;130133,河北省石家庄市赵县;130181,河北省石家庄市辛集市;130182,河北省石家庄市藁城市;130183,河北省石家庄市晋州市;130184,河北省石家庄市新乐市;130185,河北省石家庄市鹿泉市;130200,河北省唐山市;130201,河北省唐山市市辖区;130202,河北省唐山市路南区;130203,河北省唐山市路北区;130204,河北省唐山市古冶区;130205,河北省唐山市开平区;130206,河北省唐山市新区;130221,河北省唐山市丰润县;130223,河北省唐山市滦县;130224,河北省唐山市滦南县;130225,河北省唐山市乐亭县;130227,河北省唐山市迁西县;130229,河北省唐山市玉田县;130230,河北省唐山市唐海县;130281,河北省唐山市遵化市;130282,河北省唐山市丰南市;130283,河北省唐山市迁安市;130300,河北省秦皇岛市秦皇岛市;130301,河北省秦皇岛市市辖区;130302,河北省秦皇岛市海港区;130303,河北省秦皇岛市山海关区;130304,河北省秦皇岛市北戴河区;130321,河北省秦皇岛市青龙满族自治县;130322,河北省秦皇岛市昌黎县;130323,河北省秦皇岛市抚宁县;130324,河北省秦皇岛市卢龙县;130400,河北省邯郸市邯郸市;130401,河北省邯郸市市辖区;130402,河北省邯郸市邯山区;130403,河北省邯郸市丛台区;130404,河北省邯郸市复兴区;130406,河北省邯郸市峰峰矿区;130421,河北省邯郸市邯郸县;130423,河北省邯郸市临漳县;130424,河北省邯郸市成安县;130425,河北省邯郸市大名县;130426,河北省邯郸市涉县;130427,河北省邯郸市磁县;130428,河北省邯郸市肥乡县;130429,河北省邯郸市永年县;130430,河北省邯郸市邱县;130431,河北省邯郸市鸡泽县;130432,河北省邯郸市广平县;130433,河北省邯郸市馆陶县;130434,河北省邯郸市魏县;130435,河北省邯郸市曲周县;130481,河北省邯郸市武安市;130500,河北省邢台市;130501,河北省邢台市市辖区;130502,河北省邢台市桥东区;130503,河北省邢台市桥西区;130521,河北省邢台市邢台县;130522,河北省邢台市临城县;130523,河北省邢台市内丘县;130524,河北省邢台市柏乡县;130525,河北省邢台市隆尧县;130526,河北省邢台市任县;130527,河北省邢台市南和县;130528,河北省邢台市宁晋县;130529,河北省邢台市巨鹿县;130530,河北省邢台市新河县;130531,河北省邢台市广宗县;130532,河北省邢台市平乡县;130533,河北省邢台市威县;130534,河北省邢台市清河县;130535,河北省邢台市临西县;130581,河北省邢台市南宫市;130582,河北省邢台市沙河市;130600,河北省保定市;130601,河北省保定市市辖区;130602,河北省保定市新市区;130603,河北省保定市北市区;130604,河北省保定市南市区;130621,河北省保定市满城县;130622,河北省保定市清苑县;130623,河北省保定市涞水县;130624,河北省保定市阜平县;130625,河北省保定市徐水县;130626,河北省保定市定兴县;130627,河北省保定市唐县;130628,河北省保定市高阳县;130629,河北省保定市容城县;130630,河北省保定市涞源县;130631,河北省保定市望都县;130632,河北省保定市安新县;130633,河北省保定市易县;130634,河北省保定市曲阳县;130635,河北省保定市蠡县;130636,河北省保定市顺平县;130637,河北省保定市博野县;130638,河北省保定市雄县;130681,河北省保定市涿州市;130682,河北省保定市定州市;130683,河北省保定市安国市;130684,河北省保定市高碑店市;130700,河北省张家口市;130701,河北省张家口市市辖区;130702,河北省张家口市桥东区;130703,河北省张家口市桥西区;130705,河北省张家口市宣化区;130706,河北省张家口市下花园区;130721,河北省张家口市宣化县;130722,河北省张家口市张北县;130723,河北省张家口市康保县;130724,河北省张家口市沽源县;130725,河北省张家口市尚义县;130726,河北省张家口市蔚县;130727,河北省张家口市阳原县;130728,河北省张家口市怀安县;130729,河北省张家口市万全县;130730,河北省张家口市怀来县;130731,河北省张家口市涿鹿县;130732,河北省张家口市赤城县;130733,河北省张家口市崇礼县;130800,河北省承德市;130801,河北省承德市市辖区;130802,河北省承德市双桥区;130803,河北省承德市双滦区;130804,河北省承德市鹰手营子矿区;130821,河北省承德市承德县;130822,河北省承德市兴隆县;130823,河北省承德市平泉县;130824,河北省承德市滦平县;130825,河北省承德市隆化县;130826,河北省承德市丰宁满族自治县;130827,河北省承德市宽城满族自治县;130828,河北省承德市围场满族蒙古族自治县;130900,河北省沧州市;130901,河北省沧州市市辖区;130902,河北省沧州市新华区;130903,河北省沧州市运河区;130921,河北省沧州市沧县;130922,河北省沧州市青县;130923,河北省沧州市东光县;130924,河北省沧州市海兴县;130925,河北省沧州市盐山县;130926,河北省沧州市肃宁县;130927,河北省沧州市南皮县;130928,河北省沧州市吴桥县;130929,河北省沧州市献县;130930,河北省沧州市孟村回族自治县;130981,河北省沧州市泊头市;130982,河北省沧州市任丘市;130983,河北省沧州市黄骅市;130984,河北省沧州市河间市;131000,河北省廊坊市;131001,河北省廊坊市市辖区;131002,河北省廊坊市安次区;131022,河北省廊坊市固安县;131023,河北省廊坊市永清县;131024,河北省廊坊市香河县;131025,河北省廊坊市大城县;131026,河北省廊坊市文安县;131028,河北省廊坊市大厂回族自治县;131081,河北省廊坊市霸州市;131082,河北省廊坊市三河市;131100,河北省衡水市;131101,河北省衡水市市辖区;131102,河北省衡水市桃城区;131121,河北省衡水市枣强县;131122,河北省衡水市武邑县;131123,河北省衡水市武强县;131124,河北省衡水市饶阳县;131125,河北省衡水市安平县;131126,河北省衡水市故城县;131127,河北省衡水市景县;131128,河北省衡水市阜城县;131181,河北省衡水市冀州市;131182,河北省衡水市深州市;140000,山西省;140100,山西省太原市;140101,山西省太原市市辖区;140105,山西省太原市小店区;140106,山西省太原市迎泽区;140107,山西省太原市杏花岭区;140108,山西省太原市尖草坪区;140109,山西省太原市万柏林区;140110,山西省太原市晋源区;140121,山西省太原市清徐县;140122,山西省太原市阳曲县;140123,山西省太原市娄烦县;140181,山西省太原市古交市;140200,山西省大同市;140201,山西省大同市市辖区;140202,山西省大同市城区;140203,山西省大同市矿区;140211,山西省大同市南郊区;140212,山西省大同市新荣区;140221,山西省大同市阳高县;140222,山西省大同市天镇县;140223,山西省大同市广灵县;140224,山西省大同市灵丘县;140225,山西省大同市浑源县;140226,山西省大同市左云县;140227,山西省大同市大同县;140300,山西省阳泉市;140301,山西省阳泉市市辖区;140302,山西省阳泉市城区;140303,山西省阳泉市矿区;140311,山西省阳泉市郊区;140321,山西省阳泉市平定县;140322,山西省阳泉市盂县;140400,山西省长治市;140401,山西省长治市市辖区;140402,山西省长治市城区;140411,山西省长治市郊区;140421,山西省长治市长治县;140423,山西省长治市襄垣县;140424,山西省长治市屯留县;140425,山西省长治市平顺县;140426,山西省长治市黎城县;140427,山西省长治市壶关县;140428,山西省长治市长子县;140429,山西省长治市武乡县;140430,山西省长治市沁县;140431,山西省长治市沁源县;140481,山西省长治市潞城市;140500,山西省晋城市;140501,山西省晋城市市辖区;140502,山西省晋城市城区;140521,山西省晋城市沁水县;140522,山西省晋城市阳城县;140524,山西省晋城市陵川县;140525,山西省晋城市泽州县;140581,山西省晋城市高平市;140600,山西省晋城市朔州市;140601,山西省晋城市市辖区;140602,山西省晋城市朔城区;140603,山西省晋城市平鲁区;140621,山西省晋城市山阴县;140622,山西省晋城市应县;140623,山西省晋城市右玉县;140624,山西省晋城市怀仁县;142200,山西省忻州地区;142201,山西省忻州地区忻州市;142202,山西省忻州地区原平市;142222,山西省忻州地区定襄县;142223,山西省忻州地区五台县;142225,山西省忻州地区代县;142226,山西省忻州地区繁峙县;142227,山西省忻州地区宁武县;142228,山西省忻州地区静乐县;142229,山西省忻州地区神池县;142230,山西省忻州地区五寨县;142231,山西省忻州地区岢岚县;142232,山西省忻州地区河曲县;142233,山西省忻州地区保德县;142234,山西省忻州地区偏关县;142300,山西省忻州地区吕梁地区;142301,山西省忻州地区孝义市;142302,山西省忻州地区离石市;142303,山西省忻州地区汾阳市;142322,山西省忻州地区文水县;142323,山西省忻州地区交城县;142325,山西省忻州地区兴县;142326,山西省忻州地区临县;142327,山西省忻州地区柳林县;142328,山西省忻州地区石楼县;142329,山西省忻州地区岚县;142330,山西省忻州地区方山县;142332,山西省忻州地区中阳县;142333,山西省忻州地区交口县;142400,山西省晋中地区;142401,山西省晋中地区榆次市;142402,山西省晋中地区介休市;142421,山西省晋中地区榆社县;142422,山西省晋中地区左权县;142423,山西省晋中地区和顺县;142424,山西省晋中地区昔阳县;142427,山西省晋中地区寿阳县;142429,山西省晋中地区太谷县;142430,山西省晋中地区祁县;142431,山西省晋中地区平遥县;142433,山西省晋中地区灵石县;142600,山西省临汾地区;142601,山西省临汾地区临汾市;142602,山西省临汾地区侯马市;142603,山西省临汾地区霍州市;142621,山西省临汾地区曲沃县;142622,山西省临汾地区翼城县;142623,山西省临汾地区襄汾县;142625,山西省临汾地区洪洞县;142627,山西省临汾地区古县;142628,山西省临汾地区安泽县;142629,山西省临汾地区浮山县;142630,山西省临汾地区吉县;142631,山西省临汾地区乡宁县;142632,山西省临汾地区蒲县;142633,山西省临汾地区大宁县;142634,山西省临汾地区永和县;142635,山西省临汾地区隰县;142636,山西省临汾地区汾西县;142700,山西省运城地区;142701,山西省运城地区运城市;142702,山西省运城地区永济市;142703,山西省运城地区河津市;142723,山西省运城地区芮城县;142724,山西省运城地区临猗县;142725,山西省运城地区万荣县;142726,山西省运城地区新绛县;142727,山西省运城地区稷山县;142729,山西省运城地区闻喜县;142730,山西省运城地区夏县;142731,山西省运城地区绛县;142732,山西省运城地区平陆县;142733,山西省运城地区垣曲县;150000,内蒙古自治区;150100,内蒙古自治区呼和浩特市;150101,内蒙古自治区呼和浩特市市辖区;150102,内蒙古自治区呼和浩特市新城区;150103,内蒙古自治区呼和浩特市回民区;150104,内蒙古自治区呼和浩特市玉泉区;150105,内蒙古自治区呼和浩特市郊区;150121,内蒙古自治区呼和浩特市土默特左旗;150122,内蒙古自治区呼和浩特市托克托县;150123,内蒙古自治区呼和浩特市和林格尔县;150124,内蒙古自治区呼和浩特市清水河县;150125,内蒙古自治区呼和浩特市武川县;150200,内蒙古自治区包头市;150201,内蒙古自治区包头市市辖区;150202,内蒙古自治区包头市东河区;150203,内蒙古自治区包头市昆都伦区;150204,内蒙古自治区包头市青山区;150205,内蒙古自治区包头市石拐矿区;150206,内蒙古自治区包头市白云矿区;150207,内蒙古自治区包头市郊区;150221,内蒙古自治区包头市土默特右旗;150222,内蒙古自治区包头市固阳县;150223,内蒙古自治区包头市达尔罕茂明安联合旗;150300,内蒙古自治区乌海市;150301,内蒙古自治区乌海市市辖区;150302,内蒙古自治区乌海市海勃湾区;150303,内蒙古自治区乌海市海南区;150304,内蒙古自治区乌海市乌达区;150400,内蒙古自治区赤峰市;150401,内蒙古自治区赤峰市市辖区;150402,内蒙古自治区赤峰市红山区;150403,内蒙古自治区赤峰市元宝山区;150404,内蒙古自治区赤峰市松山区;150421,内蒙古自治区赤峰市阿鲁科尔沁旗;150422,内蒙古自治区赤峰市巴林左旗;150423,内蒙古自治区赤峰市巴林右旗;150424,内蒙古自治区赤峰市林西县;150425,内蒙古自治区赤峰市克什克腾旗;150426,内蒙古自治区赤峰市翁牛特旗;150428,内蒙古自治区赤峰市喀喇沁旗;150429,内蒙古自治区赤峰市宁城县;150430,内蒙古自治区赤峰市敖汉旗;152100,内蒙古自治区呼伦贝尔盟;152101,内蒙古自治区呼伦贝尔盟海拉尔市;152102,内蒙古自治区呼伦贝尔盟满洲里市;152103,内蒙古自治区呼伦贝尔盟扎兰屯市;152104,内蒙古自治区呼伦贝尔盟牙克石市;152105,内蒙古自治区呼伦贝尔盟根河市;152106,内蒙古自治区呼伦贝尔盟额尔古纳市;152122,内蒙古自治区呼伦贝尔盟阿荣旗;152123,内蒙古自治区呼伦贝尔盟莫力达瓦达斡尔族自治旗;152127,内蒙古自治区呼伦贝尔盟鄂伦春自治旗;152128,内蒙古自治区呼伦贝尔盟鄂温克族自治旗;152129,内蒙古自治区呼伦贝尔盟新巴尔虎右旗;152130,内蒙古自治区呼伦贝尔盟新巴尔虎左旗;152131,内蒙古自治区呼伦贝尔盟陈巴尔虎旗;152200,内蒙古自治区兴安盟;152201,内蒙古自治区兴安盟乌兰浩特市;152202,内蒙古自治区兴安盟阿尔山市;152221,内蒙古自治区兴安盟科尔沁右翼前旗;152222,内蒙古自治区兴安盟科尔沁右翼中旗;152223,内蒙古自治区兴安盟扎赉特旗;152224,内蒙古自治区兴安盟突泉县;152300,内蒙古自治区哲里木盟;152301,内蒙古自治区哲里木盟通辽市;152302,内蒙古自治区哲里木盟霍林郭勒市;152322,内蒙古自治区哲里木盟科尔沁左翼中旗;152323,内蒙古自治区哲里木盟科尔沁左翼后旗;152324,内蒙古自治区哲里木盟开鲁县;152325,内蒙古自治区哲里木盟库伦旗;152326,内蒙古自治区哲里木盟奈曼旗;152327,内蒙古自治区哲里木盟扎鲁特旗;152500,内蒙古自治区锡林郭勒盟;152501,内蒙古自治区锡林郭勒盟二连浩特市;152502,内蒙古自治区锡林郭勒盟锡林浩特市;152522,内蒙古自治区锡林郭勒盟阿巴嘎旗;152523,内蒙古自治区锡林郭勒盟苏尼特左旗;152524,内蒙古自治区锡林郭勒盟苏尼特右旗;152525,内蒙古自治区锡林郭勒盟东乌珠穆沁旗;152526,内蒙古自治区锡林郭勒盟西乌珠穆沁旗;152527,内蒙古自治区锡林郭勒盟太仆寺旗;152528,内蒙古自治区锡林郭勒盟镶黄旗;152529,内蒙古自治区锡林郭勒盟正镶白旗;152530,内蒙古自治区锡林郭勒盟正蓝旗;152531,内蒙古自治区锡林郭勒盟多伦县;152600,内蒙古自治区乌兰察布盟;152601,内蒙古自治区乌兰察布盟集宁市;152602,内蒙古自治区乌兰察布盟丰镇市;152624,内蒙古自治区乌兰察布盟卓资县;152625,内蒙古自治区乌兰察布盟化德县;152626,内蒙古自治区乌兰察布盟商都县;152627,内蒙古自治区乌兰察布盟兴和县;152629,内蒙古自治区乌兰察布盟凉城县;152630,内蒙古自治区乌兰察布盟察哈尔右翼前旗;152631,内蒙古自治区乌兰察布盟察哈尔右翼中旗;152632,内蒙古自治区乌兰察布盟察哈尔右翼后旗;152634,内蒙古自治区乌兰察布盟四子王旗;152700,内蒙古自治区伊克昭盟;152701,内蒙古自治区伊克昭盟东胜市;152722,内蒙古自治区伊克昭盟达拉特旗;152723,内蒙古自治区伊克昭盟准格尔旗;152724,内蒙古自治区伊克昭盟鄂托克前旗;152725,内蒙古自治区伊克昭盟鄂托克旗;152726,内蒙古自治区伊克昭盟杭锦旗;152727,内蒙古自治区伊克昭盟乌审旗;152728,内蒙古自治区伊克昭盟伊金霍洛旗;152800,内蒙古自治区巴彦淖尔盟;152801,内蒙古自治区巴彦淖尔盟临河市;152822,内蒙古自治区巴彦淖尔盟五原县;152823,内蒙古自治区巴彦淖尔盟磴口县;152824,内蒙古自治区巴彦淖尔盟乌拉特前旗;152825,内蒙古自治区巴彦淖尔盟乌拉特中旗;152826,内蒙古自治区巴彦淖尔盟乌拉特后旗;152827,内蒙古自治区巴彦淖尔盟杭锦后旗;152900,内蒙古自治区阿拉善盟;152921,内蒙古自治区阿拉善盟阿拉善左旗;152922,内蒙古自治区阿拉善盟阿拉善右旗;152923,内蒙古自治区阿拉善盟额济纳旗;210000,辽宁省;210100,辽宁省沈阳市;210101,辽宁省沈阳市市辖区;210102,辽宁省沈阳市和平区;210103,辽宁省沈阳市沈河区;210104,辽宁省沈阳市大东区;210105,辽宁省沈阳市皇姑区;210106,辽宁省沈阳市铁西区;210111,辽宁省沈阳市苏家屯区;210112,辽宁省沈阳市东陵区;210113,辽宁省沈阳市新城子区;210114,辽宁省沈阳市于洪区;210122,辽宁省沈阳市辽中县;210123,辽宁省沈阳市康平县;210124,辽宁省沈阳市法库县;210181,辽宁省沈阳市新民市;210200,辽宁省大连市;210201,辽宁省大连市市辖区;210202,辽宁省大连市中山区;210203,辽宁省大连市西岗区;210204,辽宁省大连市沙河口区;210211,辽宁省大连市甘井子区;210212,辽宁省大连市旅顺口区;210213,辽宁省大连市金州区;210224,辽宁省大连市长海县;210281,辽宁省大连市瓦房店市;210282,辽宁省大连市普兰店市;210283,辽宁省大连市庄河市;210300,辽宁省鞍山市;210301,辽宁省鞍山市市辖区;210302,辽宁省鞍山市铁东区;210303,辽宁省鞍山市铁西区;210304,辽宁省鞍山市立山区;210311,辽宁省鞍山市千山区;210321,辽宁省鞍山市台安县;210323,辽宁省鞍山市岫岩满族自治县;210381,辽宁省鞍山市海城市;210400,辽宁省抚顺市;210401,辽宁省抚顺市市辖区;210402,辽宁省抚顺市新抚区;210403,辽宁省抚顺市露天区;210404,辽宁省抚顺市望花区;210411,辽宁省抚顺市顺城区;210421,辽宁省抚顺市抚顺县;210422,辽宁省抚顺市新宾满族自治县;210423,辽宁省抚顺市清原满族自治县;210500,辽宁省本溪市;210501,辽宁省本溪市市辖区;210502,辽宁省本溪市平山区;210503,辽宁省本溪市溪湖区;210504,辽宁省本溪市明山区;210505,辽宁省本溪市南芬区;210521,辽宁省本溪市本溪满族自治县;210522,辽宁省本溪市桓仁满族自治县;210600,辽宁省丹东市;210601,辽宁省丹东市市辖区;210602,辽宁省丹东市元宝区;210603,辽宁省丹东市振兴区;210604,辽宁省丹东市振安区;210624,辽宁省丹东市宽甸满族自治县;210681,辽宁省丹东市东港市;210682,辽宁省丹东市凤城市;210700,辽宁省锦州市;210701,辽宁省锦州市市辖区;210702,辽宁省锦州市古塔区;210703,辽宁省锦州市凌河区;210711,辽宁省锦州市太和区;210726,辽宁省锦州市黑山县;210727,辽宁省锦州市义县;210781,辽宁省锦州市凌海市;210782,辽宁省锦州市北宁市;210800,辽宁省营口市;210801,辽宁省营口市市辖区;210802,辽宁省营口市站前区;210803,辽宁省营口市西市区;210804,辽宁省营口市鲅鱼圈区;210811,辽宁省营口市老边区;210881,辽宁省营口市盖州市;210882,辽宁省营口市大石桥市;210900,辽宁省阜新市;210901,辽宁省阜新市市辖区;210902,辽宁省阜新市海州区;210903,辽宁省阜新市新邱区;210904,辽宁省阜新市太平区;210905,辽宁省阜新市清河门区;210911,辽宁省阜新市细河区;210921,辽宁省阜新市阜新蒙古族自治县;210922,辽宁省阜新市彰武县;211000,辽宁省辽阳市;211001,辽宁省辽阳市市辖区;211002,辽宁省辽阳市白塔区;211003,辽宁省辽阳市文圣区;211004,辽宁省辽阳市宏伟区;211005,辽宁省辽阳市弓长岭区;211011,辽宁省辽阳市太子河区;211021,辽宁省辽阳市辽阳县;211081,辽宁省辽阳市灯塔市;211100,辽宁省盘锦市;211101,辽宁省盘锦市市辖区;211102,辽宁省盘锦市双台子区;211103,辽宁省盘锦市兴隆台区;211121,辽宁省盘锦市大洼县;211122,辽宁省盘锦市盘山县;211200,辽宁省铁岭市;211201,辽宁省铁岭市市辖区;211202,辽宁省铁岭市银州区;211204,辽宁省铁岭市清河区;211221,辽宁省铁岭市铁岭县;211223,辽宁省铁岭市西丰县;211224,辽宁省铁岭市昌图县;211281,辽宁省铁岭市铁法市;211282,辽宁省铁岭市开原市;211300,辽宁省朝阳市;211301,辽宁省朝阳市市辖区;211302,辽宁省朝阳市双塔区;211303,辽宁省朝阳市龙城区;211321,辽宁省朝阳市朝阳县;211322,辽宁省朝阳市建平县;211324,辽宁省朝阳市喀喇沁左翼蒙古族自治县;211381,辽宁省朝阳市北票市;211382,辽宁省朝阳市凌源市;211400,辽宁省葫芦岛市;211401,辽宁省葫芦岛市市辖区;211402,辽宁省葫芦岛市连山区;211403,辽宁省葫芦岛市龙港区;211404,辽宁省葫芦岛市南票区;211421,辽宁省葫芦岛市绥中县;211422,辽宁省葫芦岛市建昌县;211481,辽宁省葫芦岛市兴城市;220000,吉林省;220100,吉林省长春市;220101,吉林省长春市市辖区;220102,吉林省长春市南关区;220103,吉林省长春市宽城区;220104,吉林省长春市朝阳区;220105,吉林省长春市二道区;220106,吉林省长春市绿园区;220112,吉林省长春市双阳区;220122,吉林省长春市农安县;220181,吉林省长春市九台市;220182,吉林省长春市榆树市;220183,吉林省长春市德惠市;220200,吉林省吉林市;220201,吉林省吉林市市辖区;220202,吉林省吉林市昌邑区;220203,吉林省吉林市龙潭区;220204,吉林省吉林市船营区;220211,吉林省吉林市丰满区;220221,吉林省吉林市永吉县;220281,吉林省吉林市蛟河市;220282,吉林省吉林市桦甸市;220283,吉林省吉林市舒兰市;220284,吉林省吉林市磐石市;220300,吉林省四平市;220301,吉林省四平市市辖区;220302,吉林省四平市铁西区;220303,吉林省四平市铁东区;220322,吉林省四平市梨树县;220323,吉林省四平市伊通满族自治县;220381,吉林省四平市公主岭市;220382,吉林省四平市双辽市;220400,吉林省辽源市;220401,吉林省辽源市市辖区;220402,吉林省辽源市龙山区;220403,吉林省辽源市西安区;220421,吉林省辽源市东丰县;220422,吉林省辽源市东辽县;220500,吉林省通化市;220501,吉林省通化市市辖区;220502,吉林省通化市东昌区;220503,吉林省通化市二道江区;220521,吉林省通化市通化县;220523,吉林省通化市辉南县;220524,吉林省通化市柳河县;220581,吉林省通化市梅河口市;220582,吉林省通化市集安市;220600,吉林省白山市;220601,吉林省白山市市辖区;220602,吉林省白山市八道江区;220621,吉林省白山市抚松县;220622,吉林省白山市靖宇县;220623,吉林省白山市长白朝鲜族自治县;220625,吉林省白山市江源县;220681,吉林省白山市临江市;220700,吉林省松原市;220701,吉林省松原市市辖区;220702,吉林省松原市宁江区;220721,吉林省松原市前郭尔罗斯蒙古族自治县;220722,吉林省松原市长岭县;220723,吉林省松原市乾安县;220724,吉林省松原市扶余县;220800,吉林省白城市;220801,吉林省白城市市辖区;220802,吉林省白城市洮北区;220821,吉林省白城市镇赉县;220822,吉林省白城市通榆县;220881,吉林省白城市洮南市;220882,吉林省白城市大安市;222400,吉林省延边朝鲜族自治州;222401,吉林省延边朝鲜族自治州延吉市;222402,吉林省延边朝鲜族自治州图们市;222403,吉林省延边朝鲜族自治州敦化市;222404,吉林省延边朝鲜族自治州珲春市;222405,吉林省延边朝鲜族自治州龙井市;222406,吉林省延边朝鲜族自治州和龙市;222424,吉林省延边朝鲜族自治州汪清县;222426,吉林省延边朝鲜族自治州安图县;230000,黑龙江省;230100,黑龙江省哈尔滨市;230101,黑龙江省哈尔滨市市辖区;230102,黑龙江省哈尔滨市道里区;230103,黑龙江省哈尔滨市南岗区;230104,黑龙江省哈尔滨市道外区;230105,黑龙江省哈尔滨市太平区;230106,黑龙江省哈尔滨市香坊区;230107,黑龙江省哈尔滨市动力区;230108,黑龙江省哈尔滨市平房区;230121,黑龙江省哈尔滨市呼兰县;230123,黑龙江省哈尔滨市依兰县;230124,黑龙江省哈尔滨市方正县;230125,黑龙江省哈尔滨市宾县;230126,黑龙江省哈尔滨市巴彦县;230127,黑龙江省哈尔滨市木兰县;230128,黑龙江省哈尔滨市通河县;230129,黑龙江省哈尔滨市延寿县;230181,黑龙江省哈尔滨市阿城市;230182,黑龙江省哈尔滨市双城市;230183,黑龙江省哈尔滨市尚志市;230184,黑龙江省哈尔滨市五常市;230200,黑龙江省齐齐哈尔市;230201,黑龙江省齐齐哈尔市市辖区;230202,黑龙江省齐齐哈尔市龙沙区;230203,黑龙江省齐齐哈尔市建华区;230204,黑龙江省齐齐哈尔市铁锋区;230205,黑龙江省齐齐哈尔市昂昂溪区;230206,黑龙江省齐齐哈尔市富拉尔基区;230207,黑龙江省齐齐哈尔市碾子山区;230208,黑龙江省齐齐哈尔市梅里斯达斡尔族区;230221,黑龙江省齐齐哈尔市龙江县;230223,黑龙江省齐齐哈尔市依安县;230224,黑龙江省齐齐哈尔市泰来县;230225,黑龙江省齐齐哈尔市甘南县;230227,黑龙江省齐齐哈尔市富裕县;230229,黑龙江省齐齐哈尔市克山县;230230,黑龙江省齐齐哈尔市克东县;230231,黑龙江省齐齐哈尔市拜泉县;230281,黑龙江省齐齐哈尔市讷河市;230300,黑龙江省鸡西市;230301,黑龙江省鸡西市市辖区;230302,黑龙江省鸡西市鸡冠区;230303,黑龙江省鸡西市恒山区;230304,黑龙江省鸡西市滴道区;230305,黑龙江省鸡西市梨树区;230306,黑龙江省鸡西市城子河区;230307,黑龙江省鸡西市麻山区;230321,黑龙江省鸡西市鸡东县;230381,黑龙江省鸡西市虎林市;230382,黑龙江省鸡西市密山市;230400,黑龙江省鹤岗市;230401,黑龙江省鹤岗市市辖区;230402,黑龙江省鹤岗市向阳区;230403,黑龙江省鹤岗市工农区;230404,黑龙江省鹤岗市南山区;230405,黑龙江省鹤岗市兴安区;230406,黑龙江省鹤岗市东山区;230407,黑龙江省鹤岗市兴山区;230421,黑龙江省鹤岗市萝北县;230422,黑龙江省鹤岗市绥滨县;230500,黑龙江省双鸭山市;230501,黑龙江省双鸭山市市辖区;230502,黑龙江省双鸭山市尖山区;230503,黑龙江省双鸭山市岭东区;230505,黑龙江省双鸭山市四方台区;230506,黑龙江省双鸭山市宝山区;230521,黑龙江省双鸭山市集贤县;230522,黑龙江省双鸭山市友谊县;230523,黑龙江省双鸭山市宝清县;230524,黑龙江省双鸭山市饶河县;230600,黑龙江省大庆市;230601,黑龙江省大庆市市辖区;230602,黑龙江省大庆市萨尔图区;230603,黑龙江省大庆市龙凤区;230604,黑龙江省大庆市让胡路区;230605,黑龙江省大庆市红岗区;230606,黑龙江省大庆市大同区;230621,黑龙江省大庆市肇州县;230622,黑龙江省大庆市肇源县;230623,黑龙江省大庆市林甸县;230624,黑龙江省大庆市杜尔伯特蒙古族自治县;230700,黑龙江省伊春市;230701,黑龙江省伊春市市辖区;230702,黑龙江省伊春市伊春区;230703,黑龙江省伊春市南岔区;230704,黑龙江省伊春市友好区;230705,黑龙江省伊春市西林区;230706,黑龙江省伊春市翠峦区;230707,黑龙江省伊春市新青区;230708,黑龙江省伊春市美溪区;230709,黑龙江省伊春市金山屯区;230710,黑龙江省伊春市五营区;230711,黑龙江省伊春市乌马河区;230712,黑龙江省伊春市汤旺河区;230713,黑龙江省伊春市带岭区;230714,黑龙江省伊春市乌伊岭区;230715,黑龙江省伊春市红星区;230716,黑龙江省伊春市上甘岭区;230722,黑龙江省伊春市嘉荫县;230781,黑龙江省伊春市铁力市;230800,黑龙江省佳木斯市;230801,黑龙江省佳木斯市市辖区;230802,黑龙江省佳木斯市永红区;230803,黑龙江省佳木斯市向阳区;230804,黑龙江省佳木斯市前进区;230805,黑龙江省佳木斯市东风区;230811,黑龙江省佳木斯市郊区;230822,黑龙江省佳木斯市桦南县;230826,黑龙江省佳木斯市桦川县;230828,黑龙江省佳木斯市汤原县;230833,黑龙江省佳木斯市抚远县;230881,黑龙江省佳木斯市同江市;230882,黑龙江省佳木斯市富锦市;230900,黑龙江省七台河市;230901,黑龙江省七台河市市辖区;230902,黑龙江省七台河市新兴区;230903,黑龙江省七台河市桃山区;230904,黑龙江省七台河市茄子河区;230921,黑龙江省七台河市勃利县;231000,黑龙江省牡丹江市;231001,黑龙江省牡丹江市市辖区;231002,黑龙江省牡丹江市东安区;231003,黑龙江省牡丹江市阳明区;231004,黑龙江省牡丹江市爱民区;231005,黑龙江省牡丹江市西安区;231024,黑龙江省牡丹江市东宁县;231025,黑龙江省牡丹江市林口县;231081,黑龙江省牡丹江市绥芬河市;231083,黑龙江省牡丹江市海林市;231084,黑龙江省牡丹江市宁安市;231085,黑龙江省牡丹江市穆棱市;231100,黑龙江省黑河市;231101,黑龙江省黑河市市辖区;231102,黑龙江省黑河市爱辉区;231121,黑龙江省黑河市嫩江县;231123,黑龙江省黑河市逊克县;231124,黑龙江省黑河市孙吴县;231181,黑龙江省黑河市北安市;231182,黑龙江省黑河市五大连池市;232300,黑龙江省绥化地区;232301,黑龙江省绥化地区绥化市;232302,黑龙江省绥化地区安达市;232303,黑龙江省绥化地区肇东市;232304,黑龙江省绥化地区海伦市;232324,黑龙江省绥化地区望奎县;232325,黑龙江省绥化地区兰西县;232326,黑龙江省绥化地区青冈县;232330,黑龙江省绥化地区庆安县;232331,黑龙江省绥化地区明水县;232332,黑龙江省绥化地区绥棱县;232700,黑龙江省大兴安岭地区;232721,黑龙江省大兴安岭地区呼玛县;232722,黑龙江省大兴安岭地区塔河县;232723,黑龙江省大兴安岭地区漠河县;310000,上海市;310100,上海市市辖区;310101,上海市黄浦区;310102,上海市南市区;310103,上海市卢湾区;310104,上海市徐汇区;310105,上海市长宁区;310106,上海市静安区;310107,上海市普陀区;310108,上海市闸北区;310109,上海市虹口区;310110,上海市杨浦区;310112,上海市闵行区;310113,上海市宝山区;310114,上海市嘉定区;310115,上海市浦东新区;310116,上海市金山区;310117,上海市松江区;310200,上海市县;310225,上海市南汇县;310226,上海市奉贤县;310229,上海市青浦县;310230,上海市崇明县;320000,江苏省;320100,江苏省南京市;320101,江苏省南京市市辖区;320102,江苏省南京市玄武区;320103,江苏省南京市白下区;320104,江苏省南京市秦淮区;320105,江苏省南京市建邺区;320106,江苏省南京市鼓楼区;320107,江苏省南京市下关区;320111,江苏省南京市浦口区;320112,江苏省南京市大厂区;320113,江苏省南京市栖霞区;320114,江苏省南京市雨花台区;320121,江苏省南京市江宁县;320122,江苏省南京市江浦县;320123,江苏省南京市六合县;320124,江苏省南京市溧水县;320125,江苏省南京市高淳县;320200,江苏省无锡市;320201,江苏省无锡市市辖区;320202,江苏省无锡市崇安区;320203,江苏省无锡市南长区;320204,江苏省无锡市北塘区;320211,江苏省无锡市郊区;320281,江苏省无锡市江阴市;320282,江苏省无锡市宜兴市;320283,江苏省无锡市锡山市;320300,江苏省徐州市;320301,江苏省徐州市市辖区;320302,江苏省徐州市鼓楼区;320303,江苏省徐州市云龙区;320304,江苏省徐州市九里区;320305,江苏省徐州市贾汪区;320311,江苏省徐州市泉山区;320321,江苏省徐州市丰县;320322,江苏省徐州市沛县;320323,江苏省徐州市铜山县;320324,江苏省徐州市睢宁县;320381,江苏省徐州市新沂市;320382,江苏省徐州市邳州市;320400,江苏省常州市;320401,江苏省常州市市辖区;320402,江苏省常州市天宁区;320404,江苏省常州市钟楼区;320405,江苏省常州市戚墅堰区;320411,江苏省常州市郊区;320481,江苏省常州市溧阳市;320482,江苏省常州市金坛市;320483,江苏省常州市武进市;320500,江苏省苏州市;320501,江苏省苏州市市辖区;320502,江苏省苏州市沧浪区;320503,江苏省苏州市平江区;320504,江苏省苏州市金阊区;320511,江苏省苏州市郊区;320581,江苏省苏州市常熟市;320582,江苏省苏州市张家港市;320583,江苏省苏州市昆山市;320584,江苏省苏州市吴江市;320585,江苏省苏州市太仓市;320586,江苏省苏州市吴县市;320600,江苏省南通市;320601,江苏省南通市市辖区;320602,江苏省南通市崇川区;320611,江苏省南通市港闸区;320621,江苏省南通市海安县;320623,江苏省南通市如东县;320681,江苏省南通市启东市;320682,江苏省南通市如皋市;320683,江苏省南通市通州市;320684,江苏省南通市海门市;320700,江苏省连云港市;320701,江苏省连云港市市辖区;320703,江苏省连云港市连云区;320704,江苏省连云港市云台区;320705,江苏省连云港市新浦区;320706,江苏省连云港市海州区;320721,江苏省连云港市赣榆县;320722,江苏省连云港市东海县;320723,江苏省连云港市灌云县;320724,江苏省连云港市灌南县;320800,江苏省淮阴市;320801,江苏省淮阴市市辖区;320802,江苏省淮阴市清河区;320811,江苏省淮阴市清浦区;320821,江苏省淮阴市淮阴县;320826,江苏省淮阴市涟水县;320829,江苏省淮阴市洪泽县;320830,江苏省淮阴市盱眙县;320831,江苏省淮阴市金湖县;320882,江苏省淮阴市淮安市;320900,江苏省盐城市;320901,江苏省盐城市市辖区;320902,江苏省盐城市城区;320921,江苏省盐城市响水县;320922,江苏省盐城市滨海县;320923,江苏省盐城市阜宁县;320924,江苏省盐城市射阳县;320925,江苏省盐城市建湖县;320928,江苏省盐城市盐都县;320981,江苏省盐城市东台市;320982,江苏省盐城市大丰市;321000,江苏省扬州市;321001,江苏省扬州市市辖区;321002,江苏省扬州市广陵区;321011,江苏省扬州市郊区;321023,江苏省扬州市宝应县;321027,江苏省扬州市邗江县;321081,江苏省扬州市仪征市;321084,江苏省扬州市高邮市;321088,江苏省扬州市江都市;321100,江苏省镇江市;321101,江苏省镇江市市辖区;321102,江苏省镇江市京口区;321111,江苏省镇江市润州区;321121,江苏省镇江市丹徒县;321181,江苏省镇江市丹阳市;321182,江苏省镇江市扬中市;321183,江苏省镇江市句容市;321200,江苏省泰州市;321201,江苏省泰州市市辖区;321202,江苏省泰州市海陵区;321203,江苏省泰州市高港区;321281,江苏省泰州市兴化市;321282,江苏省泰州市靖江市;321283,江苏省泰州市泰兴市;321284,江苏省泰州市姜堰市;321300,江苏省宿迁市;321301,江苏省宿迁市市辖区;321302,江苏省宿迁市宿城区;321321,江苏省宿迁市宿豫县;321322,江苏省宿迁市沭阳县;321323,江苏省宿迁市泗阳县;321324,江苏省宿迁市泗洪县;330000,浙江省;330100,浙江省杭州市;330101,浙江省杭州市市辖区;330102,浙江省杭州市上城区;330103,浙江省杭州市下城区;330104,浙江省杭州市江干区;330105,浙江省杭州市拱墅区;330106,浙江省杭州市西湖区;330108,浙江省杭州市滨江区;330122,浙江省杭州市桐庐县;330127,浙江省杭州市淳安县;330181,浙江省杭州市萧山市;330182,浙江省杭州市建德市;330183,浙江省杭州市富阳市;330184,浙江省杭州市余杭市;330185,浙江省杭州市临安市;330200,浙江省宁波市;330201,浙江省宁波市市辖区;330203,浙江省宁波市海曙区;330204,浙江省宁波市江东区;330205,浙江省宁波市江北区;330206,浙江省宁波市北仑区;330211,浙江省宁波市镇海区;330225,浙江省宁波市象山县;330226,浙江省宁波市宁海县;330227,浙江省宁波市鄞县;330281,浙江省宁波市余姚市;330282,浙江省宁波市慈溪市;330283,浙江省宁波市奉化市;330300,浙江省温州市;330301,浙江省温州市市辖区;330302,浙江省温州市鹿城区;330303,浙江省温州市龙湾区;330304,浙江省温州市瓯海区;330322,浙江省温州市洞头县;330324,浙江省温州市永嘉县;330326,浙江省温州市平阳县;330327,浙江省温州市苍南县;330328,浙江省温州市文成县;330329,浙江省温州市泰顺县;330381,浙江省温州市瑞安市;330382,浙江省温州市乐清市;330400,浙江省嘉兴市;330401,浙江省嘉兴市市辖区;330402,浙江省嘉兴市秀城区;330411,浙江省嘉兴市郊区;330421,浙江省嘉兴市嘉善县;330424,浙江省嘉兴市海盐县;330481,浙江省嘉兴市海宁市;330482,浙江省嘉兴市平湖市;330483,浙江省嘉兴市桐乡市;330500,浙江省湖州市;330501,浙江省湖州市市辖区;330521,浙江省湖州市德清县;330522,浙江省湖州市长兴县;330523,浙江省湖州市安吉县;330600,浙江省绍兴市;330601,浙江省绍兴市市辖区;330602,浙江省绍兴市越城区;330621,浙江省绍兴市绍兴县;330624,浙江省绍兴市新昌县;330681,浙江省绍兴市诸暨市;330682,浙江省绍兴市上虞市;330683,浙江省绍兴市嵊州市;330700,浙江省金华市;330701,浙江省金华市市辖区;330702,浙江省金华市婺城区;330721,浙江省金华市金华县;330723,浙江省金华市武义县;330726,浙江省金华市浦江县;330727,浙江省金华市磐安县;330781,浙江省金华市兰溪市;330782,浙江省金华市义乌市;330783,浙江省金华市东阳市;330784,浙江省金华市永康市;330800,浙江省衢州市;330801,浙江省衢州市市辖区;330802,浙江省衢州市柯城区;330821,浙江省衢州市衢县;330822,浙江省衢州市常山县;330824,浙江省衢州市开化县;330825,浙江省衢州市龙游县;330881,浙江省衢州市江山市;330900,浙江省舟山市;330901,浙江省舟山市市辖区;330902,浙江省舟山市定海区;330903,浙江省舟山市普陀区;330921,浙江省舟山市岱山县;330922,浙江省舟山市嵊泗县;331000,浙江省台州市;331001,浙江省台州市市辖区;331002,浙江省台州市椒江区;331003,浙江省台州市黄岩区;331004,浙江省台州市路桥区;331021,浙江省台州市玉环县;331022,浙江省台州市三门县;331023,浙江省台州市天台县;331024,浙江省台州市仙居县;331081,浙江省台州市温岭市;331082,浙江省台州市临海市;332500,浙江省丽水地区;332501,浙江省丽水地区丽水市;332502,浙江省丽水地区龙泉市;332522,浙江省丽水地区青田县;332523,浙江省丽水地区云和县;332525,浙江省丽水地区庆元县;332526,浙江省丽水地区缙云县;332527,浙江省丽水地区遂昌县;332528,浙江省丽水地区松阳县;332529,浙江省丽水地区景宁畲族自治县;340000,安徽省;340100,安徽省合肥市;340101,安徽省合肥市市辖区;340102,安徽省合肥市东市区;340103,安徽省合肥市中市区;340104,安徽省合肥市西市区;340111,安徽省合肥市郊区;340121,安徽省合肥市长丰县;340122,安徽省合肥市肥东县;340123,安徽省合肥市肥西县;340200,安徽省芜湖市;340201,安徽省芜湖市市辖区;340202,安徽省芜湖市镜湖区;340203,安徽省芜湖市马塘区;340204,安徽省芜湖市新芜区;340207,安徽省芜湖市鸠江区;340221,安徽省芜湖市芜湖县;340222,安徽省芜湖市繁昌县;340223,安徽省芜湖市南陵县;340300,安徽省蚌埠市;340301,安徽省蚌埠市市辖区;340302,安徽省蚌埠市东市区;340303,安徽省蚌埠市中市区;340304,安徽省蚌埠市西市区;340311,安徽省蚌埠市郊区;340321,安徽省蚌埠市怀远县;340322,安徽省蚌埠市五河县;340323,安徽省蚌埠市固镇县;340400,安徽省淮南市;340401,安徽省淮南市市辖区;340402,安徽省淮南市大通区;340403,安徽省淮南市田家庵区;340404,安徽省淮南市谢家集区;340405,安徽省淮南市八公山区;340406,安徽省淮南市潘集区;340421,安徽省淮南市凤台县;340500,安徽省马鞍山市;340501,安徽省马鞍山市市辖区;340502,安徽省马鞍山市金家庄区;340503,安徽省马鞍山市花山区;340504,安徽省马鞍山市雨山区;340505,安徽省马鞍山市向山区;340521,安徽省马鞍山市当涂县;340600,安徽省淮北市;340601,安徽省淮北市市辖区;340602,安徽省淮北市杜集区;340603,安徽省淮北市相山区;340604,安徽省淮北市烈山区;340621,安徽省淮北市濉溪县;340700,安徽省铜陵市;340701,安徽省铜陵市市辖区;340702,安徽省铜陵市铜官山区;340703,安徽省铜陵市狮子山区;340711,安徽省铜陵市郊区;340721,安徽省铜陵市铜陵县;340800,安徽省安庆市;340801,安徽省安庆市市辖区;340802,安徽省安庆市迎江区;340803,安徽省安庆市大观区;340811,安徽省安庆市郊区;340822,安徽省安庆市怀宁县;340823,安徽省安庆市枞阳县;340824,安徽省安庆市潜山县;340825,安徽省安庆市太湖县;340826,安徽省安庆市宿松县;340827,安徽省安庆市望江县;340828,安徽省安庆市岳西县;340881,安徽省安庆市桐城市;341000,安徽省黄山市;341001,安徽省黄山市市辖区;341002,安徽省黄山市屯溪区;341003,安徽省黄山市黄山区;341004,安徽省黄山市徽州区;341021,安徽省黄山市歙县;341022,安徽省黄山市休宁县;341023,安徽省黄山市黟县;341024,安徽省黄山市祁门县;341100,安徽省滁州市;341101,安徽省滁州市市辖区;341102,安徽省滁州市琅琊区;341103,安徽省滁州市南谯区;341122,安徽省滁州市来安县;341124,安徽省滁州市全椒县;341125,安徽省滁州市定远县;341126,安徽省滁州市凤阳县;341181,安徽省滁州市天长市;341182,安徽省滁州市明光市;341200,安徽省阜阳市;341201,安徽省阜阳市市辖区;341202,安徽省阜阳市颍州区;341203,安徽省阜阳市颍东区;341204,安徽省阜阳市颍泉区;341221,安徽省阜阳市临泉县;341222,安徽省阜阳市太和县;341223,安徽省阜阳市涡阳县;341224,安徽省阜阳市蒙城县;341225,安徽省阜阳市阜南县;341226,安徽省阜阳市颍上县;341227,安徽省阜阳市利辛县;341281,安徽省阜阳市亳州市;341282,安徽省阜阳市界首市;341300,安徽省宿州市;341301,安徽省宿州市市辖区;341302,安徽省宿州市甬桥区;341321,安徽省宿州市砀山县;341322,安徽省宿州市萧县;341323,安徽省宿州市灵璧县;341324,安徽省宿州市泗县;342400,安徽省六安地区;342401,安徽省六安地区六安市;342422,安徽省六安地区寿县;342423,安徽省六安地区霍邱县;342425,安徽省六安地区舒城县;342426,安徽省六安地区金寨县;342427,安徽省六安地区霍山县;342500,安徽省宣城地区;342501,安徽省宣城地区宣州市;342502,安徽省宣城地区宁国市;342522,安徽省宣城地区郎溪县;342523,安徽省宣城地区广德县;342529,安徽省宣城地区泾县;342530,安徽省宣城地区旌德县;342531,安徽省宣城地区绩溪县;342600,安徽省巢湖地区;342601,安徽省巢湖地区巢湖市;342622,安徽省巢湖地区庐江县;342623,安徽省巢湖地区无为县;342625,安徽省巢湖地区含山县;342626,安徽省巢湖地区和县;342900,安徽省池州地区;342901,安徽省池州地区贵池市;342921,安徽省池州地区东至县;342922,安徽省池州地区石台县;342923,安徽省池州地区青阳县;350000,福建省;350100,福建省福州市;350101,福建省福州市市辖区;350102,福建省福州市鼓楼区;350103,福建省福州市台江区;350104,福建省福州市仓山区;350105,福建省福州市马尾区;350111,福建省福州市晋安区;350121,福建省福州市闽侯县;350122,福建省福州市连江县;350123,福建省福州市罗源县;350124,福建省福州市闽清县;350125,福建省福州市永泰县;350128,福建省福州市平潭县;350181,福建省福州市福清市;350182,福建省福州市长乐市;350200,福建省厦门市;350201,福建省厦门市市辖区;350202,福建省厦门市鼓浪屿区;350203,福建省厦门市思明区;350204,福建省厦门市开元区;350205,福建省厦门市杏林区;350206,福建省厦门市湖里区;350211,福建省厦门市集美区;350212,福建省厦门市同安区;350300,福建省莆田市;350301,福建省莆田市市辖区;350302,福建省莆田市城厢区;350303,福建省莆田市涵江区;350321,福建省莆田市莆田县;350322,福建省莆田市仙游县;350400,福建省三明市;350401,福建省三明市市辖区;350402,福建省三明市梅列区;350403,福建省三明市三元区;350421,福建省三明市明溪县;350423,福建省三明市清流县;350424,福建省三明市宁化县;350425,福建省三明市大田县;350426,福建省三明市尤溪县;350427,福建省三明市沙县;350428,福建省三明市将乐县;350429,福建省三明市泰宁县;350430,福建省三明市建宁县;350481,福建省三明市永安市;350500,福建省泉州市;350501,福建省泉州市市辖区;350502,福建省泉州市鲤城区;350503,福建省泉州市丰泽区;350504,福建省泉州市洛江区;350521,福建省泉州市惠安县;350524,福建省泉州市安溪县;350525,福建省泉州市永春县;350526,福建省泉州市德化县;350527,福建省泉州市金门县;350581,福建省泉州市石狮市;350582,福建省泉州市晋江市;350583,福建省泉州市南安市;350600,福建省漳州市;350601,福建省漳州市市辖区;350602,福建省漳州市芗城区;350603,福建省漳州市龙文区;350622,福建省漳州市云霄县;350623,福建省漳州市漳浦县;350624,福建省漳州市诏安县;350625,福建省漳州市长泰县;350626,福建省漳州市东山县;350627,福建省漳州市南靖县;350628,福建省漳州市平和县;350629,福建省漳州市华安县;350681,福建省漳州市龙海市;350700,福建省南平市;350701,福建省南平市市辖区;350702,福建省南平市延平区;350721,福建省南平市顺昌县;350722,福建省南平市浦城县;350723,福建省南平市光泽县;350724,福建省南平市松溪县;350725,福建省南平市政和县;350781,福建省南平市邵武市;350782,福建省南平市武夷山市;350783,福建省南平市建瓯市;350784,福建省南平市建阳市;350800,福建省龙岩市;350801,福建省龙岩市市辖区;350802,福建省龙岩市新罗区;350821,福建省龙岩市长汀县;350822,福建省龙岩市永定县;350823,福建省龙岩市上杭县;350824,福建省龙岩市武平县;350825,福建省龙岩市连城县;350881,福建省龙岩市漳平市;352200,福建省宁德地区;352201,福建省宁德地区宁德市;352202,福建省宁德地区福安市;352203,福建省宁德地区福鼎市;352225,福建省宁德地区霞浦县;352227,福建省宁德地区古田县;352228,福建省宁德地区屏南县;352229,福建省宁德地区寿宁县;352230,福建省宁德地区周宁县;352231,福建省宁德地区柘荣县;360000,江西省;360100,江西省南昌市;360101,江西省南昌市市辖区;360102,江西省南昌市东湖区;360103,江西省南昌市西湖区;360104,江西省南昌市青云谱区;360105,江西省南昌市湾里区;360111,江西省南昌市郊区;360121,江西省南昌市南昌县;360122,江西省南昌市新建县;360123,江西省南昌市安义县;360124,江西省南昌市进贤县;360200,江西省景德镇市;360201,江西省景德镇市市辖区;360202,江西省景德镇市昌江区;360203,江西省景德镇市珠山区;360222,江西省景德镇市浮梁县;360281,江西省景德镇市乐平市;360300,江西省萍乡市;360301,江西省萍乡市市辖区;360302,江西省萍乡市安源区;360313,江西省萍乡市湘东区;360321,江西省萍乡市莲花县;360322,江西省萍乡市上栗县;360323,江西省萍乡市芦溪县;360400,江西省九江市;360401,江西省九江市市辖区;360402,江西省九江市庐山区;360403,江西省九江市浔阳区;360421,江西省九江市九江县;360423,江西省九江市武宁县;360424,江西省九江市修水县;360425,江西省九江市永修县;360426,江西省九江市德安县;360427,江西省九江市星子县;360428,江西省九江市都昌县;360429,江西省九江市湖口县;360430,江西省九江市彭泽县;360481,江西省九江市瑞昌市;360500,江西省新余市;360501,江西省新余市市辖区;360502,江西省新余市渝水区;360521,江西省新余市分宜县;360600,江西省鹰潭市;360601,江西省鹰潭市市辖区;360602,江西省鹰潭市月湖区;360622,江西省鹰潭市余江县;360681,江西省鹰潭市贵溪市;360700,江西省赣州市;360701,江西省赣州市市辖区;360702,江西省赣州市章贡区;360721,江西省赣州市赣县;360722,江西省赣州市信丰县;360723,江西省赣州市大余县;360724,江西省赣州市上犹县;360725,江西省赣州市崇义县;360726,江西省赣州市安远县;360727,江西省赣州市龙南县;360728,江西省赣州市定南县;360729,江西省赣州市全南县;360730,江西省赣州市宁都县;360731,江西省赣州市于都县;360732,江西省赣州市兴国县;360733,江西省赣州市会昌县;360734,江西省赣州市寻乌县;360735,江西省赣州市石城县;360781,江西省赣州市瑞金市;360782,江西省赣州市南康市;362200,江西省宜春地区;362201,江西省宜春地区宜春市;362202,江西省宜春地区丰城市;362203,江西省宜春地区樟树市;362204,江西省宜春地区高安市;362226,江西省宜春地区奉新县;362227,江西省宜春地区万载县;362228,江西省宜春地区上高县;362229,江西省宜春地区宜丰县;362232,江西省宜春地区靖安县;362233,江西省宜春地区铜鼓县;362300,江西省上饶地区;362301,江西省上饶地区上饶市;362302,江西省上饶地区德兴市;362321,江西省上饶地区上饶县;362322,江西省上饶地区广丰县;362323,江西省上饶地区玉山县;362324,江西省上饶地区铅山县;362325,江西省上饶地区横峰县;362326,江西省上饶地区弋阳县;362329,江西省上饶地区余干县;362330,江西省上饶地区波阳县;362331,江西省上饶地区万年县;362334,江西省上饶地区婺源县;362400,江西省吉安地区;362401,江西省吉安地区吉安市;362402,江西省吉安地区井冈山市;362421,江西省吉安地区吉安县;362422,江西省吉安地区吉水县;362423,江西省吉安地区峡江县;362424,江西省吉安地区新干县;362425,江西省吉安地区永丰县;362426,江西省吉安地区泰和县;362427,江西省吉安地区遂川县;362428,江西省吉安地区万安县;362429,江西省吉安地区安福县;362430,江西省吉安地区永新县;362432,江西省吉安地区宁冈县;362500,江西省抚州地区;362502,江西省抚州地区临川市;362522,江西省抚州地区南城县;362523,江西省抚州地区黎川县;362524,江西省抚州地区南丰县;362525,江西省抚州地区崇仁县;362526,江西省抚州地区乐安县;362527,江西省抚州地区宜黄县;362528,江西省抚州地区金溪县;362529,江西省抚州地区资溪县;362531,江西省抚州地区东乡县;362532,江西省抚州地区广昌县;370000,山东省;370100,山东省济南市;370101,山东省济南市市辖区;370102,山东省济南市历下区;370103,山东省济南市市中区;370104,山东省济南市槐荫区;370105,山东省济南市天桥区;370112,山东省济南市历城区;370123,山东省济南市长清县;370124,山东省济南市平阴县;370125,山东省济南市济阳县;370126,山东省济南市商河县;370181,山东省济南市章丘市;370200,山东省青岛市;370201,山东省青岛市市辖区;370202,山东省青岛市市南区;370203,山东省青岛市市北区;370205,山东省青岛市四方区;370211,山东省青岛市黄岛区;370212,山东省青岛市崂山区;370213,山东省青岛市李沧区;370214,山东省青岛市城阳区;370281,山东省青岛市胶州市;370282,山东省青岛市即墨市;370283,山东省青岛市平度市;370284,山东省青岛市胶南市;370285,山东省青岛市莱西市;370300,山东省淄博市;370301,山东省淄博市市辖区;370302,山东省淄博市淄川区;370303,山东省淄博市张店区;370304,山东省淄博市博山区;370305,山东省淄博市临淄区;370306,山东省淄博市周村区;370321,山东省淄博市桓台县;370322,山东省淄博市高青县;370323,山东省淄博市沂源县;370400,山东省枣庄市;370401,山东省枣庄市市辖区;370402,山东省枣庄市市中区;370403,山东省枣庄市薛城区;370404,山东省枣庄市峄城区;370405,山东省枣庄市台儿庄区;370406,山东省枣庄市山亭区;370481,山东省枣庄市滕州市;370500,山东省东营市;370501,山东省东营市市辖区;370502,山东省东营市东营区;370503,山东省东营市河口区;370521,山东省东营市垦利县;370522,山东省东营市利津县;370523,山东省东营市广饶县;370600,山东省烟台市;370601,山东省烟台市市辖区;370602,山东省烟台市芝罘区;370611,山东省烟台市福山区;370612,山东省烟台市牟平区;370613,山东省烟台市莱山区;370634,山东省烟台市长岛县;370681,山东省烟台市龙口市;370682,山东省烟台市莱阳市;370683,山东省烟台市莱州市;370684,山东省烟台市蓬莱市;370685,山东省烟台市招远市;370686,山东省烟台市栖霞市;370687,山东省烟台市海阳市;370700,山东省潍坊市;370701,山东省潍坊市市辖区;370702,山东省潍坊市潍城区;370703,山东省潍坊市寒亭区;370704,山东省潍坊市坊子区;370705,山东省潍坊市奎文区;370724,山东省潍坊市临朐县;370725,山东省潍坊市昌乐县;370781,山东省潍坊市青州市;370782,山东省潍坊市诸城市;370783,山东省潍坊市寿光市;370784,山东省潍坊市安丘市;370785,山东省潍坊市高密市;370786,山东省潍坊市昌邑市;370800,山东省济宁市;370801,山东省济宁市市辖区;370802,山东省济宁市市中区;370811,山东省济宁市任城区;370826,山东省济宁市微山县;370827,山东省济宁市鱼台县;370828,山东省济宁市金乡县;370829,山东省济宁市嘉祥县;370830,山东省济宁市汶上县;370831,山东省济宁市泗水县;370832,山东省济宁市梁山县;370881,山东省济宁市曲阜市;370882,山东省济宁市兖州市;370883,山东省济宁市邹城市;370900,山东省泰安市;370901,山东省泰安市市辖区;370902,山东省泰安市泰山区;370911,山东省泰安市郊区;370921,山东省泰安市宁阳县;370923,山东省泰安市东平县;370982,山东省泰安市新泰市;370983,山东省泰安市肥城市;371000,山东省威海市;371001,山东省威海市市辖区;371002,山东省威海市环翠区;371081,山东省威海市文登市;371082,山东省威海市荣成市;371083,山东省威海市乳山市;371100,山东省日照市;371101,山东省日照市市辖区;371102,山东省日照市东港区;371121,山东省日照市五莲县;371122,山东省日照市莒县;371200,山东省莱芜市;371201,山东省莱芜市市辖区;371202,山东省莱芜市莱城区;371203,山东省莱芜市钢城区;371300,山东省临沂市;371301,山东省临沂市市辖区;371302,山东省临沂市兰山区;371311,山东省临沂市罗庄区;371312,山东省临沂市河东区;371321,山东省临沂市沂南县;371322,山东省临沂市郯城县;371323,山东省临沂市沂水县;371324,山东省临沂市苍山县;371325,山东省临沂市费县;371326,山东省临沂市平邑县;371327,山东省临沂市莒南县;371328,山东省临沂市蒙阴县;371329,山东省临沂市临沭县;371400,山东省德州市;371401,山东省德州市市辖区;371402,山东省德州市德城区;371421,山东省德州市陵县;371422,山东省德州市宁津县;371423,山东省德州市庆云县;371424,山东省德州市临邑县;371425,山东省德州市齐河县;371426,山东省德州市平原县;371427,山东省德州市夏津县;371428,山东省德州市武城县;371481,山东省德州市乐陵市;371482,山东省德州市禹城市;371500,山东省聊城市;371501,山东省聊城市市辖区;371502,山东省聊城市东昌府区;371521,山东省聊城市阳谷县;371522,山东省聊城市莘县;371523,山东省聊城市茌平县;371524,山东省聊城市东阿县;371525,山东省聊城市冠县;371526,山东省聊城市高唐县;371581,山东省聊城市临清市;372300,山东省滨州地区;372301,山东省滨州地区滨州市;372321,山东省滨州地区惠民县;372323,山东省滨州地区阳信县;372324,山东省滨州地区无棣县;372325,山东省滨州地区沾化县;372328,山东省滨州地区博兴县;372330,山东省滨州地区邹平县;372900,山东省菏泽地区;372901,山东省菏泽地区菏泽市;372922,山东省菏泽地区曹县;372923,山东省菏泽地区定陶县;372924,山东省菏泽地区成武县;372925,山东省菏泽地区单县;372926,山东省菏泽地区巨野县;372928,山东省菏泽地区郓城县;372929,山东省菏泽地区鄄城县;372930,山东省菏泽地区东明县;410000,河南省;410100,河南省郑州市;410101,河南省郑州市市辖区;410102,河南省郑州市中原区;410103,河南省郑州市二七区;410104,河南省郑州市管城回族区;410105,河南省郑州市金水区;410106,河南省郑州市上街区;410108,河南省郑州市邙山区;410122,河南省郑州市中牟县;410181,河南省郑州市巩义市;410182,河南省郑州市荥阳市;410183,河南省郑州市新密市;410184,河南省郑州市新郑市;410185,河南省郑州市登封市;410200,河南省开封市;410201,河南省开封市市辖区;410202,河南省开封市龙亭区;410203,河南省开封市顺河回族区;410204,河南省开封市鼓楼区;410205,河南省开封市南关区;410211,河南省开封市郊区;410221,河南省开封市杞县;410222,河南省开封市通许县;410223,河南省开封市尉氏县;410224,河南省开封市开封县;410225,河南省开封市兰考县;410300,河南省洛阳市;410301,河南省洛阳市市辖区;410302,河南省洛阳市老城区;410303,河南省洛阳市西工区;410304,河南省洛阳市廛河回族区;410305,河南省洛阳市涧西区;410306,河南省洛阳市吉利区;410311,河南省洛阳市郊区;410322,河南省洛阳市孟津县;410323,河南省洛阳市新安县;410324,河南省洛阳市栾川县;410325,河南省洛阳市嵩县;410326,河南省洛阳市汝阳县;410327,河南省洛阳市宜阳县;410328,河南省洛阳市洛宁县;410329,河南省洛阳市伊川县;410381,河南省洛阳市偃师市;410400,河南省平顶山市;410401,河南省平顶山市市辖区;410402,河南省平顶山市新华区;410403,河南省平顶山市卫东区;410404,河南省平顶山市石龙区;410411,河南省平顶山市湛河区;410421,河南省平顶山市宝丰县;410422,河南省平顶山市叶县;410423,河南省平顶山市鲁山县;410425,河南省平顶山市郏县;410481,河南省平顶山市舞钢市;410482,河南省平顶山市汝州市;410500,河南省安阳市;410501,河南省安阳市市辖区;410502,河南省安阳市文峰区;410503,河南省安阳市北关区;410504,河南省安阳市铁西区;410511,河南省安阳市郊区;410522,河南省安阳市安阳县;410523,河南省安阳市汤阴县;410526,河南省安阳市滑县;410527,河南省安阳市内黄县;410581,河南省安阳市林州市;410600,河南省鹤壁市;410601,河南省鹤壁市市辖区;410602,河南省鹤壁市鹤山区;410603,河南省鹤壁市山城区;410611,河南省鹤壁市郊区;410621,河南省鹤壁市浚县;410622,河南省鹤壁市淇县;410700,河南省新乡市;410701,河南省新乡市市辖区;410702,河南省新乡市红旗区;410703,河南省新乡市新华区;410704,河南省新乡市北站区;410711,河南省新乡市郊区;410721,河南省新乡市新乡县;410724,河南省新乡市获嘉县;410725,河南省新乡市原阳县;410726,河南省新乡市延津县;410727,河南省新乡市封丘县;410728,河南省新乡市长垣县;410781,河南省新乡市卫辉市;410782,河南省新乡市辉县市;410800,河南省焦作市;410801,河南省焦作市市辖区;410802,河南省焦作市解放区;410803,河南省焦作市中站区;410804,河南省焦作市马村区;410811,河南省焦作市山阳区;410821,河南省焦作市修武县;410822,河南省焦作市博爱县;410823,河南省焦作市武陟县;410825,河南省焦作市温县;410881,河南省焦作市济源市;410882,河南省焦作市沁阳市;410883,河南省焦作市孟州市;410900,河南省濮阳市;410901,河南省濮阳市市辖区;410902,河南省濮阳市市区;410922,河南省濮阳市清丰县;410923,河南省濮阳市南乐县;410926,河南省濮阳市范县;410927,河南省濮阳市台前县;410928,河南省濮阳市濮阳县;411000,河南省许昌市;411001,河南省许昌市市辖区;411002,河南省许昌市魏都区;411023,河南省许昌市许昌县;411024,河南省许昌市鄢陵县;411025,河南省许昌市襄城县;411081,河南省许昌市禹州市;411082,河南省许昌市长葛市;411100,河南省漯河市;411101,河南省漯河市市辖区;411102,河南省漯河市源汇区;411121,河南省漯河市舞阳县;411122,河南省漯河市临颍县;411123,河南省漯河市郾城县;411200,河南省三门峡市;411201,河南省三门峡市市辖区;411202,河南省三门峡市湖滨区;411221,河南省三门峡市渑池县;411222,河南省三门峡市陕县;411224,河南省三门峡市卢氏县;411281,河南省三门峡市义马市;411282,河南省三门峡市灵宝市;411300,河南省南阳市;411301,河南省南阳市市辖区;411302,河南省南阳市宛城区;411303,河南省南阳市卧龙区;411321,河南省南阳市南召县;411322,河南省南阳市方城县;411323,河南省南阳市西峡县;411324,河南省南阳市镇平县;411325,河南省南阳市内乡县;411326,河南省南阳市淅川县;411327,河南省南阳市社旗县;411328,河南省南阳市唐河县;411329,河南省南阳市新野县;411330,河南省南阳市桐柏县;411381,河南省南阳市邓州市;411400,河南省商丘市;411401,河南省商丘市市辖区;411402,河南省商丘市梁园区;411403,河南省商丘市睢阳区;411421,河南省商丘市民权县;411422,河南省商丘市睢县;411423,河南省商丘市宁陵县;411424,河南省商丘市柘城县;411425,河南省商丘市虞城县;411426,河南省商丘市夏邑县;411481,河南省商丘市永城市;411500,河南省信阳市;411501,河南省信阳市市辖区;411502,河南省信阳市师河区;411503,河南省信阳市平桥区;411521,河南省信阳市罗山县;411522,河南省信阳市光山县;411523,河南省信阳市新县;411524,河南省信阳市商城县;411525,河南省信阳市固始县;411526,河南省信阳市潢川县;411527,河南省信阳市淮滨县;411528,河南省信阳市息县;412700,河南省周口地区;412701,河南省周口地区周口市;412702,河南省周口地区项城市;412721,河南省周口地区扶沟县;412722,河南省周口地区西华县;412723,河南省周口地区商水县;412724,河南省周口地区太康县;412725,河南省周口地区鹿邑县;412726,河南省周口地区郸城县;412727,河南省周口地区淮阳县;412728,河南省周口地区沈丘县;412800,河南省驻马店地区;412801,河南省驻马店地区驻马店市;412821,河南省驻马店地区确山县;412822,河南省驻马店地区泌阳县;412823,河南省驻马店地区遂平县;412824,河南省驻马店地区西平县;412825,河南省驻马店地区上蔡县;412826,河南省驻马店地区汝南县;412827,河南省驻马店地区平舆县;412828,河南省驻马店地区新蔡县;412829,河南省驻马店地区正阳县;420000,湖北省;420100,湖北省武汉市;420101,湖北省武汉市市辖区;420102,湖北省武汉市江岸区;420103,湖北省武汉市江汉区;420104,湖北省武汉市乔口区;420105,湖北省武汉市汉阳区;420106,湖北省武汉市武昌区;420107,湖北省武汉市青山区;420111,湖北省武汉市洪山区;420112,湖北省武汉市东西湖区;420113,湖北省武汉市汉南区;420114,湖北省武汉市蔡甸区;420115,湖北省武汉市江夏区;420116,湖北省武汉市黄陂区;420117,湖北省武汉市新洲区;420200,湖北省黄石市;420201,湖北省黄石市市辖区;420202,湖北省黄石市黄石港区;420203,湖北省黄石市石灰窑区;420204,湖北省黄石市下陆区;420205,湖北省黄石市铁山区;420222,湖北省黄石市阳新县;420281,湖北省黄石市大冶市;420300,湖北省十堰市;420301,湖北省十堰市市辖区;420302,湖北省十堰市茅箭区;420303,湖北省十堰市张湾区;420321,湖北省十堰市郧县;420322,湖北省十堰市郧西县;420323,湖北省十堰市竹山县;420324,湖北省十堰市竹溪县;420325,湖北省十堰市房县;420381,湖北省十堰市丹江口市;420500,湖北省宜昌市;420501,湖北省宜昌市市辖区;420502,湖北省宜昌市西陵区;420503,湖北省宜昌市伍家岗区;420504,湖北省宜昌市点军区;420505,湖北省宜昌市虎亭区;420521,湖北省宜昌市宜昌县;420525,湖北省宜昌市远安县;420526,湖北省宜昌市兴山县;420527,湖北省宜昌市秭归县;420528,湖北省宜昌市长阳土家族自治县;420529,湖北省宜昌市五峰土家族自治县;420581,湖北省宜昌市宜都市;420582,湖北省宜昌市当阳市;420583,湖北省宜昌市枝江市;420600,湖北省襄樊市;420601,湖北省襄樊市市辖区;420602,湖北省襄樊市襄城区;420606,湖北省襄樊市樊城区;420621,湖北省襄樊市襄阳县;420624,湖北省襄樊市南漳县;420625,湖北省襄樊市谷城县;420626,湖北省襄樊市保康县;420682,湖北省襄樊市老河口市;420683,湖北省襄樊市枣阳市;420684,湖北省襄樊市宜城市;420700,湖北省鄂州市;420701,湖北省鄂州市市辖区;420702,湖北省鄂州市梁子湖区;420703,湖北省鄂州市华容区;420704,湖北省鄂州市鄂城区;420800,湖北省荆门市;420801,湖北省荆门市市辖区;420802,湖北省荆门市东宝区;420821,湖北省荆门市京山县;420822,湖北省荆门市沙洋县;420881,湖北省荆门市钟祥市;420900,湖北省孝感市;420901,湖北省孝感市市辖区;420902,湖北省孝感市孝南区;420921,湖北省孝感市孝昌县;420922,湖北省孝感市大悟县;420923,湖北省孝感市云梦县;420981,湖北省孝感市应城市;420982,湖北省孝感市安陆市;420983,湖北省孝感市广水市;420984,湖北省孝感市汉川市;421000,湖北省荆州市;421001,湖北省荆州市市辖区;421002,湖北省荆州市沙市区;421003,湖北省荆州市荆州区;421022,湖北省荆州市公安县;421023,湖北省荆州市监利县;421024,湖北省荆州市江陵县;421081,湖北省荆州市石首市;421083,湖北省荆州市洪湖市;421087,湖北省荆州市松滋市;421100,湖北省黄冈市;421101,湖北省黄冈市市辖区;421102,湖北省黄冈市黄州区;421121,湖北省黄冈市团风县;421122,湖北省黄冈市红安县;421123,湖北省黄冈市罗田县;421124,湖北省黄冈市英山县;421125,湖北省黄冈市浠水县;421126,湖北省黄冈市蕲春县;421127,湖北省黄冈市黄梅县;421181,湖北省黄冈市麻城市;421182,湖北省黄冈市武穴市;421200,湖北省咸宁市;421201,湖北省咸宁市市辖区;421202,湖北省咸宁市咸安区;421221,湖北省咸宁市嘉鱼县;421222,湖北省咸宁市通城县;421223,湖北省咸宁市崇阳县;421224,湖北省咸宁市通山县;422800,湖北省施土家族苗族自治州;422801,湖北省恩施土家族苗族自治州恩施县;422802,湖北省恩施土家族苗族自治州利川市;422822,湖北省恩施土家族苗族自治州建始县;422823,湖北省恩施土家族苗族自治州巴东县;422825,湖北省恩施土家族苗族自治州宣恩县;422826,湖北省恩施土家族苗族自治州咸丰县;422827,湖北省恩施土家族苗族自治州来凤县;422828,湖北省恩施土家族苗族自治州鹤峰县;429000,湖北省省直辖县级行政单位;429001,湖北省随州市;429004,湖北省仙桃市;429005,湖北省潜江市;429006,湖北省天门市;429021,湖北省神农架林区;430000,湖南省;430100,湖南省长沙市;430101,湖南省长沙市市辖区;430102,湖南省长沙市芙蓉区;430103,湖南省长沙市天心区;430104,湖南省长沙市岳麓区;430105,湖南省长沙市开福区;430111,湖南省长沙市雨花区;430121,湖南省长沙市长沙县;430122,湖南省长沙市望城县;430124,湖南省长沙市宁乡县;430181,湖南省长沙市浏阳市;430200,湖南省株洲市;430201,湖南省株洲市市辖区;430202,湖南省株洲市荷塘区;430203,湖南省株洲市芦淞区;430204,湖南省株洲市石峰区;430211,湖南省株洲市天元区;430221,湖南省株洲市株洲县;430223,湖南省株洲市攸县;430224,湖南省株洲市茶陵县;430225,湖南省株洲市炎陵县;430281,湖南省株洲市醴陵市;430300,湖南省湘潭市;430301,湖南省湘潭市市辖区;430302,湖南省湘潭市雨湖区;430304,湖南省湘潭市岳塘区;430321,湖南省湘潭市湘潭县;430381,湖南省湘潭市湘乡市;430382,湖南省湘潭市韶山市;430400,湖南省衡阳市;430401,湖南省衡阳市市辖区;430402,湖南省衡阳市江东区;430403,湖南省衡阳市城南区;430404,湖南省衡阳市城北区;430411,湖南省衡阳市郊区;430412,湖南省衡阳市南岳区;430421,湖南省衡阳市衡阳县;430422,湖南省衡阳市衡南县;430423,湖南省衡阳市衡山县;430424,湖南省衡阳市衡东县;430426,湖南省衡阳市祁东县;430481,湖南省衡阳市耒阳市;430482,湖南省衡阳市常宁市;430500,湖南省邵阳市;430501,湖南省邵阳市市辖区;430502,湖南省邵阳市双清区;430503,湖南省邵阳市大祥区;430511,湖南省邵阳市北塔区;430521,湖南省邵阳市邵东县;430522,湖南省邵阳市新邵县;430523,湖南省邵阳市邵阳县;430524,湖南省邵阳市隆回县;430525,湖南省邵阳市洞口县;430527,湖南省邵阳市绥宁县;430528,湖南省邵阳市新宁县;430529,湖南省邵阳市城步苗族自治县;430581,湖南省邵阳市武冈市;430600,湖南省岳阳市;430601,湖南省岳阳市市辖区;430602,湖南省岳阳市岳阳楼区;430603,湖南省岳阳市云溪区;430611,湖南省岳阳市君山区;430621,湖南省岳阳市岳阳县;430623,湖南省岳阳市华容县;430624,湖南省岳阳市湘阴县;430626,湖南省岳阳市平江县;430681,湖南省岳阳市汨罗市;430682,湖南省岳阳市临湘市;430700,湖南省常德市;430701,湖南省常德市市辖区;430702,湖南省常德市武陵区;430703,湖南省常德市鼎城区;430721,湖南省常德市安乡县;430722,湖南省常德市汉寿县;430723,湖南省常德市澧县;430724,湖南省常德市临澧县;430725,湖南省常德市桃源县;430726,湖南省常德市石门县;430781,湖南省常德市津市市;430800,湖南省张家界市;430801,湖南省张家界市市辖区;430802,湖南省张家界市永定区;430811,湖南省张家界市武陵源区;430821,湖南省张家界市慈利县;430822,湖南省张家界市桑植县;430900,湖南省益阳市;430901,湖南省益阳市市辖区;430902,湖南省益阳市资阳区;430903,湖南省益阳市赫山区;430921,湖南省益阳市南县;430922,湖南省益阳市桃江县;430923,湖南省益阳市安化县;430981,湖南省益阳市沅江市;431000,湖南省郴州市;431001,湖南省郴州市市辖区;431002,湖南省郴州市北湖区;431003,湖南省郴州市苏仙区;431021,湖南省郴州市桂阳县;431022,湖南省郴州市宜章县;431023,湖南省郴州市永兴县;431024,湖南省郴州市嘉禾县;431025,湖南省郴州市临武县;431026,湖南省郴州市汝城县;431027,湖南省郴州市桂东县;431028,湖南省郴州市安仁县;431081,湖南省郴州市资兴市;431100,湖南省永州市;431101,湖南省永州市市辖区;431102,湖南省永州市芝山区;431103,湖南省永州市冷水滩区;431121,湖南省永州市祁阳县;431122,湖南省永州市东安县;431123,湖南省永州市双牌县;431124,湖南省永州市道县;431125,湖南省永州市江永县;431126,湖南省永州市宁远县;431127,湖南省永州市蓝山县;431128,湖南省永州市新田县;431129,湖南省永州市江华瑶族自治县;431200,湖南省怀化市;431201,湖南省怀化市市辖区;431202,湖南省怀化市鹤城区;431221,湖南省怀化市中方县;431222,湖南省怀化市沅陵县;431223,湖南省怀化市辰溪县;431224,湖南省怀化市溆浦县;431225,湖南省怀化市会同县;431226,湖南省怀化市麻阳苗族自治县;431227,湖南省怀化市新晃侗族自治县;431228,湖南省怀化市芷江侗族自治县;431229,湖南省怀化市靖州苗族侗族自治县;431230,湖南省怀化市通道侗族自治县;431281,湖南省怀化市洪江市;432500,湖南省娄底地区;432501,湖南省娄底地区娄底市;432502,湖南省娄底地区冷水江市;432503,湖南省娄底地区涟源市;432522,湖南省娄底地区双峰县;432524,湖南省娄底地区新化县;433000,湖南省怀化市;433001,湖南省怀化市;433100,湖南省湘西土家族苗族自治州;433101,湖南省湘西土家族苗族自治州吉首市;433122,湖南省湘西土家族苗族自治州泸溪县;433123,湖南省湘西土家族苗族自治州凤凰县;433124,湖南省湘西土家族苗族自治州花垣县;433125,湖南省湘西土家族苗族自治州保靖县;433126,湖南省湘西土家族苗族自治州古丈县;433127,湖南省湘西土家族苗族自治州永顺县;433130,湖南省湘西土家族苗族自治州龙山县;440000,广东省;440100,广东省广州市;440101,广东省广州市市辖区;440102,广东省广州市东山区;440103,广东省广州市荔湾区;440104,广东省广州市越秀区;440105,广东省广州市海珠区;440106,广东省广州市天河区;440107,广东省广州市芳村区;440111,广东省广州市白云区;440112,广东省广州市黄埔区;440181,广东省广州市番禺市;440182,广东省广州市花都市;440183,广东省广州市增城市;440184,广东省广州市从化市;440200,广东省韶关市;440201,广东省韶关市市辖区;440202,广东省韶关市北江区;440203,广东省韶关市武江区;440204,广东省韶关市浈江区;440221,广东省韶关市曲江县;440222,广东省韶关市始兴县;440224,广东省韶关市仁化县;440229,广东省韶关市翁源县;440232,广东省韶关市乳源瑶族自治县;440233,广东省韶关市新丰县;440281,广东省韶关市乐昌市;440282,广东省韶关市南雄市;440300,广东省深圳市;440301,广东省深圳市市辖区;440303,广东省深圳市罗湖区;440304,广东省深圳市福田区;440305,广东省深圳市南山区;440306,广东省深圳市宝安区;440307,广东省深圳市龙岗区;440308,广东省深圳市盐田区;440400,广东省珠海市;440401,广东省珠海市市辖区;440402,广东省珠海市香洲区;440421,广东省珠海市斗门县;440500,广东省汕头市;440501,广东省汕头市市辖区;440506,广东省汕头市达濠区;440507,广东省汕头市龙湖区;440508,广东省汕头市金园区;440509,广东省汕头市升平区;440510,广东省汕头市河浦区;440523,广东省汕头市南澳县;440582,广东省汕头市潮阳市;440583,广东省汕头市澄海市;440600,广东省佛山市;440601,广东省佛山市市辖区;440602,广东省佛山市城区;440603,广东省佛山市石湾区;440681,广东省佛山市顺德市;440682,广东省佛山市南海市;440683,广东省佛山市三水市;440684,广东省佛山市高明市;440700,广东省江门市;440701,广东省江门市市辖区;440703,广东省江门市蓬江区;440704,广东省江门市江海区;440781,广东省江门市台山市;440782,广东省江门市新会市;440783,广东省江门市开平市;440784,广东省江门市鹤山市;440785,广东省江门市恩平市;440800,广东省湛江市;440801,广东省湛江市市辖区;440802,广东省湛江市赤坎区;440803,广东省湛江市霞山区;440804,广东省湛江市坡头区;440811,广东省湛江市麻章区;440823,广东省湛江市遂溪县;440825,广东省湛江市徐闻县;440881,广东省湛江市廉江市;440882,广东省湛江市雷州市;440883,广东省湛江市吴川市;440900,广东省茂名市;440901,广东省茂名市市辖区;440902,广东省茂名市茂南区;440923,广东省茂名市电白县;440981,广东省茂名市高州市;440982,广东省茂名市化州市;440983,广东省茂名市信宜市;441200,广东省肇庆市;441201,广东省肇庆市市辖区;441202,广东省肇庆市端州区;441203,广东省肇庆市鼎湖区;441223,广东省肇庆市广宁县;441224,广东省肇庆市怀集县;441225,广东省肇庆市封开县;441226,广东省肇庆市德庆县;441283,广东省肇庆市高要市;441284,广东省肇庆市四会市;441300,广东省惠州市;441301,广东省惠州市市辖区;441302,广东省惠州市惠城区;441322,广东省惠州市博罗县;441323,广东省惠州市惠东县;441324,广东省惠州市龙门县;441381,广东省惠州市惠阳市;441400,广东省梅州市;441401,广东省梅州市市辖区;441402,广东省梅州市梅江区;441421,广东省梅州市梅县;441422,广东省梅州市大埔县;441423,广东省梅州市丰顺县;441424,广东省梅州市五华县;441426,广东省梅州市平远县;441427,广东省梅州市蕉岭县;441481,广东省梅州市兴宁市;441500,广东省汕尾市;441501,广东省汕尾市市辖区;441502,广东省汕尾市城区;441521,广东省汕尾市海丰县;441523,广东省汕尾市陆河县;441581,广东省汕尾市陆丰市;441600,广东省河源市;441601,广东省河源市市辖区;441602,广东省河源市源城区;441621,广东省河源市紫金县;441622,广东省河源市龙川县;441623,广东省河源市连平县;441624,广东省河源市和平县;441625,广东省河源市东源县;441700,广东省阳江市;441701,广东省阳江市市辖区;441702,广东省阳江市江城区;441721,广东省阳江市阳西县;441723,广东省阳江市阳东县;441781,广东省阳江市阳春市;441800,广东省清远市;441801,广东省清远市市辖区;441802,广东省清远市清城区;441821,广东省清远市佛冈县;441823,广东省清远市阳山县;441825,广东省清远市连山壮族瑶族自治县;441826,广东省清远市连南瑶族自治县;441827,广东省清远市清新县;441881,广东省清远市英德市;441882,广东省清远市连州市;441900,广东省东莞市;441901,广东省东莞市市辖区;442000,广东省中山市;442001,广东省中山市市辖区;445100,广东省潮州市;445101,广东省潮州市市辖区;445102,广东省潮州市湘桥区;445121,广东省潮州市潮安县;445122,广东省潮州市饶平县;445200,广东省揭阳市;445201,广东省揭阳市市辖区;445202,广东省揭阳市榕城区;445221,广东省揭阳市揭东县;445222,广东省揭阳市揭西县;445224,广东省揭阳市惠来县;445281,广东省揭阳市普宁市;445300,广东省云浮市;445301,广东省云浮市市辖区;445302,广东省云浮市云城区;445321,广东省云浮市新兴县;445322,广东省云浮市郁南县;445323,广东省云浮市云安县;445381,广东省云浮市罗定市;450000,广西壮族自治区;450100,广西壮族自治区南宁市;450101,广西壮族自治区南宁市市辖区;450102,广西壮族自治区南宁市兴宁区;450103,广西壮族自治区南宁市新城区;450104,广西壮族自治区南宁市城北区;450105,广西壮族自治区南宁市江南区;450106,广西壮族自治区南宁市永新区;450111,广西壮族自治区南宁市市郊区;450121,广西壮族自治区南宁市邕宁县;450122,广西壮族自治区南宁市武鸣县;450200,广西壮族自治区柳州市;450201,广西壮族自治区柳州市市辖区;450202,广西壮族自治区柳州市城中区;450203,广西壮族自治区柳州市鱼峰区;450204,广西壮族自治区柳州市柳南区;450205,广西壮族自治区柳州市柳北区;450211,广西壮族自治区柳州市市郊区;450221,广西壮族自治区柳州市柳江县;450222,广西壮族自治区柳州市柳城县;450300,广西壮族自治区桂林市;450301,广西壮族自治区桂林市市辖区;450302,广西壮族自治区桂林市秀峰区;450303,广西壮族自治区桂林市叠彩区;450304,广西壮族自治区桂林市象山区;450305,广西壮族自治区桂林市七星区;450311,广西壮族自治区桂林市雁山区;450321,广西壮族自治区桂林市阳朔县;450322,广西壮族自治区桂林市临桂县;450323,广西壮族自治区桂林市灵川县;450324,广西壮族自治区桂林市全州县;450325,广西壮族自治区桂林市兴安县;450326,广西壮族自治区桂林市永福县;450327,广西壮族自治区桂林市灌阳县;450328,广西壮族自治区桂林市龙胜各族自治县;450329,广西壮族自治区桂林市资源县;450330,广西壮族自治区桂林市平乐县;450331,广西壮族自治区桂林市荔浦县;450332,广西壮族自治区桂林市恭城瑶族自治县;450400,广西壮族自治区梧州市;450401,广西壮族自治区梧州市市辖区;450403,广西壮族自治区梧州市万秀区;450404,广西壮族自治区梧州市蝶山区;450411,广西壮族自治区梧州市市郊区;450421,广西壮族自治区梧州市苍梧县;450422,广西壮族自治区梧州市藤县;450423,广西壮族自治区梧州市蒙山县;450481,广西壮族自治区梧州市岑溪市;450500,广西壮族自治区北海市;450501,广西壮族自治区北海市市辖区;450502,广西壮族自治区北海市海城区;450503,广西壮族自治区北海市银海区;450512,广西壮族自治区北海市铁山港区;450521,广西壮族自治区北海市合浦县;450600,广西壮族自治区防城港市;450601,广西壮族自治区防城港市市辖区;450602,广西壮族自治区防城港市港口区;450603,广西壮族自治区防城港市防城区;450621,广西壮族自治区防城港市上思县;450681,广西壮族自治区防城港市东兴市;450700,广西壮族自治区钦州市;450701,广西壮族自治区钦州市市辖区;450702,广西壮族自治区钦州市钦南区;450703,广西壮族自治区钦州市钦北区;450721,广西壮族自治区钦州市灵山县;450722,广西壮族自治区钦州市浦北县;450800,广西壮族自治区贵港市;450801,广西壮族自治区贵港市市辖区;450802,广西壮族自治区贵港市港北区;450803,广西壮族自治区贵港市港南区;450821,广西壮族自治区贵港市平南县;450881,广西壮族自治区贵港市桂平市;450900,广西壮族自治区玉林市;450901,广西壮族自治区玉林市市辖区;450902,广西壮族自治区玉林市玉州区;450921,广西壮族自治区玉林市容县;450922,广西壮族自治区玉林市陆川县;450923,广西壮族自治区玉林市博白县;450924,广西壮族自治区玉林市兴业县;450981,广西壮族自治区玉林市北流市;452100,广西壮族自治区南宁地区;452101,广西壮族自治区南宁地区凭祥市;452122,广西壮族自治区南宁地区横县;452123,广西壮族自治区南宁地区宾阳县;452124,广西壮族自治区南宁地区上林县;452126,广西壮族自治区南宁地区隆安县;452127,广西壮族自治区南宁地区马山县;452128,广西壮族自治区南宁地区扶绥县;452129,广西壮族自治区南宁地区崇左县;452130,广西壮族自治区南宁地区大新县;452131,广西壮族自治区南宁地区天等县;452132,广西壮族自治区南宁地区宁明县;452133,广西壮族自治区南宁地区龙州县;452200,广西壮族自治区柳州地区;452201,广西壮族自治区柳州地区合山市;452223,广西壮族自治区柳州地区鹿寨县;452224,广西壮族自治区柳州地区象州县;452225,广西壮族自治区柳州地区武宣县;452226,广西壮族自治区柳州地区来宾县;452227,广西壮族自治区柳州地区融安县;452228,广西壮族自治区柳州地区三江侗族自治县;452229,广西壮族自治区柳州地区融水苗族自治县;452230,广西壮族自治区柳州地区金秀瑶族自治县;452231,广西壮族自治区柳州地区忻城县;452400,广西壮族自治区贺州地区;452402,广西壮族自治区贺州地区贺州市;452424,广西壮族自治区贺州地区昭平县;452427,广西壮族自治区贺州地区钟山县;452428,广西壮族自治区贺州地区富川瑶族自治县;452600,广西壮族自治区百色地区;452601,广西壮族自治区百色地区百色市;452622,广西壮族自治区百色地区田阳县;452623,广西壮族自治区百色地区田东县;452624,广西壮族自治区百色地区平果县;452625,广西壮族自治区百色地区德保县;452626,广西壮族自治区百色地区靖西县;452627,广西壮族自治区百色地区那坡县;452628,广西壮族自治区百色地区凌云县;452629,广西壮族自治区百色地区乐业县;452630,广西壮族自治区百色地区田林县;452631,广西壮族自治区百色地区隆林各族自治县;452632,广西壮族自治区百色地区西林县;452700,广西壮族自治区河池地区;452701,广西壮族自治区河池地区河池市;452702,广西壮族自治区河池地区宜州市;452723,广西壮族自治区河池地区罗城仫佬族自治县;452724,广西壮族自治区河池地区环江毛南族自治县;452725,广西壮族自治区河池地区南丹县;452726,广西壮族自治区河池地区天峨县;452727,广西壮族自治区河池地区凤山县;452728,广西壮族自治区河池地区东兰县;452729,广西壮族自治区河池地区巴马瑶族自治县;452730,广西壮族自治区河池地区都安瑶族自治县;452731,广西壮族自治区河池地区大化瑶族自治县;460000,海南省;460001,海南省三亚市通什市;460002,海南省三亚市琼海市;460003,海南省三亚市儋州市;460004,海南省三亚市琼山市;460005,海南省三亚市文昌市;460006,海南省三亚市万宁市;460007,海南省三亚市东方市;460025,海南省三亚市定安县;460026,海南省三亚市屯昌县;460027,海南省三亚市澄迈县;460028,海南省三亚市临高县;460030,海南省三亚市白沙黎族自治县;460031,海南省三亚市昌江黎族自治县;460033,海南省三亚市乐东黎族自治县;460034,海南省三亚市陵水黎族自治县;460035,海南省三亚市保亭黎族苗族自治县;460036,海南省三亚市琼中黎族苗族自治县;460037,海南省西沙群岛;460038,海南省南沙群岛;460039,海南省中沙群岛的岛礁及其海域;460100,海南省海口市;460101,海南省海口市市辖区;460102,海南省海口市振东区;460103,海南省海口市新华区;460104,海南省海口市秀英区;460200,海南省三亚市;460201,海南省三亚市市辖区;500000,重庆市;500100,重庆市市辖区;500101,重庆市万州区;500102,重庆市涪陵区;500103,重庆市渝中区;500104,重庆市大渡口区;500105,重庆市江北区;500106,重庆市沙坪坝区;500107,重庆市九龙坡区;500108,重庆市南岸区;500109,重庆市北碚区;500110,重庆市万盛区;500111,重庆市双桥区;500112,重庆市渝北区;500113,重庆市巴南区;500200,重庆市县;500221,重庆市长寿县;500222,重庆市綦江县;500223,重庆市潼南县;500224,重庆市铜梁县;500225,重庆市大足县;500226,重庆市荣昌县;500227,重庆市璧山县;500228,重庆市梁平县;500229,重庆市城口县;500230,重庆市丰都县;500231,重庆市垫江县;500232,重庆市武隆县;500233,重庆市忠县;500234,重庆市开县;500235,重庆市云阳县;500236,重庆市奉节县;500237,重庆市巫山县;500238,重庆市巫溪县;500239,重庆市黔江土家族苗族自治县;500240,重庆市石柱土家族自治县;500241,重庆市秀山土家族苗族自治县;500242,重庆市酉阳土家族苗族自治县;500243,重庆市彭水苗族土家族自治县;500300,重庆市(市);500381,重庆市江津市;500382,重庆市合川市;500383,重庆市永川市;500384,重庆市南川市;510000,四川省;510100,四川省成都市;510101,四川省成都市市辖区;510104,四川省成都市锦江区;510105,四川省成都市青羊区;510106,四川省成都市金牛区;510107,四川省成都市武侯区;510108,四川省成都市成华区;510112,四川省成都市龙泉驿区;510113,四川省成都市青白江区;510121,四川省成都市金堂县;510122,四川省成都市双流县;510123,四川省成都市温江县;510124,四川省成都市郫县;510125,四川省成都市新都县;510129,四川省成都市大邑县;510131,四川省成都市蒲江县;510132,四川省成都市新津县;510181,四川省成都市都江堰市;510182,四川省成都市彭州市;510183,四川省成都市邛崃市;510184,四川省成都市崇州市;510300,四川省自贡市;510301,四川省自贡市市辖区;510302,四川省自贡市自流井区;510303,四川省自贡市贡井区;510304,四川省自贡市大安区;510311,四川省自贡市沿滩区;510321,四川省自贡市荣县;510322,四川省自贡市富顺县;510400,四川省攀枝花市;510401,四川省攀枝花市市辖区;510402,四川省攀枝花市东区;510403,四川省攀枝花市西区;510411,四川省攀枝花市仁和区;510421,四川省攀枝花市米易县;510422,四川省攀枝花市盐边县;510500,四川省泸州市;510501,四川省泸州市市辖区;510502,四川省泸州市江阳区;510503,四川省泸州市纳溪区;510504,四川省泸州市龙马潭区;510521,四川省泸州市泸县;510522,四川省泸州市合江县;510524,四川省泸州市叙永县;510525,四川省泸州市古蔺县;510600,四川省德阳市;510601,四川省德阳市市辖区;510603,四川省德阳市旌阳区;510623,四川省德阳市中江县;510626,四川省德阳市罗江县;510681,四川省德阳市广汉市;510682,四川省德阳市什邡市;510683,四川省德阳市绵竹市;510700,四川省绵阳市;510701,四川省绵阳市市辖区;510703,四川省绵阳市涪城区;510704,四川省绵阳市游仙区;510722,四川省绵阳市三台县;510723,四川省绵阳市盐亭县;510724,四川省绵阳市安县;510725,四川省绵阳市梓潼县;510726,四川省绵阳市北川县;510727,四川省绵阳市平武县;510781,四川省绵阳市江油市;510800,四川省广元市;510801,四川省广元市市辖区;510802,四川省广元市市中区;510811,四川省广元市元坝区;510812,四川省广元市朝天区;510821,四川省广元市旺苍县;510822,四川省广元市青川县;510823,四川省广元市剑阁县;510824,四川省广元市苍溪县;510900,四川省遂宁市;510901,四川省遂宁市市辖区;510902,四川省遂宁市市中区;510921,四川省遂宁市蓬溪县;510922,四川省遂宁市射洪县;510923,四川省遂宁市大英县;511000,四川省内江市;511001,四川省内江市市辖区;511002,四川省内江市市中区;511011,四川省内江市东兴区;511024,四川省内江市威远县;511025,四川省内江市资中县;511028,四川省内江市隆昌县;511100,四川省乐山市;511101,四川省乐山市市辖区;511102,四川省乐山市市中区;511111,四川省乐山市沙湾区;511112,四川省乐山市五通桥区;511113,四川省乐山市金口河区;511123,四川省乐山市犍为县;511124,四川省乐山市井研县;511126,四川省乐山市夹江县;511129,四川省乐山市沐川县;511132,四川省乐山市峨边彝族自治县;511133,四川省乐山市马边彝族自治县;511181,四川省乐山市峨眉山市;511300,四川省南充市;511301,四川省南充市市辖区;511302,四川省南充市顺庆区;511303,四川省南充市高坪区;511304,四川省南充市嘉陵区;511321,四川省南充市南部县;511322,四川省南充市营山县;511323,四川省南充市蓬安县;511324,四川省南充市仪陇县;511325,四川省南充市西充县;511381,四川省南充市阆中市;511500,四川省宜宾市;511501,四川省宜宾市市辖区;511502,四川省宜宾市翠屏区;511521,四川省宜宾市宜宾县;511522,四川省宜宾市南溪县;511523,四川省宜宾市江安县;511524,四川省宜宾市长宁县;511525,四川省宜宾市高县;511526,四川省宜宾市珙县;511527,四川省宜宾市筠连县;511528,四川省宜宾市兴文县;511529,四川省宜宾市屏山县;511600,四川省广安市;511601,四川省广安市市辖区;511602,四川省广安市广安区;511621,四川省广安市岳池县;511622,四川省广安市武胜县;511623,四川省广安市邻水县;511681,四川省广安市华蓥市;513000,四川省达川地区;513001,四川省达川地区达川市;513002,四川省达川地区万源市;513021,四川省达川地区达县;513022,四川省达川地区宣汉县;513023,四川省达川地区开江县;513029,四川省达川地区大竹县;513030,四川省达川地区渠县;513100,四川省雅安地区;513101,四川省雅安地区雅安市;513122,四川省雅安地区名山县;513123,四川省雅安地区荥经县;513124,四川省雅安地区汉源县;513125,四川省雅安地区石棉县;513126,四川省雅安地区天全县;513127,四川省雅安地区芦山县;513128,四川省雅安地区宝兴县;513200,四川省阿坝藏族羌族自治州;513221,四川省阿坝藏族羌族自治州汶川县;513222,四川省阿坝藏族羌族自治州理县;513223,四川省阿坝藏族羌族自治州茂县;513224,四川省阿坝藏族羌族自治州松潘县;513225,四川省阿坝藏族羌族自治州九寨沟县;513226,四川省阿坝藏族羌族自治州金川县;513227,四川省阿坝藏族羌族自治州小金县;513228,四川省阿坝藏族羌族自治州黑水县;513229,四川省阿坝藏族羌族自治州马尔康县;513230,四川省阿坝藏族羌族自治州壤塘县;513231,四川省阿坝藏族羌族自治州阿坝县;513232,四川省阿坝藏族羌族自治州若尔盖县;513233,四川省阿坝藏族羌族自治州红原县;513300,四川省甘孜藏族自治州;513321,四川省甘孜藏族自治州康定县;513322,四川省甘孜藏族自治州泸定县;513323,四川省甘孜藏族自治州丹巴县;513324,四川省甘孜藏族自治州九龙县;513325,四川省甘孜藏族自治州雅江县;513326,四川省甘孜藏族自治州道孚县;513327,四川省甘孜藏族自治州炉霍县;513328,四川省甘孜藏族自治州甘孜县;513329,四川省甘孜藏族自治州新龙县;513330,四川省甘孜藏族自治州德格县;513331,四川省甘孜藏族自治州白玉县;513332,四川省甘孜藏族自治州石渠县;513333,四川省甘孜藏族自治州色达县;513334,四川省甘孜藏族自治州理塘县;513335,四川省甘孜藏族自治州巴塘县;513336,四川省甘孜藏族自治州乡城县;513337,四川省甘孜藏族自治州稻城县;513338,四川省甘孜藏族自治州得荣县;513400,四川省凉山彝族自治州;513401,四川省凉山彝族自治州西昌市;513422,四川省凉山彝族自治州木里藏族自治县;513423,四川省凉山彝族自治州盐源县;513424,四川省凉山彝族自治州德昌县;513425,四川省凉山彝族自治州会理县;513426,四川省凉山彝族自治州会东县;513427,四川省凉山彝族自治州宁南县;513428,四川省凉山彝族自治州普格县;513429,四川省凉山彝族自治州布拖县;513430,四川省凉山彝族自治州金阳县;513431,四川省凉山彝族自治州昭觉县;513432,四川省凉山彝族自治州喜德县;513433,四川省凉山彝族自治州冕宁县;513434,四川省凉山彝族自治州越西县;513435,四川省凉山彝族自治州甘洛县;513436,四川省凉山彝族自治州美姑县;513437,四川省凉山彝族自治州雷波县;513700,四川省巴中地区;513701,四川省巴中地区巴中市;513721,四川省巴中地区通江县;513722,四川省巴中地区南江县;513723,四川省巴中地区平昌县;513800,四川省眉山地区;513821,四川省眉山地区眉山县;513822,四川省眉山地区仁寿县;513823,四川省眉山地区彭山县;513824,四川省眉山地区洪雅县;513825,四川省眉山地区丹棱县;513826,四川省眉山地区青神县;513900,四川省眉山地区资阳地区;513901,四川省眉山地区资阳市;513902,四川省眉山地区简阳市;513921,四川省眉山地区安岳县;513922,四川省眉山地区乐至县;520000,贵州省;520100,贵州省贵阳市;520101,贵州省贵阳市市辖区;520102,贵州省贵阳市南明区;520103,贵州省贵阳市云岩区;520111,贵州省贵阳市花溪区;520112,贵州省贵阳市乌当区;520113,贵州省贵阳市白云区;520121,贵州省贵阳市开阳县;520122,贵州省贵阳市息烽县;520123,贵州省贵阳市修文县;520181,贵州省贵阳市清镇市;520200,贵州省六盘水市;520201,贵州省六盘水市钟山区;520202,贵州省六盘水市盘县特区;520203,贵州省六盘水市六枝特区;520221,贵州省六盘水市水城县;520300,贵州省遵义市;520301,贵州省遵义市市辖区;520302,贵州省遵义市红花岗区;520321,贵州省遵义市遵义县;520322,贵州省遵义市桐梓县;520323,贵州省遵义市绥阳县;520324,贵州省遵义市正安县;520325,贵州省遵义市道真仡佬族苗族自治县;520326,贵州省遵义市务川仡佬族苗族自治县;520327,贵州省遵义市凤冈县;520328,贵州省遵义市湄潭县;520329,贵州省遵义市余庆县;520330,贵州省遵义市习水县;520381,贵州省遵义市赤水市;520382,贵州省遵义市仁怀市;522200,贵州省铜仁地区;522201,贵州省铜仁地区铜仁市;522222,贵州省铜仁地区江口县;522223,贵州省铜仁地区玉屏侗族自治县;522224,贵州省铜仁地区石阡县;522225,贵州省铜仁地区思南县;522226,贵州省铜仁地区印江土家族苗族自治县;522227,贵州省铜仁地区德江县;522228,贵州省铜仁地区沿河土家族自治县;522229,贵州省铜仁地区松桃苗族自治县;522230,贵州省铜仁地区万山特区;522300,贵州省黔西南布依族苗族自治州;522301,贵州省黔西南布依族苗族自治州兴义市;522322,贵州省黔西南布依族苗族自治州兴仁县;522323,贵州省黔西南布依族苗族自治州普安县;522324,贵州省黔西南布依族苗族自治州晴隆县;522325,贵州省黔西南布依族苗族自治州贞丰县;522326,贵州省黔西南布依族苗族自治州望谟县;522327,贵州省黔西南布依族苗族自治州册亨县;522328,贵州省黔西南布依族苗族自治州安龙县;522400,贵州省毕节地区;522401,贵州省毕节地区毕节市;522422,贵州省毕节地区大方县;522423,贵州省毕节地区黔西县;522424,贵州省毕节地区金沙县;522425,贵州省毕节地区织金县;522426,贵州省毕节地区纳雍县;522427,贵州省毕节地区威宁彝族回族苗族自治县;522428,贵州省毕节地区赫章县;522500,贵州省安顺地区;522501,贵州省安顺地区安顺市;522526,贵州省安顺地区平坝县;522527,贵州省安顺地区普定县;522528,贵州省安顺地区关岭布依族苗族自治县;522529,贵州省安顺地区镇宁布依族苗族自治县;522530,贵州省安顺地区紫云苗族布依族自治县;522600,贵州省黔东南苗族侗族自治州;522601,贵州省黔东南苗族侗族自治州凯里市;522622,贵州省黔东南苗族侗族自治州黄平县;522623,贵州省黔东南苗族侗族自治州施秉县;522624,贵州省黔东南苗族侗族自治州三穗县;522625,贵州省黔东南苗族侗族自治州镇远县;522626,贵州省黔东南苗族侗族自治州岑巩县;522627,贵州省黔东南苗族侗族自治州天柱县;522628,贵州省黔东南苗族侗族自治州锦屏县;522629,贵州省黔东南苗族侗族自治州剑河县;522630,贵州省黔东南苗族侗族自治州台江县;522631,贵州省黔东南苗族侗族自治州黎平县;522632,贵州省黔东南苗族侗族自治州榕江县;522633,贵州省黔东南苗族侗族自治州从江县;522634,贵州省黔东南苗族侗族自治州雷山县;522635,贵州省黔东南苗族侗族自治州麻江县;522636,贵州省黔东南苗族侗族自治州丹寨县;522700,贵州省黔南布依族苗族自治州;522701,贵州省黔南布依族苗族自治州都匀市;522702,贵州省黔南布依族苗族自治州福泉市;522722,贵州省黔南布依族苗族自治州荔波县;522723,贵州省黔南布依族苗族自治州贵定县;522725,贵州省黔南布依族苗族自治州瓮安县;522726,贵州省黔南布依族苗族自治州独山县;522727,贵州省黔南布依族苗族自治州平塘县;522728,贵州省黔南布依族苗族自治州罗甸县;522729,贵州省黔南布依族苗族自治州长顺县;522730,贵州省黔南布依族苗族自治州龙里县;522731,贵州省黔南布依族苗族自治州惠水县;522732,贵州省黔南布依族苗族自治州三都水族自治县;530000,云南省;530100,云南省昆明市;530101,云南省昆明市市辖区;530102,云南省昆明市五华区;530103,云南省昆明市盘龙区;530111,云南省昆明市官渡区;530112,云南省昆明市西山区;530113,云南省昆明市东川区;530121,云南省昆明市呈贡县;530122,云南省昆明市晋宁县;530124,云南省昆明市富民县;530125,云南省昆明市宜良县;530126,云南省昆明市石林彝族自治县;530127,云南省昆明市嵩明县;530128,云南省昆明市禄劝彝族苗族自治县;530129,云南省昆明市寻甸回族彝族自治县;530181,云南省昆明市安宁市;530300,云南省曲靖市;530301,云南省曲靖市市辖区;530302,云南省曲靖市麒麟区;530321,云南省曲靖市马龙县;530322,云南省曲靖市陆良县;530323,云南省曲靖市师宗县;530324,云南省曲靖市罗平县;530325,云南省曲靖市富源县;530326,云南省曲靖市会泽县;530328,云南省曲靖市沾益县;530381,云南省曲靖市宣威市;530400,云南省玉溪市;530401,云南省玉溪市市辖区;530402,云南省玉溪市红塔区;530421,云南省玉溪市江川县;530422,云南省玉溪市澄江县;530423,云南省玉溪市通海县;530424,云南省玉溪市华宁县;530425,云南省玉溪市易门县;530426,云南省玉溪市峨山彝族自治县;530427,云南省玉溪市新平彝族傣族自治县;530428,云南省玉溪市元江哈尼族彝族傣族自治县;532100,云南省昭通地区;532101,云南省昭通地区昭通市;532122,云南省昭通地区鲁甸县;532123,云南省昭通地区巧家县;532124,云南省昭通地区盐津县;532125,云南省昭通地区大关县;532126,云南省昭通地区永善县;532127,云南省昭通地区绥江县;532128,云南省昭通地区镇雄县;532129,云南省昭通地区彝良县;532130,云南省昭通地区威信县;532131,云南省昭通地区水富县;532300,云南省楚雄彝族自治州;532301,云南省楚雄彝族自治州楚雄市;532322,云南省楚雄彝族自治州双柏县;532323,云南省楚雄彝族自治州牟定县;532324,云南省楚雄彝族自治州南华县;532325,云南省楚雄彝族自治州姚安县;532326,云南省楚雄彝族自治州大姚县;532327,云南省楚雄彝族自治州永仁县;532328,云南省楚雄彝族自治州元谋县;532329,云南省楚雄彝族自治州武定县;532331,云南省楚雄彝族自治州禄丰县;532500,云南省红河哈尼族彝族自治州;532501,云南省红河哈尼族彝族自治州个旧市;532502,云南省红河哈尼族彝族自治州开远市;532522,云南省红河哈尼族彝族自治州蒙自县;532523,云南省红河哈尼族彝族自治州屏边苗族自治县;532524,云南省红河哈尼族彝族自治州建水县;532525,云南省红河哈尼族彝族自治州石屏县;532526,云南省红河哈尼族彝族自治州弥勒县;532527,云南省红河哈尼族彝族自治州泸西县;532528,云南省红河哈尼族彝族自治州元阳县;532529,云南省红河哈尼族彝族自治州红河县;532530,云南省红河哈尼族彝族自治州金平苗族瑶族傣族自治县;532531,云南省红河哈尼族彝族自治州绿春县;532532,云南省红河哈尼族彝族自治州河口瑶族自治县;532600,云南省文山壮族苗族自治州;532621,云南省文山壮族苗族自治州文山县;532622,云南省文山壮族苗族自治州砚山县;532623,云南省文山壮族苗族自治州西畴县;532624,云南省文山壮族苗族自治州麻栗坡县;532625,云南省文山壮族苗族自治州马关县;532626,云南省文山壮族苗族自治州丘北县;532627,云南省文山壮族苗族自治州广南县;532628,云南省文山壮族苗族自治州富宁县;532700,云南省思茅地区;532701,云南省思茅地区思茅市;532722,云南省思茅地区普洱哈尼族彝族自治县;532723,云南省思茅地区墨江哈尼族自治县;532724,云南省思茅地区景东彝族自治县;532725,云南省思茅地区景谷傣族彝族自治县;532726,云南省思茅地区镇沅彝族哈尼族拉祜族自治县;532727,云南省思茅地区江城哈尼族彝族自治县;532728,云南省思茅地区孟连傣族拉祜族佤族自治县;532729,云南省思茅地区澜沧拉祜族自治县;532730,云南省思茅地区西盟佤族自治县;532800,云南省西双版纳傣族自治州;532801,云南省西双版纳傣族自治州景洪市;532822,云南省西双版纳傣族自治州勐海县;532823,云南省西双版纳傣族自治州勐腊县;532900,云南省大理白族自治州;532901,云南省大理白族自治州大理市;532922,云南省大理白族自治州漾濞彝族自治县;532923,云南省大理白族自治州祥云县;532924,云南省大理白族自治州宾川县;532925,云南省大理白族自治州弥渡县;532926,云南省大理白族自治州南涧彝族自治县;532927,云南省大理白族自治州巍山彝族回族自治县;532928,云南省大理白族自治州永平县;532929,云南省大理白族自治州云龙县;532930,云南省大理白族自治州洱源县;532931,云南省大理白族自治州剑川县;532932,云南省大理白族自治州鹤庆县;533000,云南省保山地区;533001,云南省保山地区保山市;533022,云南省保山地区施甸县;533023,云南省保山地区腾冲县;533024,云南省保山地区龙陵县;533025,云南省保山地区昌宁县;533100,云南省德宏傣族景颇族自治州;533101,云南省德宏傣族景颇族自治州畹町市;533102,云南省德宏傣族景颇族自治州瑞丽市;533103,云南省德宏傣族景颇族自治州潞西市;533122,云南省德宏傣族景颇族自治州梁河县;533123,云南省德宏傣族景颇族自治州盈江县;533124,云南省德宏傣族景颇族自治州陇川县;533200,云南省丽江地区;533221,云南省丽江地区丽江纳西族自治县;533222,云南省丽江地区永胜县;533223,云南省丽江地区华坪县;533224,云南省丽江地区宁蒗彝族自治县;533300,云南省怒江傈僳族自治州;533321,云南省怒江傈僳族自治州泸水县;533323,云南省怒江傈僳族自治州福贡县;533324,云南省怒江傈僳族自治州贡山独龙族怒族自治县;533325,云南省怒江傈僳族自治州兰坪白族普米族自治县;533400,云南省迪庆藏族自治州;533421,云南省迪庆藏族自治州中甸县;533422,云南省迪庆藏族自治州德钦县;533423,云南省迪庆藏族自治州维西傈僳族自治县;533500,云南省临沧地区;533521,云南省临沧地区临沧县;533522,云南省临沧地区凤庆县;533523,云南省临沧地区云县;533524,云南省临沧地区永德县;533525,云南省临沧地区镇康县;533526,云南省临沧地区双江拉祜族佤族布朗族傣族自治县;533527,云南省临沧地区耿马傣族佤族自治县;533528,云南省临沧地区沧源佤族自治县;540000,西藏自治区;540100,西藏自治区拉萨市;540101,西藏自治区拉萨市市辖区;540102,西藏自治区拉萨市城关区;540121,西藏自治区拉萨市林周县;540122,西藏自治区拉萨市当雄县;540123,西藏自治区拉萨市尼木县;540124,西藏自治区拉萨市曲水县;540125,西藏自治区拉萨市堆龙德庆县;540126,西藏自治区拉萨市达孜县;540127,西藏自治区拉萨市墨竹工卡县;542100,西藏自治区昌都地区;542121,西藏自治区昌都地区昌都县;542122,西藏自治区昌都地区江达县;542123,西藏自治区昌都地区贡觉县;542124,西藏自治区昌都地区类乌齐县;542125,西藏自治区昌都地区丁青县;542126,西藏自治区昌都地区察雅县;542127,西藏自治区昌都地区八宿县;542128,西藏自治区昌都地区左贡县;542129,西藏自治区昌都地区芒康县;542132,西藏自治区昌都地区洛隆县;542133,西藏自治区昌都地区边坝县;542134,西藏自治区昌都地区盐井县;542135,西藏自治区昌都地区碧土县;542136,西藏自治区昌都地区妥坝县;542137,西藏自治区昌都地区生达县;542200,西藏自治区山南地区;542221,西藏自治区山南地区乃东县;542222,西藏自治区山南地区扎囊县;542223,西藏自治区山南地区贡嘎县;542224,西藏自治区山南地区桑日县;542225,西藏自治区山南地区琼结县;542226,西藏自治区山南地区曲松县;542227,西藏自治区山南地区措美县;542228,西藏自治区山南地区洛扎县;542229,西藏自治区山南地区加查县;542231,西藏自治区山南地区隆子县;542232,西藏自治区山南地区错那县;542233,西藏自治区山南地区浪卡子县;542300,西藏自治区日喀则地区;542301,西藏自治区日喀则地区日喀则市;542322,西藏自治区日喀则地区南木林县;542323,西藏自治区日喀则地区江孜县;542324,西藏自治区日喀则地区定日县;542325,西藏自治区日喀则地区萨迦县;542326,西藏自治区日喀则地区拉孜县;542327,西藏自治区日喀则地区昂仁县;542328,西藏自治区日喀则地区谢通门县;542329,西藏自治区日喀则地区白朗县;542330,西藏自治区日喀则地区仁布县;542331,西藏自治区日喀则地区康马县;542332,西藏自治区日喀则地区定结县;542333,西藏自治区日喀则地区仲巴县;542334,西藏自治区日喀则地区亚东县;542335,西藏自治区日喀则地区吉隆县;542336,西藏自治区日喀则地区聂拉木县;542337,西藏自治区日喀则地区萨嘎县;542338,西藏自治区日喀则地区岗巴县;542400,西藏自治区那曲地区;542421,西藏自治区那曲地区那曲县;542422,西藏自治区那曲地区嘉黎县;542423,西藏自治区那曲地区比如县;542424,西藏自治区那曲地区聂荣县;542425,西藏自治区那曲地区安多县;542426,西藏自治区那曲地区申扎县;542427,西藏自治区那曲地区索县;542428,西藏自治区那曲地区班戈县;542429,西藏自治区那曲地区巴青县;542430,西藏自治区那曲地区尼玛县;542500,西藏自治区阿里地区;542521,西藏自治区阿里地区普兰县;542522,西藏自治区阿里地区札达县;542523,西藏自治区阿里地区噶尔县;542524,西藏自治区阿里地区日土县;542525,西藏自治区阿里地区革吉县;542526,西藏自治区阿里地区改则县;542527,西藏自治区阿里地区措勤县;542528,西藏自治区阿里地区隆格尔县;542600,西藏自治区林芝地区;542621,西藏自治区林芝地区林芝县;542622,西藏自治区林芝地区工布江达县;542623,西藏自治区林芝地区米林县;542624,西藏自治区林芝地区墨脱县;542625,西藏自治区林芝地区波密县;542626,西藏自治区林芝地区察隅县;542627,西藏自治区林芝地区朗县;610000,陕西省;610100,陕西省西安市;610101,陕西省西安市市辖区;610102,陕西省西安市新城区;610103,陕西省西安市碑林区;610104,陕西省西安市莲湖区;610111,陕西省西安市灞桥区;610112,陕西省西安市未央区;610113,陕西省西安市雁塔区;610114,陕西省西安市阎良区;610115,陕西省西安市临潼区;610121,陕西省西安市长安县;610122,陕西省西安市蓝田县;610124,陕西省西安市周至县;610125,陕西省西安市户县;610126,陕西省西安市高陵县;610200,陕西省铜川市;610201,陕西省铜川市市辖区;610202,陕西省铜川市城区;610203,陕西省铜川市郊区;610221,陕西省铜川市耀县;610222,陕西省铜川市宜君县;610300,陕西省宝鸡市;610301,陕西省宝鸡市市辖区;610302,陕西省宝鸡市渭滨区;610303,陕西省宝鸡市金台区;610321,陕西省宝鸡市宝鸡县;610322,陕西省宝鸡市凤翔县;610323,陕西省宝鸡市岐山县;610324,陕西省宝鸡市扶风县;610326,陕西省宝鸡市眉县;610327,陕西省宝鸡市陇县;610328,陕西省宝鸡市千阳县;610329,陕西省宝鸡市麟游县;610330,陕西省宝鸡市凤县;610331,陕西省宝鸡市太白县;610400,陕西省咸阳市;610401,陕西省咸阳市市辖区;610402,陕西省咸阳市秦都区;610403,陕西省咸阳市杨陵区;610404,陕西省咸阳市渭城区;610422,陕西省咸阳市三原县;610423,陕西省咸阳市泾阳县;610424,陕西省咸阳市乾县;610425,陕西省咸阳市礼泉县;610426,陕西省咸阳市永寿县;610427,陕西省咸阳市彬县;610428,陕西省咸阳市长武县;610429,陕西省咸阳市旬邑县;610430,陕西省咸阳市淳化县;610431,陕西省咸阳市武功县;610481,陕西省咸阳市兴平市;610500,陕西省渭南市;610501,陕西省渭南市市辖区;610502,陕西省渭南市临渭区;610521,陕西省渭南市华县;610522,陕西省渭南市潼关县;610523,陕西省渭南市大荔县;610524,陕西省渭南市合阳县;610525,陕西省渭南市澄城县;610526,陕西省渭南市蒲城县;610527,陕西省渭南市白水县;610528,陕西省渭南市富平县;610581,陕西省渭南市韩城市;610582,陕西省渭南市华阴市;610600,陕西省延安市;610601,陕西省延安市市辖区;610602,陕西省延安市宝塔区;610621,陕西省延安市延长县;610622,陕西省延安市延川县;610623,陕西省延安市子长县;610624,陕西省延安市安塞县;610625,陕西省延安市志丹县;610626,陕西省延安市吴旗县;610627,陕西省延安市甘泉县;610628,陕西省延安市富县;610629,陕西省延安市洛川县;610630,陕西省延安市宜川县;610631,陕西省延安市黄龙县;610632,陕西省延安市黄陵县;610700,陕西省汉中市;610701,陕西省汉中市市辖区;610702,陕西省汉中市汉台区;610721,陕西省汉中市南郑县;610722,陕西省汉中市城固县;610723,陕西省汉中市洋县;610724,陕西省汉中市西乡县;610725,陕西省汉中市勉县;610726,陕西省汉中市宁强县;610727,陕西省汉中市略阳县;610728,陕西省汉中市镇巴县;610729,陕西省汉中市留坝县;610730,陕西省汉中市佛坪县;612400,陕西省安康地区;612401,陕西省安康地区安康市;612422,陕西省安康地区汉阴县;612423,陕西省安康地区石泉县;612424,陕西省安康地区宁陕县;612425,陕西省安康地区紫阳县;612426,陕西省安康地区岚皋县;612427,陕西省安康地区平利县;612428,陕西省安康地区镇坪县;612429,陕西省安康地区旬阳县;612430,陕西省安康地区白河县;612500,陕西省商洛地区;612501,陕西省商洛地区商州市;612522,陕西省商洛地区洛南县;612523,陕西省商洛地区丹凤县;612524,陕西省商洛地区商南县;612525,陕西省商洛地区山阳县;612526,陕西省商洛地区镇安县;612527,陕西省商洛地区柞水县;612700,陕西省榆林地区;612701,陕西省榆林地区榆林市;612722,陕西省榆林地区神木县;612723,陕西省榆林地区府谷县;612724,陕西省榆林地区横山县;612725,陕西省榆林地区靖边县;612726,陕西省榆林地区定边县;612727,陕西省榆林地区绥德县;612728,陕西省榆林地区米脂县;612729,陕西省榆林地区佳县;612730,陕西省榆林地区吴堡县;612731,陕西省榆林地区清涧县;612732,陕西省榆林地区子洲县;620000,甘肃省;620100,甘肃省兰州市;620101,甘肃省兰州市市辖区;620102,甘肃省兰州市城关区;620103,甘肃省兰州市七里河区;620104,甘肃省兰州市西固区;620105,甘肃省兰州市安宁区;620111,甘肃省兰州市红古区;620121,甘肃省兰州市永登县;620122,甘肃省兰州市皋兰县;620123,甘肃省兰州市榆中县;620200,甘肃省嘉峪关市;620201,甘肃省嘉峪关市市辖区;620300,甘肃省嘉峪关市金昌市;620301,甘肃省嘉峪关市市辖区;620302,甘肃省嘉峪关市金川区;620321,甘肃省嘉峪关市永昌县;620400,甘肃省白银市;620401,甘肃省白银市市辖区;620402,甘肃省白银市白银区;620403,甘肃省白银市平川区;620421,甘肃省白银市靖远县;620422,甘肃省白银市会宁县;620423,甘肃省白银市景泰县;620500,甘肃省天水市;620501,甘肃省天水市市辖区;620502,甘肃省天水市秦城区;620503,甘肃省天水市北道区;620521,甘肃省天水市清水县;620522,甘肃省天水市秦安县;620523,甘肃省天水市甘谷县;620524,甘肃省天水市武山县;620525,甘肃省天水市张家川回族自治县;622100,甘肃省酒泉地区;622101,甘肃省酒泉地区玉门市;622102,甘肃省酒泉地区酒泉市;622103,甘肃省酒泉地区敦煌市;622123,甘肃省酒泉地区金塔县;622124,甘肃省酒泉地区肃北蒙古族自治县;622125,甘肃省酒泉地区阿克塞哈萨克族自治县;622126,甘肃省酒泉地区安西县;622200,甘肃省张掖地区;622201,甘肃省张掖地区张掖市;622222,甘肃省张掖地区肃南裕固族自治县;622223,甘肃省张掖地区民乐县;622224,甘肃省张掖地区临泽县;622225,甘肃省张掖地区高台县;622226,甘肃省张掖地区山丹县;622300,甘肃省武威地区;622301,甘肃省武威地区武威市;622322,甘肃省武威地区民勤县;622323,甘肃省武威地区古浪县;622326,甘肃省武威地区天祝藏族自治县;622400,甘肃省定西地区;622421,甘肃省定西地区定西县;622424,甘肃省定西地区通渭县;622425,甘肃省定西地区陇西县;622426,甘肃省定西地区渭源县;622427,甘肃省定西地区临洮县;622428,甘肃省定西地区漳县;622429,甘肃省定西地区岷县;622600,甘肃省陇南地区;622621,甘肃省陇南地区武都县;622623,甘肃省陇南地区宕昌县;622624,甘肃省陇南地区成县;622625,甘肃省陇南地区康县;622626,甘肃省陇南地区文县;622627,甘肃省陇南地区西和县;622628,甘肃省陇南地区礼县;622629,甘肃省陇南地区两当县;622630,甘肃省陇南地区徽县;622700,甘肃省平凉地区;622701,甘肃省平凉地区平凉市;622722,甘肃省平凉地区泾川县;622723,甘肃省平凉地区灵台县;622724,甘肃省平凉地区崇信县;622725,甘肃省平凉地区华亭县;622726,甘肃省平凉地区庄浪县;622727,甘肃省平凉地区静宁县;622800,甘肃省庆阳地区;622801,甘肃省庆阳地区西峰市;622821,甘肃省庆阳地区庆阳县;622822,甘肃省庆阳地区环县;622823,甘肃省庆阳地区华池县;622824,甘肃省庆阳地区合水县;622825,甘肃省庆阳地区正宁县;622826,甘肃省庆阳地区宁县;622827,甘肃省庆阳地区镇原县;622900,甘肃省临夏回族自治州;622901,甘肃省临夏回族自治州临夏市;622921,甘肃省临夏回族自治州临夏县;622922,甘肃省临夏回族自治州康乐县;622923,甘肃省临夏回族自治州永靖县;622924,甘肃省临夏回族自治州广河县;622925,甘肃省临夏回族自治州和政县;622926,甘肃省临夏回族自治州东乡族自治县;622927,甘肃省临夏回族自治州积石山保安族东乡族撒拉族自治县;623000,甘肃省甘南藏族自治州;623001,甘肃省甘南藏族自治州合作市;623021,甘肃省甘南藏族自治州临潭县;623022,甘肃省甘南藏族自治州卓尼县;623023,甘肃省甘南藏族自治州舟曲县;623024,甘肃省甘南藏族自治州迭部县;623025,甘肃省甘南藏族自治州玛曲县;623026,甘肃省甘南藏族自治州碌曲县;623027,甘肃省甘南藏族自治州夏河县;630000,青海省;630100,青海省西宁市;630101,青海省西宁市市辖区;630102,青海省西宁市城东区;630103,青海省西宁市城中区;630104,青海省西宁市城西区;630105,青海省西宁市城北区;630121,青海省西宁市大通回族土族自治县;632100,青海省海东地区;632121,青海省海东地区平安县;632122,青海省海东地区民和回族土族自治县;632123,青海省海东地区乐都县;632124,青海省海东地区湟中县;632125,青海省海东地区湟源县;632126,青海省海东地区互助土族自治县;632127,青海省海东地区化隆回族自治县;632128,青海省海东地区循化撒拉族自治县;632200,青海省海北藏族自治州;632221,青海省海北藏族自治州门源回族自治县;632222,青海省海北藏族自治州祁连县;632223,青海省海北藏族自治州海晏县;632224,青海省海北藏族自治州刚察县;632300,青海省黄南藏族自治州;632321,青海省黄南藏族自治州同仁县;632322,青海省黄南藏族自治州尖扎县;632323,青海省黄南藏族自治州泽库县;632324,青海省黄南藏族自治州河南蒙古族自治县;632500,青海省海南藏族自治州;632521,青海省海南藏族自治州共和县;632522,青海省海南藏族自治州同德县;632523,青海省海南藏族自治州贵德县;632524,青海省海南藏族自治州兴海县;632525,青海省海南藏族自治州贵南县;632600,青海省果洛藏族自治州;632621,青海省果洛藏族自治州玛沁县;632622,青海省果洛藏族自治州班玛县;632623,青海省果洛藏族自治州甘德县;632624,青海省果洛藏族自治州达日县;632625,青海省果洛藏族自治州久治县;632626,青海省果洛藏族自治州玛多县;632700,青海省玉树藏族自治州;632721,青海省玉树藏族自治州玉树县;632722,青海省玉树藏族自治州杂多县;632723,青海省玉树藏族自治州称多县;632724,青海省玉树藏族自治州治多县;632725,青海省玉树藏族自治州囊谦县;632726,青海省玉树藏族自治州曲麻莱县;632800,青海省海西蒙古族藏族自治州;632801,青海省海西蒙古族藏族自治州格尔木市;632802,青海省海西蒙古族藏族自治州德令哈市;632821,青海省海西蒙古族藏族自治州乌兰县;632822,青海省海西蒙古族藏族自治州都兰县;632823,青海省海西蒙古族藏族自治州天峻县;640000,宁夏回族自治区;640100,宁夏回族自治区银川市;640101,宁夏回族自治区银川市市辖区;640102,宁夏回族自治区银川市城区;640103,宁夏回族自治区银川市新城区;640111,宁夏回族自治区银川市郊区;640121,宁夏回族自治区银川市永宁县;640122,宁夏回族自治区银川市贺兰县;640200,宁夏回族自治区石嘴山市;640201,宁夏回族自治区石嘴山市市辖区;640202,宁夏回族自治区石嘴山市大武口区;640203,宁夏回族自治区石嘴山市石嘴山区;640204,宁夏回族自治区石嘴山市石炭井区;640221,宁夏回族自治区石嘴山市平罗县;640222,宁夏回族自治区石嘴山市陶乐县;640223,宁夏回族自治区石嘴山市惠农县;640300,宁夏回族自治区吴忠市;640301,宁夏回族自治区吴忠市市辖区;640302,宁夏回族自治区吴忠市利通区;640321,宁夏回族自治区吴忠市中卫县;640322,宁夏回族自治区吴忠市中宁县;640323,宁夏回族自治区吴忠市盐池县;640324,宁夏回族自治区吴忠市同心县;640381,宁夏回族自治区吴忠市青铜峡市;640382,宁夏回族自治区吴忠市灵武市;642200,宁夏回族自治区固原地区;642221,宁夏回族自治区固原地区固原县;642222,宁夏回族自治区固原地区海原县;642223,宁夏回族自治区固原地区西吉县;642224,宁夏回族自治区固原地区隆德县;642225,宁夏回族自治区固原地区泾源县;642226,宁夏回族自治区固原地区彭阳县;650000,新疆维吾尔自治区;650100,新疆维吾尔族自治区乌鲁木齐市;650101,新疆维吾尔族自治区乌鲁木齐市市辖区;650102,新疆维吾尔族自治区乌鲁木齐市天山区;650103,新疆维吾尔族自治区乌鲁木齐市沙依巴克区;650104,新疆维吾尔族自治区乌鲁木齐市新市区;650105,新疆维吾尔族自治区乌鲁木齐市水磨沟区;650106,新疆维吾尔族自治区乌鲁木齐市头屯河区;650107,新疆维吾尔族自治区乌鲁木齐市南山矿区;650108,新疆维吾尔族自治区乌鲁木齐市东山区;650121,新疆维吾尔族自治区乌鲁木齐市乌鲁木齐县;650200,新疆维吾尔族自治区克拉玛依市;650201,新疆维吾尔族自治区克拉玛依市市辖区;650202,新疆维吾尔族自治区克拉玛依市独山子区;650203,新疆维吾尔族自治区克拉玛依市克拉玛依区;650204,新疆维吾尔族自治区克拉玛依市白碱滩区;650205,新疆维吾尔族自治区克拉玛依市乌尔禾区;652100,新疆维吾尔族自治区吐鲁番地区;652101,新疆维吾尔族自治区吐鲁番地区吐鲁番市;652122,新疆维吾尔族自治区吐鲁番地区鄯善县;652123,新疆维吾尔族自治区吐鲁番地区托克逊县;652200,新疆维吾尔族自治区哈密地区;652201,新疆维吾尔族自治区哈密地区哈密市;652222,新疆维吾尔族自治区哈密地区巴里坤哈萨克自治县;652223,新疆维吾尔族自治区哈密地区伊吾县;652300,新疆维吾尔族自治区昌吉回族自治州;652301,新疆维吾尔族自治区昌吉回族自治州昌吉市;652302,新疆维吾尔族自治区昌吉回族自治州阜康市;652303,新疆维吾尔族自治区昌吉回族自治州米泉市;652323,新疆维吾尔族自治区昌吉回族自治州呼图壁县;652324,新疆维吾尔族自治区昌吉回族自治州玛纳斯县;652325,新疆维吾尔族自治区昌吉回族自治州奇台县;652327,新疆维吾尔族自治区昌吉回族自治州吉木萨尔县;652328,新疆维吾尔族自治区昌吉回族自治州木垒哈萨克自治县;652700,新疆维吾尔族自治区博尔塔拉蒙古自治州;652701,新疆维吾尔族自治区博尔塔拉蒙古自治州博乐市;652722,新疆维吾尔族自治区博尔塔拉蒙古自治州精河县;652723,新疆维吾尔族自治区博尔塔拉蒙古自治州温泉县;652800,新疆维吾尔族自治区巴音郭楞蒙古自治州;652801,新疆维吾尔族自治区巴音郭楞蒙古自治州库尔勒市;652822,新疆维吾尔族自治区巴音郭楞蒙古自治州轮台县;652823,新疆维吾尔族自治区巴音郭楞蒙古自治州尉犁县;652824,新疆维吾尔族自治区巴音郭楞蒙古自治州若羌县;652825,新疆维吾尔族自治区巴音郭楞蒙古自治州且末县;652826,新疆维吾尔族自治区巴音郭楞蒙古自治州焉耆回族自治县;652827,新疆维吾尔族自治区巴音郭楞蒙古自治州和静县;652828,新疆维吾尔族自治区巴音郭楞蒙古自治州和硕县;652829,新疆维吾尔族自治区巴音郭楞蒙古自治州博湖县;652900,新疆维吾尔族自治区阿克苏地区;652901,新疆维吾尔族自治区阿克苏地区阿克苏市;652922,新疆维吾尔族自治区阿克苏地区温宿县;652923,新疆维吾尔族自治区阿克苏地区库车县;652924,新疆维吾尔族自治区阿克苏地区沙雅县;652925,新疆维吾尔族自治区阿克苏地区新和县;652926,新疆维吾尔族自治区阿克苏地区拜城县;652927,新疆维吾尔族自治区阿克苏地区乌什县;652928,新疆维吾尔族自治区阿克苏地区阿瓦提县;652929,新疆维吾尔族自治区阿克苏地区柯坪县;653000,新疆维吾尔族自治区克孜勒苏柯尔克孜自治州;653001,新疆维吾尔族自治区克孜勒苏柯尔克孜自治州阿图什市;653022,新疆维吾尔族自治区克孜勒苏柯尔克孜自治州阿克陶县;653023,新疆维吾尔族自治区克孜勒苏柯尔克孜自治州阿合奇县;653024,新疆维吾尔族自治区克孜勒苏柯尔克孜自治州乌恰县;653100,新疆维吾尔族自治区喀什地区;653101,新疆维吾尔族自治区喀什地区喀什市;653121,新疆维吾尔族自治区喀什地区疏附县;653122,新疆维吾尔族自治区喀什地区疏勒县;653123,新疆维吾尔族自治区喀什地区英吉沙县;653124,新疆维吾尔族自治区喀什地区泽普县;653125,新疆维吾尔族自治区喀什地区莎车县;653126,新疆维吾尔族自治区喀什地区叶城县;653127,新疆维吾尔族自治区喀什地区麦盖提县;653128,新疆维吾尔族自治区喀什地区岳普湖县;653129,新疆维吾尔族自治区喀什地区伽师县;653130,新疆维吾尔族自治区喀什地区巴楚县;653131,新疆维吾尔族自治区喀什地区塔什库尔干塔吉克自治县;653200,新疆维吾尔族自治区和田地区;653201,新疆维吾尔族自治区和田地区和田市;653221,新疆维吾尔族自治区和田地区和田县;653222,新疆维吾尔族自治区和田地区墨玉县;653223,新疆维吾尔族自治区和田地区皮山县;653224,新疆维吾尔族自治区和田地区洛浦县;653225,新疆维吾尔族自治区和田地区策勒县;653226,新疆维吾尔族自治区和田地区于田县;653227,新疆维吾尔族自治区和田地区民丰县;654000,新疆维吾尔族自治区伊犁哈萨克自治州;654001,新疆维吾尔族自治区伊犁哈萨克自治州奎屯市;654100,新疆维吾尔族自治区伊犁哈萨克自治州伊犁地区;654101,新疆维吾尔族自治区伊犁哈萨克自治州伊宁市;654121,新疆维吾尔族自治区伊犁哈萨克自治州伊宁县;654122,新疆自治区伊犁哈萨克自治州察布查尔锡伯自治县;654123,新疆维吾尔族自治区伊犁哈萨克自治州霍城县;654124,新疆维吾尔族自治区伊犁哈萨克自治州巩留县;654125,新疆维吾尔族自治区伊犁哈萨克自治州新源县;654126,新疆维吾尔族自治区伊犁哈萨克自治州昭苏县;654127,新疆维吾尔族自治区伊犁哈萨克自治州特克斯县;654128,新疆维吾尔族自治区伊犁哈萨克自治州尼勒克县;654200,新疆维吾尔族自治区塔城地区;654201,新疆维吾尔族自治区塔城地区塔城市;654202,新疆维吾尔族自治区塔城地区乌苏市;654221,新疆维吾尔族自治区塔城地区额敏县;654223,新疆维吾尔族自治区塔城地区沙湾县;654224,新疆维吾尔族自治区塔城地区托里县;654225,新疆维吾尔族自治区塔城地区裕民县;654226,新疆维吾尔族自治区塔城地区和布克赛尔蒙古自治县;654300,新疆维吾尔族自治区阿勒泰地区;654301,新疆维吾尔族自治区阿勒泰地区阿勒泰市;654321,新疆维吾尔族自治区阿勒泰地区布尔津县;654322,新疆维吾尔族自治区阿勒泰地区富蕴县;654323,新疆维吾尔族自治区阿勒泰地区福海县;654324,新疆维吾尔族自治区阿勒泰地区哈巴河县;654325,新疆维吾尔族自治区阿勒泰地区青河县;654326,新疆维吾尔族自治区阿勒泰地区吉木乃县;659000,新疆维吾尔族自治区直辖县级行政单位;659001,新疆维吾尔族自治区石河子市;";
            string TempAreaNorm = AreaNorm.Substring(AreaNorm.Replace(AreaStr, "逇").IndexOf('逇') + 7);
            string AreaResultStr = TempAreaNorm.Substring(0, TempAreaNorm.IndexOf(';'));
            ResultList.Add("籍贯：" + AreaResultStr);
            if (AreaResultStr == "")
            {
                return "身份证号码不合法";
            }
            string ResultStr = "";
            foreach (string item in ResultList)
            {
                ResultStr += item + ";";
            }
            return ResultStr;
        }
        #endregion

        #endregion

        #region 投诉建议
        /// <summary>
        /// 投诉跟进分部视图
        /// </summary>
        /// <returns></returns>
        public ActionResult CompainPView()
        {
            return PartialView();
        }

        /// <summary>
        /// 根据条件查询投诉信息
        /// </summary>
        /// <param name="CBName">投诉住户名</param>
        /// <param name="CRemark">投诉状态-受理待处理 处理待反馈 需再处理 归档</param>
        /// <returns></returns>
        public string GetComplainsByConditions(string PlotName = "", string BulidName = "", string HouseNumber = "", string HostName = "", string CRemark = "")
        {
            return ApiResult.GetAPIResult("GetComplainsByConditions?PlotName=" + PlotName + "&BulidName=" + BulidName + "&HouseNumber=" + HouseNumber + "&HostName=" + HostName + "&CRemark=" + CRemark + "", "get");
        }

        /// <summary>
        /// 根据房屋信息获取住户
        /// </summary>
        /// <param name="PlotName">区域</param>
        /// <param name="BulidName">单元</param>
        /// <param name="HouseNumber">房屋</param>
        /// <returns></returns>
        public string GetHostInfosByHouseInfo(string PlotName, string BulidName, string HouseNumber)
        {
            return ApiResult.GetAPIResult("GetHostInfosByHouseInfo?PlotName=" + PlotName + "&BulidName=" + BulidName + "&HouseNumber=" + HouseNumber + "", "get");
        }

        /// <summary>
        /// 获取所有员工
        /// </summary>
        /// <returns></returns>
        public string GetEmployees()
        {
            return ApiResult.GetAPIResult("GetEmployees", "get");
        }

        /// <summary>
        /// 添加投诉信息
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public string AddComplain(string CBName, string ReceptionEmp, string Ccontent)
        {
            return ApiResult.GetAPIResult("AddComplain?CBName=" + CBName + "&ReceptionEmp=" + ReceptionEmp + "&Ccontent=" + Ccontent + "", "post");
        }

        /// <summary> 
        /// 投诉跟进
        /// </summary>
        /// <param name="CSId">投诉记录Id</param>
        /// <param name="Ccontent">投诉详情</param>
        /// <param name="CRemark">投诉状态</param>
        /// <returns></returns>
        public string FollowComplain(string CSId, string Ccontent, string CRemark)
        {
            return ApiResult.GetAPIResult("FollowComplain?CSId=" + CSId + "&Ccontent=" + Ccontent + "&CRemark=" + CRemark + "", "put");
        }

        /// <summary>
        /// 历史投诉分部视图
        /// </summary>
        /// <returns></returns>
        public ActionResult HistoryCompainPView()
        {
            return PartialView();
        }
        #endregion

        #endregion
    }
}