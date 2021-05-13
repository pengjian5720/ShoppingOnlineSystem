using ShoppingOnline.App_Code;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ShoppingOnline
{
    public partial class Order : System.Web.UI.Page
    {
        private static string u_ID = "";
        public int num = 0, sum = 0;
        Button btn = new Button();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getOrders();
            }
        }
        private void getOrders()
        {
            if (Session["userid"] != null)
            {
                u_ID = Session["userid"].ToString();
                string sql = "select orderid,goodsname,ordertime,ordermoney,orderstates,tb_order.goodsid from tb_order left join tb_goods on (userid=@userid and tb_order.goodsid=tb_goods.goodsid)";
                SqlParameter[] sqlParameter =
                {
                    new SqlParameter("@userid",u_ID)
                };
                DataTable dt = SqlHelper.ExecDataSet(sql,sqlParameter).Tables[0];
                dt.Columns.Add("btnText", Type.GetType("System.String"));
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!dt.Rows[i]["orderstates"].ToString().Equals("已收货"))
                    {
                        dt.Rows[i]["btnText"] = "确认收货";
                    }
                }
                PagedDataSource pds = new PagedDataSource();
                pds.PageSize = AspNetPager1.PageSize;
                pds.AllowPaging = true;
                pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
                AspNetPager1.RecordCount = dt.Rows.Count;
                int pagecount = AspNetPager1.PageCount;
                DataView dv = dt.DefaultView;
                pds.DataSource = dv;
                rptbind.DataSource=dt;
                rptbind.DataBind();                
            }
            else
            {
                Response.Redirect("userLogin.aspx");
            }
        }
        protected void btnMake_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "确认收货")
            {
                string strsel = "update tb_order set orderstates='已收货' where orderid=" + btn.CommandArgument.ToString();
                int flag = SqlHelper.ExecNonQuery(strsel);
                if (flag > 0)
                {
                    btn.Visible = false;
                    getOrders();
                }
                else
                {
                    Response.Write("<script>alert('功能失效，请重新点击！')</script>");
                    return;
                }
            }
            
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            getOrders();
        }
    }
}