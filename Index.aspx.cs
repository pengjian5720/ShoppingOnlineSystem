using ShoppingOnline.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingOnline
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strpro = "select top 4 * from tb_goods order by goodsid desc";
                DataTable dt = SqlHelper.ExecDataSet(strpro).Tables[0];
                rptPro.DataSource = dt;
                rptPro.DataBind();


            }
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx?query=" + txtQuery.Text);
        }

        protected void rptPro_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}