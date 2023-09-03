using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Bulk_Storage_Solutions.Exceptions;

namespace Bulk_Storage_Solutions.DAL.Features.IClients
{

    public class ClientFunctionality : IClient

    {
        private readonly ISqlDbConnection _db;

        public ClientFunctionality(ISqlDbConnection db)
        {
            _db = db;
        }

        public DataSet GetAllRowsFromClients()
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlDataAdapter da = new SqlDataAdapter("GetAllClients", connection);
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

        public DataSet SearchForClient(string search)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("SearchClient", connection);

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
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public void CreateNewClient(ClientDTO client)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("CreateClient", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@clientName", SqlDbType.VarChar).Value = client.ClientName;
                cmd.Parameters.Add("@clientSurname", SqlDbType.VarChar).Value = client.ClientSurname;
                cmd.Parameters.Add("@clientStatus", SqlDbType.VarChar).Value = client.ClientStatus;
                cmd.Parameters.Add("@clientEmail", SqlDbType.VarChar).Value = client.ClientEmail;
                cmd.Parameters.Add("@clientContactNumber", SqlDbType.VarChar).Value = client.ClientContact;



                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public ClientDTO GetClientById(int clientId)
        {
            try
            {
                ClientDTO client = new ClientDTO();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetClientById", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientId;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    client = new ClientDTO
                    {
                        ClientId = Convert.ToInt32(reader["Client_Id"]),
                        ClientName = reader["Client_Name"].ToString(),
                        ClientSurname = reader["Client_Surname"].ToString(),
                        ClientStatus = reader["Client_Status"].ToString(),
                        ClientEmail = reader["Client_Email"].ToString(),
                        ClientContact = reader["Client_Contact_Number"].ToString(),

                    };
                }

                connection.Close();

                return client;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public void UpdateContract(ClientDTO client)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("UpdateClient", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = client.ClientId;
                cmd.Parameters.Add("@clientName", SqlDbType.VarChar).Value = client.ClientName;
                cmd.Parameters.Add("@clientSurname", SqlDbType.VarChar).Value = client.ClientSurname;
                cmd.Parameters.Add("@clientStatus", SqlDbType.VarChar).Value = client.ClientStatus;
                cmd.Parameters.Add("@clientEmail", SqlDbType.VarChar).Value = client.ClientEmail;
                cmd.Parameters.Add("@clientContactNumber", SqlDbType.VarChar).Value = client.ClientContact;



                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public void UpdateClient(ClientDTO client)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("UpdateClient", connection);

                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = client.ClientId;
                cmd.Parameters.Add("@clientName", SqlDbType.VarChar).Value= client.ClientName;
                cmd.Parameters.Add("@clientSurname", SqlDbType.VarChar).Value = client.ClientSurname;
                cmd.Parameters.Add("@clientEmail", SqlDbType.VarChar).Value = client.ClientEmail;
                cmd.Parameters.Add("@clientContactNumber", SqlDbType.VarChar).Value = client.ClientContact;
                cmd.Parameters.Add("@clientStatus", SqlDbType.VarChar).Value = client.ClientStatus;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch(Exception ex)
            {
                throw new BadRequestException($"Could not update client ({client.ClientId}). ({ex.Message})");
            }
        }

        public void DeleteClient(int clientId)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("DeleteClient", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientId;

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Could not delete client ({clientId}). ({ex.Message})");
            }
        }
    }
}
