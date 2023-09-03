using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.Exceptions;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Bulk_Storage_Solutions.DAL.Features.Storage
{
    public class StorageFunctions : IStorage
    {
        private readonly ISqlDbConnection _db;

        public StorageFunctions(ISqlDbConnection db)
        {
            _db = db;
        }

        public void CreateStorage(StorageDTO storage)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("CreateStorage", connection);

                cmd.CommandType= CommandType.StoredProcedure;

                cmd.Parameters.Add("@storageStatus", SqlDbType.VarChar).Value = storage.storageStatus;
                cmd.Parameters.Add("@storageTypeId", SqlDbType.Int).Value = storage.storageTypeId;

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception ex)
            {
                throw new BadRequestException($"Could not create storage. ({ex.Message})");
            }
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
                throw new BadRequestException($"Could not delete storage ({storageId}). ({ex.Message})");
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
                throw new NotFoundException(nameof(Storage), ex.Message);
            }
            
        }

        public List<Models.Persistent.StorageType> GetAllStorageTypesForDropDownList()
        {
            try
            {
                List<Models.Persistent.StorageType> storageTypeList = new List<Models.Persistent.StorageType>();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetAllStorageTypesForDropDownList", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Models.Persistent.StorageType storageType = new Models.Persistent.StorageType
                    {
                        StorageTypeDesc = reader["Storage_Type_Desc"].ToString(),
                        StorageTypeId = Convert.ToInt32(reader["Storage_Type_Id"])

                    };

                    storageTypeList.Add(storageType);
                }

                return storageTypeList;
            }
            catch(Exception ex)
            {
                throw new NotFoundException(nameof(Storage), ex.Message);
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
                        storageStatus = reader["StorageStatus"].ToString(),
                        storageTypeId = Convert.ToInt32(reader["StorageTypeId"])
                    };
                }
                connection.Close();
                return storage;
            }
            catch (Exception ex)
            {
                throw new NotFoundException(nameof(Storage), storageId);
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
                throw new NotFoundException(nameof(Storage), search);
            }
        }

        public void UpdateStorage(StorageDTO storage)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("UpdateStorage", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@storageId", SqlDbType.Int).Value = storage.storageId;
                cmd.Parameters.Add("@storageStatus", SqlDbType.VarChar).Value = storage.storageStatus;
                cmd.Parameters.Add("@storageTypeId", SqlDbType.Int).Value = storage.storageTypeId;

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Could not update storage ({storage.storageId}). ({ex.Message})");
            }
        }
    }
}