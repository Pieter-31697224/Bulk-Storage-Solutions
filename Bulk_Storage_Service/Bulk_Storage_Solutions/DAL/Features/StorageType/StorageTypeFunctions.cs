using Bulk_Storage_Solutions.DAL.Features.Contracts;
using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.Exceptions;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Bulk_Storage_Solutions.DAL.Features.StorageType
{
    public class StorageTypeFunctions : IStorageType
    {
        private readonly ISqlDbConnection _db;

        public StorageTypeFunctions(ISqlDbConnection db)
        {
            _db = db;
        }

        public void CreateStorageType(StorageTypeDTO storageType)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("CreateStorageType", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@storageTypeDesc", SqlDbType.VarChar).Value = storageType.StorageTypeDesc;
                cmd.Parameters.Add("@storageQtyAvailable", SqlDbType.Int).Value = storageType.StorageTypeQtyAvailable;

                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Could not create storage type. ({ex.Message})");
            }
        }

        public void DeleteStorageType(int storageTpeId)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("DeleteStorageType", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@storageTypeId", SqlDbType.Int).Value = storageTpeId;

                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Could not delete storage type {storageTpeId}. ({ex.Message})");
            }
        }

        public DataSet GetAllStorageTypes()
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlDataAdapter da = new SqlDataAdapter("GetAllStorageTypes", connection);
                DataSet ds = new DataSet();

                da.Fill(ds);

                connection.Close();

                return ds;
            }
            catch(Exception ex)
            {
                throw new NotFoundException(nameof(StorageType), ex.Message);
            }
        }

        public StorageTypeDTO GetStorageTypeById(int storageTypeId)
        {
            try
            {
                StorageTypeDTO storageType = new StorageTypeDTO();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetStorageTypeById", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@storageTypeId", SqlDbType.Int).Value = storageTypeId;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    storageType = new StorageTypeDTO
                    {
                        StorageTypeId = Convert.ToInt32(reader["Storage_Type_Id"]),
                        StorageTypeDesc = reader["Storage_Type_Desc"].ToString(),
                        StorageTypeQtyAvailable = Convert.ToInt32(reader["Storage_Qty_Available"])
                    };
                }

                connection.Close();

                return storageType;

            }
            catch (Exception ex)
            {
                throw new NotFoundException(nameof(StorageType), storageTypeId);
            }
        }

        public DataSet SearchStorageType(string searchValue)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("SearchStorageTypes", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@searchValue", searchValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connection.Close();

                return ds;
            }
            catch (Exception ex)
            {
                throw new NotFoundException(nameof(StorageType), searchValue);
            };
        }

        public void UpdateStorageType(StorageTypeDTO storageType)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("UpdateStorageType", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@storageTypeId", SqlDbType.Int).Value = storageType.StorageTypeId;
                cmd.Parameters.Add("@storageTypeDesc", SqlDbType.VarChar).Value = storageType.StorageTypeDesc;
                cmd.Parameters.Add("@storageQtyAvailable", SqlDbType.Int).Value = storageType.StorageTypeQtyAvailable;

                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Could not update storage type {storageType.StorageTypeId}. ({ex.Message})");
            }
        }
    }
}