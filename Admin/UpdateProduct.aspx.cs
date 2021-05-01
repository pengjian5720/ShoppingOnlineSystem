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
    public partial class UpdateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowProductList();
            }

        }
        //返回按钮
        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProdouctList.aspx");
        }
        private void ShowProductList()
        {
            string goodsid = "";
            if (Request.QueryString["goodsid"] != null)
            {
                goodsid = Request.QueryString["goodsid"].ToString();
            }
            string sql = "select * from tb_goods where goodsid=@goodsid";
            SqlParameter[] pars =
            {
                new SqlParameter("@goodsid",goodsid)
             };
            //执行查询并返回dataread对象
            SqlDataReader dar = SqlHelper.ExecDataReader(sql, pars);
            if (dar.Read())//读取下一条记录
            {
                this.txtbgoodsid.Text = dar["goodsid"].ToString();
                this.txtbgoodsname.Text = dar["goodsname"].ToString();
                this.txtbprice.Text = dar["goodsprice"].ToString();
                this.txtbdescribe.Text = dar["goodsdescribe"].ToString();
                this.txtbcreatetime.Text = dar["goodscreatetime"].ToString();
                this.txtbishost.Text = dar["goodsishost"].ToString();
                this.txtbsortid.Text = dar["sortid"].ToString();
                this.txtbstock.Text = dar["goodsstock"].ToString();
                this.txtbpicture.Text = dar["goodspicture"].ToString();
            }
        }
        //修改商品信息
        protected void btnChange_Click(object sender, EventArgs e)
        {
            string sql = "update tb_goods set goodsname=@goodsname,goodsprice=@goodsprice,goodsdescribe=@goodsdescribe," +
                "goodscreatetime=@goodscreatetime,goodsishost=@goodsishost,sortid=@sortid,goodsstock=@goodsstock,goodspicture=@goodspicture where goodsid=@goodsid";
            SqlParameter[] spt =
             {
                 new SqlParameter("@goodsname", txtbgoodsname.Text),
                 new SqlParameter("@goodsprice", txtbprice.Text),
                 new SqlParameter("@goodsdescribe",txtbdescribe.Text),
                 new SqlParameter("@goodscreatetime", txtbcreatetime.Text),
                 new SqlParameter("@goodsishost",txtbishost.Text),
                 new SqlParameter("@sortid", txtbsortid.Text),
                 new SqlParameter("@goodsstock", txtbstock.Text),
                 new SqlParameter("@goodspicture", txtbpicture.Text),
                 new SqlParameter("@goodsid", txtbgoodsid.Text)
             };
            if (SqlHelper.ExecNonQuery(sql, spt) > 0)
            {
                //Response.Redirect("ProdouctList.aspx");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('商品信息修改成功！');window.location.href='ProdouctList.aspx';", true);
            }
            else
            {
                Response.Write("<script>alert('修改失败')</ Script>");
            }
        }
    }
}