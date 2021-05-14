using ShoppingOnline.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingOnline.Admin
{
    public partial class AddGoodsSort : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void B_sub_Click(object sender, EventArgs e)
        {
            string sort = this.TBaddSort.Text;

            if (!sort.Equals(""))
            {
                string sql = "insert into tb_sort (sortname) values('" + sort + "')";
                int ins = SqlHelper.ExecNonQuery(sql);
                if (ins > 0)
                {
                    Response.Write("<script language=javascript>alert('添加成功！')</script>");

                }
                else
                {
                    Response.Write("<script language=javascript>alert('添加失败！')</script>");
                }
            }
            else
            {
                Response.Write("<script language=javascript>alert('不能为空！')</script>");
            }
        }

        //取消
        protected void B_Can_Click(object sender, EventArgs e)
        {
            this.TBaddSort.Text = null;
        }

        //返回
        protected void B_Ret_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/GoodsSort.aspx");
        }
    }
}