﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingOnline
{
    public partial class Check : System.Web.UI.Page
    {
        private static string u_ID = "", u_Shop = "", w_ListID = "", w_ID = "";
        private static string[] w_IDs;
        public static int num = 0, sum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Click(object sender, EventArgs e)
        {
        }

        protected void btnToOrder_Click(object sender, EventArgs e)
        {
            //Response.Write(ra.Next(10)+ra.Next(10)+date.ToFileTime().ToString());
        }

    }
}