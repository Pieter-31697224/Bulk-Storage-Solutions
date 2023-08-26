using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.DAL.Features.Storage
{
    public class StorageFunctions : IStorage
    {
        private readonly ISqlDbConnection _db;

        public StorageFunctions(ISqlDbConnection db)
        {
            _db = db;
        }

        public DataSet GetAllStorage()
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlDataAdapter da = new SqlDataAdapter("GetAllStorage", connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
            
        }
            
    }
}