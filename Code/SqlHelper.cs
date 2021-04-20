using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingOnline.App_Code
{
    public class SqlHelper
    {
        private static readonly string connString = ConfigurationManager.ConnectionStrings["SqlLibraryMS"].ConnectionString;
        /// <summary>
        /// 执行增删改操作的方法
        /// </summary>
        /// <param name="sql">增删改的SQL语句  必填</param>
        /// <param name="commandParams">参数数组  选填</param>
        /// <returns></returns>
        public static int ExecNonQuery(string sql,
            params SqlParameter[] commandParams)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                PreparedCommand(sql, commandParams, conn, cmd);
                return cmd.ExecuteNonQuery();
            }
        }

        private static void PreparedCommand(string sql, SqlParameter[] commandParams, SqlConnection conn, SqlCommand cmd)
        {
            //判断数据库连接对象若不是打开状态则打开
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.CommandText = sql;//设置执行的SQL语句
            cmd.Connection = conn;//关联数据库连接对象
            if (commandParams != null)
                cmd.Parameters.AddRange(commandParams);
        }

        /// <summary>
        /// 执行查询 返回第一行第一列的数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandParams"></param>
        /// <returns>第一行第一列的数据</returns>
        public static object ExecScalar(string sql,
           params SqlParameter[] commandParams)
        {
            //自动释放资源
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                PreparedCommand(sql, commandParams, conn, cmd);

                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 查询方法  读取数据必须保存数据库连接状态
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandParams"></param>
        /// <returns>SqlDataReader对象</returns>
        public static SqlDataReader ExecDataReader(string sql, params SqlParameter[] commandParams)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            PreparedCommand(sql, commandParams, conn, cmd);

            //CommandBehavior.CloseConnection: 若dataReader对象关闭则自动关闭connection对象
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 执行查询 断开式
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commandParams"></param>
        /// <returns>DataSet对象</returns>
        public static DataSet ExecDataSet(string sql, params SqlParameter[] commandParams)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                PreparedCommand(sql, commandParams, conn, cmd);

                //创建适配器对象
                using (SqlDataAdapter dap = new SqlDataAdapter())
                {
                    dap.SelectCommand = cmd;//适配器对象关联command对象
                    DataSet ds = new DataSet();
                    dap.Fill(ds);
                    return ds;
                }
            }
        }
    }
}