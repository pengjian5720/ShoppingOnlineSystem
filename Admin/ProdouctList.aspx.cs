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
    public partial class ProdouctList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GvBindProduct();//绑定数据
            }
        }
        //绑定数据
        private void GvBindProduct()
        {
            string sql = "select * from tb_goods";
            DataSet ds = SqlHelper.ExecDataSet(sql);
            gdview.DataSource = ds;
            //给控件添加主键字段
            this.gdview.DataKeyNames = new string[] { "goodsid" };
            gdview.DataBind();
        }
        //分页触发事件
        protected void gdview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gdview.PageIndex = e.NewPageIndex;//设置新页码
            GvBindProduct();
        }
        //删除事件
        protected void gdview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //获取当前行主键
            string goodsid = gdview.DataKeys[e.RowIndex].Value.ToString();
            string sql = "delete from tb_goods where goodsid='" + goodsid + "'";
            SqlHelper.ExecNonQuery(sql);
            GvBindProduct();
        }
        //数据行绑定事件
        protected void gdview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = e.Row.FindControl("LinkButton1") as LinkButton;
                lnk.Attributes.Add("onclick", "return confirm('您确定要删除吗？')");
            }
        }
        //搜索商品
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from tb_goods where goodsname like '%" + txtbname.Text + "%'";
            DataSet ds = SqlHelper.ExecDataSet(sql);
            gdview.DataSource = ds.Tables[0];
            gdview.DataBind();
        }

        protected void linbtAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }
    }
}