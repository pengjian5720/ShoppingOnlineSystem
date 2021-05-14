using ShoppingOnline.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingOnline.Admin
{
    public partial class GoodsSort : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            string sql = "select * from tb_sort";
            DataSet ds = SqlHelper.ExecDataSet(sql);

            GVgoodsSort.DataSource = ds.Tables[0];
            GVgoodsSort.DataBind();
        }

        //点击跳转到添加商品分类界面
        protected void AddSorts_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AddGoodsSort.aspx");
        }

        //分业功能
        protected void GVgoodsSort_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVgoodsSort.PageIndex = e.NewPageIndex;
            BindData();
        }
        //编辑事件启动
        protected void GVgoodsSort_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVgoodsSort.EditIndex = e.NewEditIndex;
            BindData();
        }

        //编辑-编辑事件
        protected void GVgoodsSort_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //取得编辑行的关键字段的值
            int sortId = (int)GVgoodsSort.DataKeys[e.RowIndex].Value;
            //取得文本框输入内容
            string sortName = (GVgoodsSort.Rows[e.RowIndex].FindControl("Goodssort") as TextBox).Text;
            //sql语句
            string sql = "update tb_sort set sortname='" + sortName + "'where sortid='" + sortId + "' ";
            int updata = SqlHelper.ExecNonQuery(sql);
            if (updata > 0)
            {
                Response.Write("<script language=javascript>alert('修改成功！')</script>");
                //取消编辑
                GVgoodsSort.EditIndex = -1;
                BindData();

            }
            else
            {
                Response.Write("<script language=javascript>alert('修改失败！')</script>");
            }
        }
        //取消-编辑事件
        protected void GVgoodsSort_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVgoodsSort.EditIndex = -1;
            BindData();
        }

        //删除-编辑事件
        protected void GVgoodsSort_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sql = "delete from tb_sort where sortid='" + (int)GVgoodsSort.DataKeys[e.RowIndex].Value + "'";
            int delete = SqlHelper.ExecNonQuery(sql);
            if (delete > 0)
            {
                Response.Write("<script language=javascript>alert('删除成功！')</script>");
                BindData();
            }
            else
            {
                Response.Write("<script language=javascript>alert('删除失败！')</script>");

            }
        }

        //删除事件提示


        protected void GVgoodsSort_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton link = e.Row.FindControl("LBdel") as LinkButton;
                link.Attributes.Add("onclick", "return confirm('请谨慎操作！')");
            }
        }
    }
}
