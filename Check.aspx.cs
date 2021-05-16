using ShoppingOnline.App_Code;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace ShoppingOnline
{
    public partial class Check : System.Web.UI.Page
    {
        private static string u_ID = "", g_ID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getMasterCar();
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            g_ID = btn.CommandArgument.ToString();
            string strudp = "delete from tb_mastercar where userid=@u_ID and goodsid=@g_ID";
            SqlParameter[] paras = 
            {
                new SqlParameter("@u_ID",u_ID),
                new SqlParameter("@g_ID",g_ID)
            };
            int flag = SqlHelper.ExecNonQuery(strudp, paras);
            if (flag > 0)
            {
                getMasterCar();
                return;
            }
            else
            {
                getMasterCar();
                Response.Write("<script>alert('删除出错，请重新加入购物车')</script>");
            }
        }


        protected void btnToOrder_Click(object sender, EventArgs e)
        {

            string oNum = "";           //订单号
            string oState = "";         //订单状态
            string oPrice = "";         //订单总价

            u_ID = Session["userid"].ToString();
            LinkButton btn = (LinkButton)sender;
            g_ID = btn.CommandArgument.ToString();
            //生成订单信息
            DateTime date = DateTime.Now;
            Random ra = new Random();
            oNum = ra.Next(100).ToString() + ra.Next(100).ToString();
            string sql1 = "select * from tb_goods where goodsid=" + g_ID;
            DataTable dt = SqlHelper.ExecDataSet(sql1).Tables[0];
            int stock = 0;
            int f_add = 0;
            if (dt.Rows.Count > 0)
            {
                DataRow dataRow = dt.Rows[0];
                oPrice = dataRow["goodsprice"].ToString();
                stock =Convert.ToInt32(dataRow["goodsprice"]);
            }
            oState = "正在配送";
            if (stock > 0)
            {
                string strAdd = "insert into tb_order(orderid,ordertime,ordermoney,orderstates,userid,goodsid) values(@orderid,@ordertime,@ordermoney,@orderstates,@userid,@goodsid)";
                SqlParameter[] parasadd = 
                {
                    new SqlParameter("@orderid",oNum),
                    new SqlParameter("@ordertime",date.ToShortDateString().ToString()),
                    new SqlParameter("@ordermoney",oPrice),
                    new SqlParameter("@orderstates",oState),
                    new SqlParameter("@userid",u_ID),
                    new SqlParameter("@goodsid",g_ID)
                };
                f_add = SqlHelper.ExecNonQuery(strAdd, parasadd);
            }
            else
            {
                Response.Write("<script>alert('暂时缺货，请联系店长');</script>");
            }
            if (f_add > 0)
            {
                DataRow dataRow = dt.Rows[0];
                int a = Convert.ToInt32(dataRow["goodsstock"]);
                if (a > 0)
                {
                    a--;
                    string updateNum = "update tb_goods set goodsstock=@a where goodsid=@g_ID ";
                    SqlParameter[] sql3 =
                    {
                        new SqlParameter("@a",a),
                        new SqlParameter("@g_ID",g_ID)
                    };
                    SqlHelper.ExecNonQuery(updateNum,sql3);
                    getMasterCar();
                    Response.Write("<script>alert('购买成功，请单击“订单”查看详细信息');</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('购买出错，请重新下订单')</script>");
                return;
            }
        }
        private void getMasterCar()
        {
            if (Session["userid"] != null)
            {
                StringBuilder listString = new StringBuilder();
                u_ID = Session["userid"].ToString();
                string struser = "select goodsid,goodsname,goodspicture,goodsprice from mastercarList where userid=@u_ID";
                SqlParameter[] paras = 
                {
                    new SqlParameter("@u_ID",u_ID),
                };
                DataTable dataTable = SqlHelper.ExecDataSet(struser,paras).Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    rptbind.DataSource = dataTable;
                    rptbind.DataBind();
                }
            }
            else
            {
                Response.Redirect("userLogin.aspx");
            }
        }
    }
}