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
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getMenu();
            }

            void getMenu()
            {
                string addMenuItem = "select sortname from tb_sort";
                DataTable dtItem = SqlHelper.ExecDataSet(addMenuItem).Tables[0];

                MenuItem menuItem1 = new MenuItem();
                menuItem1.Text = "首页";
                sortList.Items.Add(menuItem1);
                MenuItem menuItem2 = new MenuItem();
                menuItem2.Text = "全部";
                sortList.Items.Add(menuItem2);
                for (int i = 0; i < dtItem.Rows.Count; i++)
                {
                    DataRow dr = dtItem.Rows[i];
                    MenuItem menuItem = new MenuItem();
                    menuItem.Text = dr["sortname"].ToString();
                    sortList.Items.Add(menuItem);
                }
            }
        }

        protected void sortList_MenuItemClick(object sender, MenuEventArgs e)
        {
            Menu menu = (Menu)sender;
            MenuItem menuItem = menu.SelectedItem;
            string item=menuItem.Text;
            if (item.Equals("首页"))
            {
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                Response.Redirect("~/Product.aspx?item=" + item);

            }
        }
    }
}