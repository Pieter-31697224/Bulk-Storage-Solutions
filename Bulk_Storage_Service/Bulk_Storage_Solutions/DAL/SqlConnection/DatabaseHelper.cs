using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.DAL.SqlConnection
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper() : this(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString)
        {

        }

        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}