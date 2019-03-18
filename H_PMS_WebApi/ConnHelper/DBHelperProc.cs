using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConnHelper
{
    public class DBHelperProc
    {

        public static string strCon = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public static SqlConnection cnn = new SqlConnection(strCon);

        /// <summary>
        /// 执行增删改的操作
        /// </summary>
        /// <param name="sql">sql命令</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sql)
        {
            Open();
            SqlCommand command = new SqlCommand(sql, cnn);
            int result = command.ExecuteNonQuery();
            cnn.Close();
            return result;
        }
        /// <summary>
        /// 查询单个值-返回首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)
        {
            Open();
            SqlCommand command = new SqlCommand(sql, cnn);
            object result = command.ExecuteScalar();
            cnn.Close();
            return result;
        }
        /// <summary>
        /// 返回数据表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// 返回DataReader对象，使用结束后，勿忘关闭DataReader与数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetDataReader(string sql)
        {
            Open();
            SqlCommand command = new SqlCommand(sql, cnn);
            return command.ExecuteReader();
        }
        /// <summary>
        /// 打开数据库
        /// </summary>
        public static void Open()
        {
            if (cnn.State == ConnectionState.Broken || cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
            cnn.Open();
        }

        /// <summary>
        /// 打开数据库
        /// </summary>
        public static void Close()
        {
            cnn.Close();
        }

        /// <summary>
        /// 使用存储过程查询数据结果
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string procName, SqlParameter[] paras = null)
        {
            Open();
            SqlCommand command = new SqlCommand(procName, cnn);
            command.CommandType = CommandType.StoredProcedure;

            if (paras != null)
            {
                command.Parameters.AddRange(paras);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            Close();
            return ds.Tables[0];
        }

        /// <summary>
        /// 使用存储过程执行增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string procName, SqlParameter[] paras)
        {
            Open();
            SqlCommand command = new SqlCommand(procName, cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(paras);

            int result = command.ExecuteNonQuery();
            Close();

            return result;


        }
    }
}