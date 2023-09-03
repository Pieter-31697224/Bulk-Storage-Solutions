using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.Exceptions;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.DAL.Features.Users
{
    public class UserFunctions : IUser
    {
        private readonly ISqlDbConnection _db;
        public UserFunctions(ISqlDbConnection db)
        {
            _db = db;
        }

        public void CheckPassword(UserDTO user)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("CheckPassword", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userEmail", SqlDbType.VarChar).Value = user.UserEmail;
                cmd.Parameters.AddWithValue("@userPassword", SqlDbType.VarChar).Value = user.UserPassword;

                SqlDataAdapter adapter = new SqlDataAdapter("login",connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Could not find the User. {ex.Message}");
            }
        }

        public void CreateNewUser(UserDTO user)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("CreateUser", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = user.UserName;
                cmd.Parameters.Add("@userSurname", SqlDbType.VarChar).Value = user.UserSurname;
                cmd.Parameters.Add("@userEmail", SqlDbType.VarChar).Value = user.UserEmail;
                cmd.Parameters.Add("@userPassword", SqlDbType.VarChar).Value = user.UserPassword;

                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Could not create new User. {ex.Message}");
            }
        }
    }
}