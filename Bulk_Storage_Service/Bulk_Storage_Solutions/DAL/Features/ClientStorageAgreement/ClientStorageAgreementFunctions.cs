using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.Exceptions;
using Bulk_Storage_Solutions.Models.DTO;
using Bulk_Storage_Solutions.Models.Persistent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Bulk_Storage_Solutions.DAL.Features.ClientStorageAgreement
{
    public class ClientStorageAgreementFunctions : IClientStorageAgreement
    {
        private readonly ISqlDbConnection _db;

        public ClientStorageAgreementFunctions(ISqlDbConnection db)
        {
            _db = db;
        }

        public DataSet GetAllClientStorageAgreements()
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlDataAdapter da = new SqlDataAdapter("GetAllClientStorageAgreements", connection);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connection.Close();

                return ds;
            }
            catch(Exception ex)
            {
                throw new NotFoundException(nameof(ClientStorageAgreement), ex.Message);
            }
        }

        public DataSet SearchForClientStorageAgreement(string search)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("SearchClientStorageAgreement", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@searchValue", search);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connection.Close();

                return ds;
            }
            catch (Exception ex)
            {
                throw new NotFoundException(nameof(ClientStorageAgreement), search);
            }
        }

        public ClientStorageAgreementDTO GetClientStorageAgreementById(int clientStorageAgreementId)
        {
            try
            {
                ClientStorageAgreementDTO clientStorageAgreement = new ClientStorageAgreementDTO();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetClientStorageAgreementById", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@clientStorageAgreementId", SqlDbType.Int).Value = clientStorageAgreementId;

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                    clientStorageAgreement = new ClientStorageAgreementDTO
                    {
                        ClientId = Convert.ToInt32(reader["Client_Id"]),
                        Client = reader["Client"].ToString(),
                        CargoId = Convert.ToInt32(reader["Cargo_Id"]),
                        Cargo = reader["Cargo_Desc"].ToString(),
                        ContractId = Convert.ToInt32(reader["Contract_Id"]),
                        Contract = reader["Contract_Desc"].ToString(),
                        StorageId = Convert.ToInt32(reader["Storage_Id"]),
                        Storage = reader["Storage_Status"].ToString()
                    };
                }

                connection.Close();

                return clientStorageAgreement;
            }
            catch(Exception ex)
            {
                throw new NotFoundException(nameof(ClientStorageAgreement), clientStorageAgreementId);
            }
        }

        public List<Client> GetAllClientsForDropDownList()
        {
            try
            {
                List<Client> clientList = new List<Client>();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetAllClientsForClientStorageAgreementDropDownList", connection);

                cmd.CommandType= CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Client client = new Client
                    {
                        ClientId = Convert.ToInt32(reader["Client_Id"]),
                        ClientName = reader["Client"].ToString()
                    };

                    clientList.Add(client);
                }

                return clientList;
            }
            catch(Exception ex)
            {
                throw new BadRequestException($"Could not get any clients for drop down list. ({ex.Message})");
            }
        }

        public List<Models.Persistent.Cargo> GetAllCargoForDropDownList()
        {
            try
            {
                List<Models.Persistent.Cargo> cargoList = new List<Models.Persistent.Cargo>();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetAllCargoForClientStorageAgreementDropDownList", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Models.Persistent.Cargo client = new Models.Persistent.Cargo
                    {
                        CargoId = Convert.ToInt32(reader["Cargo_Id"]),
                        CargoDesc = reader["Cargo_Desc"].ToString()
                    };

                    cargoList.Add(client);
                }

                return cargoList;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Could not get any cargo for drop down list. ({ex.Message})");
            }
        }

        public List<Contract> GetAllContractsForDropDownList()
        {
            try
            {
                List<Contract> contractList = new List<Contract>();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetAllContractsForClientStorageAgreementDropDownList", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Contract client = new Contract
                    {
                        ContractId = Convert.ToInt32(reader["Contract_Id"]),
                        ContractDesc = reader["Contract_Desc"].ToString()
                    };

                    contractList.Add(client);
                }

                return contractList;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Could not get any contracts for drop down list. ({ex.Message})");
            }
        }

        public List<Models.Persistent.Storage> GetAllStorageForDropDownList()
        {
            try
            {
                List<Models.Persistent.Storage> storageList = new List<Models.Persistent.Storage>();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetAllStorageForClientStorageAgreement", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Models.Persistent.Storage client = new Models.Persistent.Storage
                    {
                        StorageId = Convert.ToInt32(reader["Storage_Id"]),
                        StorageUnitNumber = reader["Storage_Unit_Number"].ToString()
                    };

                    storageList.Add(client);
                }

                return storageList;
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Could not get any storage for drop down list. ({ex.Message})");
            }
        }

        public void CreateClientStorageAgreement(ClientStorageAgreementDTO clientAgreement)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("CreateClientStorageAgreement", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientAgreement.ClientId;
                cmd.Parameters.Add("@cargoId", SqlDbType.Int).Value = clientAgreement.CargoId;
                cmd.Parameters.Add("@storageId", SqlDbType.Int).Value = clientAgreement.StorageId;
                cmd.Parameters.Add("@contractId", SqlDbType.Int).Value = clientAgreement.ContractId;

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception ex)
            {
                throw new BadRequestException($"Could not create new client storage agreement. ({ex.Message})");
            }
        }

        public void DeleteClientStorageAgreement(int clientStorageAgreementId)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("DeleteClientStorageAgreement", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@clientStorageAgreementId", SqlDbType.Int).Value = clientStorageAgreementId;

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception ex)
            {
                throw new BadRequestException($"Could not delete client storage agreement {clientStorageAgreementId}. ({ex.Message})");
            }
        }
    }
}