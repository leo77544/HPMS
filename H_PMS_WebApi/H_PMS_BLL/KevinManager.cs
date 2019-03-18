using H_PMS_DAL;
using H_PMS_Model;
using System;
using System.Collections.Generic;

namespace H_PMS_BLL
{
    public class KevinManager
    {
        KevinService service = new KevinService();

        #region Ա������
        /// <summary>
        /// Ա����ʾ����ѯ
        /// </summary>
        /// <param name="EName"></param>
        /// <param name="DId"></param>
        /// <returns></returns>
        public List<GetEmp> GetEmployees(string EName = "", int DId = -1)
        {
            return service.GetEmployees(EName,DId);
        }
        /// <summary>
        /// Ա�����
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int AddEmp(Employee employee)
        {
            return service.AddEmp(employee);
        }
        /// <summary>
        /// �޸�Ա��
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int PutEmpByEId(Employee employee)
        {
            return service.PutEmpByEId(employee);
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public int DelEmpByEId(int EmployeeId)
        {
            return service.DelEmpByEId(EmployeeId);
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
            return service.AddRepair(repair);
        }
        /// <summary>
        /// ���ı��޵���
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        public int PutRepair(Repair repair)
        {
            return service.PutRepair(repair);
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
            return service.AddVisitor(visitor);
        }
        /// <summary>
        /// �ÿ��뿪�Ǽ�
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public int PutVisitor(Visitor visitor)
        {
            return service.PutVisitor(visitor);
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
            return service.AddPatrol(patrol);
        }
        #endregion

    }
}

