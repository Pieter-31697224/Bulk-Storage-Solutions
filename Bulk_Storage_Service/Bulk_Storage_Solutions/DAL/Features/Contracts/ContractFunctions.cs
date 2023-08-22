using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Bulk_Storage_Solutions.DAL.Features.Contracts
{
    public class ContractFunctions : IContracts
    {
        private readonly ISqlDbConnection _db;

        public ContractFunctions(ISqlDbConnection db)
        {
            _db = db;
        }

        public DataSet GetAllRowsFromContracts()
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlDataAdapter da = new SqlDataAdapter("GetAllContracts", connection);
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

        public DataSet SearchForContract(string search)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("SearchContracts", connection);

                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@searchValue", search);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
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

        public void CreateNewContract(ContractDTO contract)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("CreateContract", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@contractDescription", SqlDbType.VarChar).Value = contract.ContractDescription;
                cmd.Parameters.Add("@contractStatus", SqlDbType.VarChar).Value = contract.ContractStatus;
                cmd.Parameters.Add("@contractStartDate", SqlDbType.Date).Value = contract.StartDate;
                cmd.Parameters.Add("@contractEndDate", SqlDbType.DateTime).Value = contract.EndDate;

                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public ContractDTO GetContractById(int contractId)
        {
            try
            {
                ContractDTO contract = new ContractDTO();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetContractById", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@contractId", SqlDbType.Int).Value = contractId;

                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.Read())
                {
                     contract = new ContractDTO
                    {
                        ContractId = Convert.ToInt32(reader["Contract_Id"]),
                        ContractDescription = reader["Contract_Desc"].ToString(),
                        ContractStatus = reader["Contract_Status"].ToString(),
                        StartDate = reader["Contract_Start_Date"] != DBNull.Value ? Convert.ToDateTime(reader["Contract_Start_Date"]): (DateTime?)null,
                        EndDate = reader["Contract_End_Date"] != DBNull.Value ? Convert.ToDateTime(reader["Contract_End_Date"]) : (DateTime?)null
                     };
                }

                connection.Close();

                return contract;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public void UpdateContract(ContractDTO contract)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("UpdateContract", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@contractId", SqlDbType.Int).Value = contract.ContractId;
                cmd.Parameters.Add("@contractDescription", SqlDbType.VarChar).Value = contract.ContractDescription;
                cmd.Parameters.Add("@contractStatus", SqlDbType.VarChar).Value = contract.ContractStatus;
                cmd.Parameters.Add("@contractStartDate", SqlDbType.Date).Value = contract.StartDate;
                cmd.Parameters.Add("@contractEndDate", SqlDbType.DateTime).Value = contract.EndDate;

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public void DeleteContract(int contractId)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("DeleteContract", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@contractId", SqlDbType.Int).Value = contractId;

                cmd.ExecuteNonQuery();

                connection.Close(); 

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
    }
}