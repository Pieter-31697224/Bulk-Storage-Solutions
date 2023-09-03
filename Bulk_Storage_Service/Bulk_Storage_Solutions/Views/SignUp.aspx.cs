using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Bulk_Storage_Solutions.Models.DTO;
using Bulk_Storage_Solutions.DAL.Features.Users;

namespace Bulk_Storage_Solutions
{
    public partial class SignUp : System.Web.UI.Page
    {
        private readonly IUser _user;
        public SignUp()
        {
            _user = Global.Resolve<IUser>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserPasswordSignUp.Text == PasswordConfirm.Text)
                {
               
                    UserDTO user = new UserDTO
                    {
                        UserName = UserName.Text,
                        UserSurname = UserSurname.Text,
                        UserEmail = UserEmailSignUp.Text,
                        UserPassword = UserPasswordSignUp.Text,
                    };

                    _user.CreateNewUser(user);

                    Server.Transfer("~/Default.aspx");
                }
                else
                {
                    Console.WriteLine("Your Passwords did not match. Please try again");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            

        }
    }
}