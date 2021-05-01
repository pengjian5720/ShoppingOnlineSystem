using ShoppingOnline.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingOnline.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //返回按钮
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProdouctList.aspx");
        }
        //添加商品
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string sql2 = "insert into tb_goods(goodsname,goodsprice,goodsdescribe,goodscreatetime,goodsishost,sortid,goodsstock,goodspicture)" +
              " values(@goodsname,@goodsprice,@goodsdescribe,@goodscreatetime,@goodsishost,@sortid,@goodsstock,@goodspicture)";
            SqlParameter[] spt =
            {
                new SqlParameter("@goodsname", txtbgoodsname.Text),
                new SqlParameter("@goodsprice", txtbprice.Text),
                new SqlParameter("@goodsdescribe", txtbdescribe.Text),
                new SqlParameter("@goodscreatetime", txtbcreatetime.Text),
                new SqlParameter("@goodsishost", txtbishost.Text),
                new SqlParameter("@sortid",txtbsortid.Text),
                new SqlParameter("@goodsstock", txtbstock.Text),
                new SqlParameter("@goodspicture", txtbpicture.Text)
             };
            if (SqlHelper.ExecNonQuery(sql2, spt) > 0)
            {
                //Response.Redirect("ProdouctList.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('商品添加成功！');window.location.href='ProdouctList.aspx';", true);
            }
            else
            {
                Response.Write("<script>alert('商品添加失败')</script>");
            }
        }
    }
}