using ShoppingOnline.App_Code;
using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace ShoppingOnline
{
    public partial class UserLogin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                Response.Write("<script>alert('用户名或密码不能为空！')</script>");
                return;
            }

            string checksql = "select * from tb_user where userName=@username and userpassWord=@password";
            SqlParameter[] paras = {
                                    new SqlParameter("@username", txtName.Text),
                                    new SqlParameter("@password",txtPassword.Text)
                                 };
            DataTable dt =SqlHelper.ExecDataSet(checksql,paras).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Session["usname"] = dt.Rows[0]["username"].ToString();
                Session["userid"] = dt.Rows[0]["userid"].ToString();
                Response.Write("<script>alert('登录成功')</script>");
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Write("<script>alert('账户或密码错误')</script>");
                return;
            }
        }
    }
}