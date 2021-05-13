using ShoppingOnline.App_Code;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ShoppingOnline
{
    public partial class Product : System.Web.UI.Page
    {
        public static string quming = "装饰摆饰";
        public static string query = "";
        public static string[] state = new string[6];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["item"] != null)
                {
                    quming = Request.QueryString["item"].ToString();

                    switch (quming)
                    {
                        case "装饰摆饰":
                            state[0] = "active";
                            state[1] = "grid";
                            state[2] = "grid";
                            state[3] = "grid";
                            state[4] = "grid";
                            state[5] = "grid";
                            break;
                        case "厨房餐饮":
                            state[0] = "grid";
                            state[1] = "active";
                            state[2] = "grid";
                            state[3] = "grid";
                            state[4] = "grid";
                            state[5] = "grid";
                            break;
                        case "办公文具":
                            state[0] = "grid";
                            state[1] = "grid";
                            state[2] = "active";
                            state[3] = "grid";
                            state[4] = "grid";
                            state[5] = "grid";
                            break;
                        case "玩具娱乐":
                            state[0] = "grid";
                            state[1] = "grid";
                            state[2] = "grid";
                            state[3] = "active";
                            state[4] = "grid";
                            state[5] = "grid";
                            break;
                        case "智能科技":
                            state[0] = "grid";
                            state[1] = "grid";
                            state[2] = "grid";
                            state[3] = "grid";
                            state[4] = "active";
                            state[5] = "grid";
                            break;
                        case "全部":
                            state[0] = "grid";
                            state[1] = "grid";
                            state[2] = "grid";
                            state[3] = "grid";
                            state[4] = "grid";
                            state[5] = "active";
                            break;
                        default:
                            state[0] = "grid";
                            state[1] = "grid";
                            state[2] = "grid";
                            state[3] = "active";
                            break;
                    }
                    string strsql;
                    if (!quming.Equals("全部"))
                        strsql = "select * from tb_goods where sortid =(select sortid from tb_sort WHERE sortname='"+ quming+"') order by goodsid desc";
                        
                    else
                        strsql = "select * from tb_goods order by goodsid desc";

                    DataTable dt = new DataTable();
                    dt = SqlHelper.ExecDataSet(strsql).Tables[0];
                    GetRptBind(dt);
                }
                else if (Request.QueryString["query"] != null)
                {
                    query = Request.QueryString["query"].ToString();
                    quming = "全部";
                    state[0] = "grid";
                    state[1] = "grid";
                    state[2] = "grid";
                    state[3] = "active";
                    string strquery = "select * from tb_goods where goodsname like @title order by goodsid desc";
                    SqlParameter para = new SqlParameter("@title", query);
                    DataTable dt = new DataTable();
                    dt = SqlHelper.ExecDataSet(strquery, para).Tables[0];
                    GetRptBind(dt);
                }
                else
                {
                    Response.Redirect("Index.aspx");
                    return;
                }
            }
        }

        private void GetRptBind(DataTable dt)
        {

            PagedDataSource pds = new PagedDataSource();
            pds.PageSize = AspNetPager1.PageSize;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            AspNetPager1.RecordCount = dt.Rows.Count;
            int pagecount = AspNetPager1.PageCount;
            DataView dv = dt.DefaultView;
            pds.DataSource = dv;
            
            rpt.DataSource = pds;
            rpt.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            string strsql;
            DataTable dt = new DataTable();
            if (!quming.Equals("全部"))
            {
                strsql = "select * from tb_goods where pType = '" + quming + "' order by goodsid desc";
                dt = SqlHelper.ExecDataSet(strsql).Tables[0];
            }
            else if (query == "")
            {
                strsql = "select * from tb_goods order by goodsid desc";
                dt = SqlHelper.ExecDataSet(strsql).Tables[0];
            }
            else
            {
                strsql = "select * from tb_goods where pTitle like @title order by goodsid desc";
                SqlParameter para = new SqlParameter("@title", query);
                dt = SqlHelper.ExecDataSet(strsql, para).Tables[0];
            }

            GetRptBind(dt);
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product.aspx?query=" + txtQuery.Text);
        }

    }
}