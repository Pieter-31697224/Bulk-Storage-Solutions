using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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

        public DataSet GetContractById(int contractId)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetContractById", connection);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@contractId", SqlDbType.Int).Value = contractId;
                da.SelectCommand = cmd;
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
    }
}