﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulk_Storage_Solutions.Views
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else
            {
                if(!IsPostBack)
                {
                    logo.ImageUrl = "~/Image/logo.png";
                }
            }
        }
    }
}