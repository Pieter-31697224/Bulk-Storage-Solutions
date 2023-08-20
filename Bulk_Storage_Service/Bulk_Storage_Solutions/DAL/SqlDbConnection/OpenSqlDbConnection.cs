using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.DAL.SqlDbConnection
{
    public class OpenSqlDbConnection : ISqlDbConnection
    {
        public SqlConnection OpenDbConnection()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
            connection.Open();

            return connection;
        }
    }
}