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
        private static string u_ID = "", u_Shop = "";
        public static string w_Path, w_Title, w_Price, w_Type, w_Info, w_Count;

        protected void rptAbout_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

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

                        strsql = "select * from tb_goods where goodsid=" + w_ID;
                        DataTable dt = SqlHelper.ExecDataSet(strsql).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            w_Path = dt.Rows[0]["goodspicture"].ToString().Substring(3);
                            w_Title = dt.Rows[0]["goodsname"].ToString();
                            w_Price = dt.Rows[0]["goodsprice"].ToString();
                            w_Type = dt.Rows[0]["sortid"].ToString();
                            w_Info = dt.Rows[0]["goodsdescribe"].ToString();
                            w_Count = dt.Rows[0]["goodsstock"].ToString();
                        }
                        else
                        {
                            Response.Redirect("Index.aspx");
                            return;
                        }

                        string strrpt = "select top 3 * from tb_goods where sortid=(select sortid from tb_sort WHERE sortname='" + w_Type + "') and goodsid=" + w_ID;
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
                string strsel = "select * from bt_user where userid=" + u_ID;
                DataTable dtsel = SqlHelper.ExecDataSet(strsel).Tables[0];
                if (dtsel.Rows.Count > 0)
                {
                    u_Shop = dtsel.Rows[0]["userShopCart"].ToString();
                }
                if (u_Shop.Equals(""))
                {
                    u_Shop = w_ID + ",1000,";
                }
                else
                {
                    string[] stru_s = u_Shop.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int i;
                    for (i = 0; i < stru_s.Length; i++)
                    {
                        if (w_ID == stru_s[i])
                        {
                            int count = Convert.ToInt32(stru_s[i + 1]);
                            count += 1000;
                            stru_s[i + 1] = count.ToString();
                            break;
                        }
                    }
                    u_Shop = "";
                    foreach (string s in stru_s)
                    {
                        u_Shop += s + ",";
                    }
                    if (i == stru_s.Length)
                    {
                        u_Shop += w_ID + "," + "1000" + ",";
                    }
                }
                string strudp = "update Db_User set userShopCart=@shop where ID=@id";
                SqlParameter[] paras = {
                                         new SqlParameter("@shop",u_Shop),
                                         new SqlParameter("@id",u_ID)
                                     };
                int flag = SqlHelper.ExecNonQuery(strudp, paras);
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
                Response.Write("<script>alert('您还未登录，请登录后再进行购物！');window.location='userLogin.aspx';</script>");
                return;
            }
        }
    }
}