using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.Exceptions;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Bulk_Storage_Solutions.DAL.Features.LoginValidation
{
    public class ValidateUserFunction : IValidation
    {
        private readonly ISqlDbConnection _db;

        public ValidateUserFunction(ISqlDbConnection db)
        {
            _db = db;
        }

        public bool ValidateUser(string email, string password)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("ValidateUser", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserEmail", email);
                cmd.Parameters.AddWithValue("@UserPassword", password);

                SqlParameter isValidParam = cmd.Parameters.Add("@IsValid", SqlDbType.Bit);
                isValidParam.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                return (bool)isValidParam.Value;
            }
            catch(Exception ex)
            {
                throw new NotFoundException("User", email);
            }
        }
    }
}