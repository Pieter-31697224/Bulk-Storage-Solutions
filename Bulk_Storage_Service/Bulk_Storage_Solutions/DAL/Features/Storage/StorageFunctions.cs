using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.Models.DTO;
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

        public void DeleteStorage(int storageId)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("DeleteStorage", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@storageId", SqlDbType.Int).Value = storageId;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();

            }
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

        public StorageDTO GetStorageById(int storageId)
        {
            try
            {
                StorageDTO storage = new StorageDTO();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetStorageById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@storageId", SqlDbType.Int).Value = storageId;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) 
                {
                    storage = new StorageDTO
                    {
                        storageDescription = reader["StorageDescription"].ToString(),
                        storageStatus = reader["StorageStatus"].ToString()
                    };
                }
                connection.Close();
                return storage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public DataSet SearchForStorage(string search)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("SearchStorage", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchValue",search);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
    }
}