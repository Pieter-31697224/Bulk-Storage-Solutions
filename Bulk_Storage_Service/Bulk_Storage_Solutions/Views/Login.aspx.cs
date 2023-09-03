using Bulk_Storage_Solutions.DAL.Features.LoginValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulk_Storage_Solutions.Views
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly IValidation _validation;

        public Login()
        {
            _validation = Global.Resolve<IValidation>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if(_validation.ValidateUser(Username.Text, Password.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(Username.Text, false);
            }
        }
    }
}