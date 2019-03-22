using System;
using System.Collections.Generic;
using H_PMS_DAL;
using H_PMS_Model;


namespace H_PMS_BLL
{
    public class MichaelManager
    {
        MichaelService MDAL = new MichaelService();

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
        public List<HouseInfo> GetHouseInfosByConditions(string PlotName = "", string BulidName = "", string HouseType = "", string HouseArea = "", string HouseState = "")
        {
            return MDAL.GetHouseInfosByConditions(PlotName, BulidName, HouseType, HouseArea, HouseState);
        }

        /// <summary>
        /// 修改房屋状态
        /// </summary>
        /// <param name="HouseId">房屋Id</param>
        /// <param name="HouseState">房屋状态</param>
        /// <returns></returns>
        public int ChangeHouseState(int HouseId, string HouseState)
        {
            return MDAL.ChangeHouseState(HouseId, HouseState);
        }

        /// <summary>
        /// 住户登记 房主、家庭成员、房客、访客
        /// </summary>
        /// <param name="TheHost"></param>
        /// <returns></returns>
        public int HostRegister(string HostName, string HostPhone, string IDCard, string Role, int HouseId)
        {
            return MDAL.HostRegister(HostName, HostPhone, IDCard, Role, HouseId);
        }

        /// <summary>
        /// 住户查询
        /// </summary>
        /// <param name="HouseId">房屋Id</param>
        /// <param name="HostName">住户姓名</param>
        /// <returns></returns>
        public List<HostInfo> GetHostInfosByConditions(int HouseId = 0, string HostName = "")
        {
            return MDAL.GetHostInfosByConditions(HouseId, HostName);
        }
        #endregion

        #region 投诉建议
        /// <summary>
        /// 根据条件查询投诉信息
        /// </summary>
        /// <param name="CBName">投诉住户名</param>
        /// <param name="CRemark">投诉状态-受理待处理 处理待反馈 需再处理 归档</param>
        /// <returns></returns>
        public List<Complain> GetComplainsByConditions(string CBName = "", string CRemark = "")
        {
            return MDAL.GetComplainsByConditions(CBName, CRemark);
        }

        /// <summary>
        /// 添加投诉信息
        /// </summary>
        /// <param name="TheComplain"></param>
        /// <returns></returns>
        public int AddComplain(Complain TheComplain)
        {
            return MDAL.AddComplain(TheComplain);
        }

        /// <summary> 
        /// 投诉跟进
        /// </summary>
        /// <param name="CSId">投诉记录Id</param>
        /// <param name="Ccontent">投诉详情</param>
        /// <param name="CRemark">投诉状态</param>
        /// <returns></returns>
        public int FollowComplain(int CSId, string Ccontent, string CRemark)
        {
            return MDAL.FollowComplain(CSId, Ccontent, CRemark);
        }
        #endregion
    }
}

