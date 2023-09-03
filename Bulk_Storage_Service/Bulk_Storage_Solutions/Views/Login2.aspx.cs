using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Bulk_Storage_Solutions.DAL.Features.Users;
using Bulk_Storage_Solutions.Models.DTO;
using System.Web.Security;

namespace Bulk_Storage_Solutions
{
    public partial class Login2 : System.Web.UI.Page
    {
        private readonly IUser _user;
        public Login2()
        {
            _user = Global.Resolve<IUser>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is already authenticated
                if (User.Identity.IsAuthenticated)
                {
                    // Redirect to the default page if the user is already logged in
                    Response.Redirect("~/Default.aspx");
                }
            }
        }



        protected void btnLogin2_Click(object sender, EventArgs e)
        {
            try
            {
                // Authenticate the user against your database or user store
                string userEmail = UserEmail.Text.Trim();
                string password = UserPassword.Text.Trim();

                if (AuthenticateUser(userEmail, password))
                {
                    UserDTO user = new UserDTO
                    {
                        UserEmail = UserEmail.Text,
                        UserPassword = UserPassword.Text,
                    };

                    // Create a forms authentication ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userEmail, DateTime.Now, DateTime.Now.AddMinutes(30), false, FormsAuthentication.FormsCookiePath);
                    // Adjust the expiration time as needed

                    // Encrypt the ticket and add it to a cookie
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(cookie);

                    // Redirect the user to the default page
                    Response.Redirect(FormsAuthentication.DefaultUrl);

                    _user.CheckPassword(user);

                    Console.WriteLine("You have succesfully logged into your account. Welcome back!");

                }
                else
                {
                    Console.WriteLine("Invalid username or password.");
                }

               ;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private bool AuthenticateUser(string userEmail, string password)
        {
            // Implement your user authentication logic here
            // Check if the provided username and password are valid
            // Return true if authentication is successful, otherwise false
            return (userEmail == "your_username" && password == "your_password");
            
        }
    }
}