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
                string strpro = "select top 8 * from Db_Prodouct order by ID desc";
                DataTable dt = OleDbHelper.GetDataTable(strpro);
                rptPro.DataSource = dt;
                rptPro.DataBind();
            }
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx?query=" + txtQuery.Text);
        }
    }
}