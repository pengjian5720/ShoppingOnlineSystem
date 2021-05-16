using ShoppingOnline.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingOnline
{
    public partial class Signle : System.Web.UI.Page
    {
        private static string w_ID = "";
        private static string u_ID = "";
        public static string w_Path, w_Title, w_Price, w_Type, w_Info, w_Count;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    w_ID = Request.QueryString["id"].ToString();

                    string strsql = "";
                    try
                    {
                        int p = Convert.ToInt32(w_ID);

                        strsql = "select * from goodsDisplay where goodsid=" + w_ID;
                        DataTable dt = SqlHelper.ExecDataSet(strsql).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            w_Path = dt.Rows[0]["goodspicture"].ToString().Substring(3);
                            w_Title = dt.Rows[0]["goodsname"].ToString();
                            w_Price = dt.Rows[0]["goodsprice"].ToString();
                            w_Type = dt.Rows[0]["sortname"].ToString();
                            w_Info = dt.Rows[0]["goodsdescribe"].ToString();
                            w_Count = dt.Rows[0]["goodsstock"].ToString();
                        }
                        else
                        {
                            Response.Redirect("Index.aspx");
                            return;
                        }

                        string strrpt = "select top 3 * from goodsDisplay WHERE sortname='" + w_Type + "'";
                        DataTable dtrpt = SqlHelper.ExecDataSet(strrpt).Tables[0];
                        rptAbout.DataSource = dtrpt;
                        rptAbout.DataBind();
                    }
                    catch
                    {
                        Response.Redirect("Index.aspx");
                        return;
                    }

                }
                else
                {
                    Response.Redirect("Index.aspx");
                    return;
                }
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx?query=" + txtQuery.Text);
        }

        protected void btnAddShop_Click(object sender, EventArgs e)
        {
            if (w_ID == "")
            {
                Response.Redirect("Index.aspx");
                return;
            }
            if (Session["userid"] != null)
            {
                u_ID = Session["userid"].ToString();
                string g_ID=Request.QueryString["id"];
                string strsel = "select * from tb_mastercar where userid=@u_ID and goodsid=@g_ID" ;
                SqlParameter[] paras = {
                                         new SqlParameter("@u_ID",u_ID),
                                         new SqlParameter("@g_ID",g_ID)
                                     };
                DataTable dtsel = SqlHelper.ExecDataSet(strsel,paras).Tables[0];
                if (dtsel.Rows.Count == 0)
                {
                    string strudp = "insert into tb_mastercar(userid,goodsid) values(@u_ID,@g_ID)";
                    SqlParameter[] paras1 = {
                                         new SqlParameter("@u_ID",u_ID),
                                         new SqlParameter("@g_ID",g_ID)
                                     };
                    int flag = SqlHelper.ExecNonQuery(strudp, paras1);
                    if (flag > 0)
                    {
                        Response.Redirect("Check.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('添加出错，请重新加入购物车')</script>");
                        return;
                    }
                }
                else
                {
                    Response.Write("<script>alert('该商品已加入购物车，请点击购物车查看')</script>");
                    return;
                }

            }
            else
            {
                Response.Write("<script>alert('您还未登录，请登录后再进行购物！');window.location='userLogin.aspx';</script>");
                return;
            }
        }
    }
}