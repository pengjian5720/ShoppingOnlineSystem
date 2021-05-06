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
    public partial class UserReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void btnReg_Click(object sender, EventArgs e)
        {

            if (txtPassword.Text != txtRePassword.Text)
            {
                Response.Write("<script>alert('两次密码不一致！请重新输入')</script>");
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtAdress.Text))
            {
                Response.Write("<script>alert('用户名，密码或地址不能为空。')</script>");
                return;
            }

            string checksql = "select count(*) from tb_user where nsername=@username";
            int count =  Convert.ToInt32(SqlHelper.ExecScalar(checksql, new SqlParameter("@username", txtName.Text)));
            if (count >= 1)
            {
                Response.Write("<script>alert('已存在此用户名，请重新输入用户名！')</script>");
                txtName.Text = "";
                return;
            }
            else
            {
                DateTime createDate = DateTime.Now;
                string txtSex = "";
                if (rbtnMan.Checked == true)
                    txtSex = "男性";
                else
                    txtSex = "女性";
                string sql = "insert into tb_user(username,userpassword,sex,name,address,telephone)values(@username,@password,@usersex,@usercreatedate," +
                    "@useremail,@useradress,@usermobile)";
                SqlParameter[] paras = {
                                            new SqlParameter("@username", txtName.Text),
                                            new SqlParameter("@password", CommonHelper.GetMD5(txtPassword.Text+CommonHelper.GetPawSalt())),
                                            new SqlParameter("@usersex", txtSex),
                                            new SqlParameter("@usercreatedate", createDate.ToShortDateString()),
                                            new SqlParameter("@useremail",txtEmail.Text),
                                            new SqlParameter("@useradress",txtAdress.Text),
                                            new SqlParameter("@usermobile",txtMobile.Text)
                                     };
                int i = SqlHelper.ExecNonQuery(sql, paras);
                if (i == 1)
                {
                    string str = "select * from Db_User where userName=@username";
                    DataTable dt = SqlHelper.ExecDataSet(str, new SqlParameter("@username", txtName.Text)).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Session["usname"] = dt.Rows[0]["userName"].ToString();
                        Session["userid"] = dt.Rows[0]["ID"].ToString();
                    }
                    Response.Write("<script>alert('注册成功！');window.location='Index.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('注册失败')</script>");
                    return;
                }
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtAdress.Text = "";
        }
    }
}