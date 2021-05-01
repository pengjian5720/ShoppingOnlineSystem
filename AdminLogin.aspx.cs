using ShoppingOnline.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingOnline
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["username"] = "";
                Session["password"] = "";
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().ToString() == "" || txtPasswd.Text.Trim().ToString() == "")
            {
                Response.Write("<script>alert('请填写必要内容！')</script>");
                return;
            }
            string selcmdstr = "select * from tb_manager where managername=@name";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@name",txtName.Text.ToString())
            };
            DataTable dt = SqlHelper.ExecDataSet(selcmdstr, sqlParameter).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string password = txtPasswd.Text.ToString().Trim();
                if (password == dt.Rows[0]["managerpassword"].ToString())
                {
                    Session["username"] = txtName.Text.Trim().ToString();
                    Session["password"] = txtPasswd.Text.Trim().ToString();
                    Response.Redirect("~/Admin/index.aspx");
                }
                else
                {
                    Response.Write("<script>alert('密码错误！')</script>");
                    return;
                }
            }
            else
            {
                Response.Write("<script>alert('不存在此用户')</script>");
                return;
            }
        }


    }
}