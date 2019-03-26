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

        #region Ա������
        /// <summary>
        /// Ա����ʾ����ѯ
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
        /// Ա�����
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int AddEmp(Employee employee)
        {
            return DBHelper.ExecuteNonQuery($"insert into Employee values('{employee.EName}','{employee.ESex}','{employee.EAge}','{employee.ESalary}','{employee.EStartTime}','{employee.DId}')");
        }
        /// <summary>
        /// ����ID��ȡEmp����
        /// </summary>
        /// <param name="EId"></param>
        /// <returns></returns>
        public Employee GetEmployeeByEId(int EId)
        {
            return JsonConvert.DeserializeObject<List<Employee>>(JsonConvert.SerializeObject(DBHelper.GetDataTable("select * from Employee where EmployeeId=" + EId)))[0];
        }
        /// <summary>
        /// �޸�Ա��
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int PutEmpByEId(Employee employee)
        {
            return DBHelper.ExecuteNonQuery($"updata Employee set EName='{employee.EName}' and ESex='{employee.ESex}' and EAge='{employee.EAge}' and ESalary='{employee.ESalary}' and EStartTime='{employee.EStartTime}' and DId='{employee.DId}' where EmployeeId={employee.EmployeeId}");
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int DelEmpByEId(int EmployeeId)
        {
            return DBHelper.ExecuteNonQuery("delete from Employee where EmployeeId=" + EmployeeId);
        }

        #endregion

        #region ���޹���
        /// <summary>
        /// ��ӱ��޵���
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        public int AddRepair(Repair repair)
        {
            int n = DBHelper.ExecuteNonQuery($"insert into Repair values('{repair.HostName}','{repair.HouseId}','{repair.ReNumber}','{repair.MaintainName}','{repair.RSTime}','{repair.MaintainTime}','{repair.ServePrice}','{repair.GoodsPrice}','{repair.PriceSum}','{repair.Estimate}','{repair.ReRemark}')");
            if (n > 0)
            {
                n += DBHelper.ExecuteNonQuery("update HouseInfo set HouseState='����' where HouseId=" + repair.HouseId);
            }
            return n;
        }
        /// <summary>
        /// ������ϸ
        /// </summary>
        /// <returns></returns>
        public List<Repair> GetRepairs(int lx)
        {
            string sql = "select * from repair where 1=1 ";
            if (lx == 1)
            {
                sql += " and Estimate = '��δ���'";
            }
            else if (lx == 2)
            {
                sql += " and Estimate = '�������'";
            }
            else if (lx == 3)
            {
                sql += " and Estimate = '�ȴ����'";
            }
            else if (lx == 4)
            {
                sql += " and Estimate = '����覴�'";
            }
            sql += " order by RepairId desc";
            return JsonConvert.DeserializeObject<List<Repair>>(JsonConvert.SerializeObject(DBHelper.GetDataTable(sql)));
        }
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="PlotName"></param>
        /// <param name="BulidName"></param>
        /// <param name="HouseNumber"></param>
        /// <returns></returns>
        public string GetHouseInfoByHouse(string PlotName, string BulidName, string HouseNumber)
        {
            List<HouseInfo> list = JsonConvert.DeserializeObject<List<HouseInfo>>(JsonConvert.SerializeObject(DBHelper.GetDataTable($"select * from HouseInfo where PlotName='{PlotName}' and BulidName='{BulidName}' and HouseNumber='{HouseNumber}' and HouseState!='����'")));
            if (list.Count == 0)
            {
                return "�÷���û��ס��";
            }
            else
            {
                HouseInfo house = list[0];
                List<HostInfo> listh = JsonConvert.DeserializeObject<List<HostInfo>>(JsonConvert.SerializeObject(DBHelper.GetDataTable($"select * from HostInfo where HouseId='{house.HouseId}'")));
                if (listh.Count == 0)
                {
                    return "�÷���û��ס��";
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
        /// ���ı��޵���
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

        #region �Ӵ�
        /// <summary>
        /// ��ӽӴ�����
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public int AddVisitor(Visitor visitor)
        {
            return DBHelper.ExecuteNonQuery($"insert into Visitor values('{visitor.VisitorName}','{visitor.HostName}','{visitor.StartTime}','{visitor.EndTime}')");
        }
        /// <summary>
        /// �ÿ��뿪�Ǽ�
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public int PutVisitor(Visitor visitor)
        {
            return DBHelper.ExecuteNonQuery($"update Visitor set EndTime='{visitor.EndTime}' where Visitorid={visitor.Visitorid}");
        }
        #endregion

        #region ֵ��-��

        /// <summary>
        /// ���ֵ��
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

