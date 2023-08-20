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
        public DataSet GetAllRowsFromContracts()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ToString());
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("GetAllContracts", connection);
            DataSet ds= new DataSet();
            da.Fill(ds);

            return ds;

        }
    }
}