using System;
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
            // The code in this page can only be accessed by authenticated users
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login2.aspx");
            }
        }
    }
}