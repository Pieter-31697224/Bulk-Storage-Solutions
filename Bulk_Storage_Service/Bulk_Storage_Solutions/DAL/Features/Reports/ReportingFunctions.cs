using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.Exceptions;
using Bulk_Storage_Solutions.Models.Persistent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Bulk_Storage_Solutions.DAL.Features.Reports
{
    public class ReportingFunctions : IReports
    {
        private readonly ISqlDbConnection _db;

        public ReportingFunctions(ISqlDbConnection db)
        {
            _db = db;
        }

        public List<ClientReport> GetClientsReport(string startDate, string endDate)
        {
            try
            {
                DateTime? startDateTime = DateTime.TryParse(startDate, out DateTime resultStartDate) ? DateTime.Parse(startDate) : DateTime.MinValue;
                DateTime? endDateTime = DateTime.TryParse(endDate, out DateTime resultEndDate) ? DateTime.Parse(endDate) : DateTime.MinValue;

                if(startDateTime == DateTime.MinValue)
                {
                    startDateTime = null;
                }

                if(endDateTime == DateTime.MinValue)
                {
                    endDateTime= null;
                }

                List<ClientReport> clientReportList = new List<ClientReport>();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetTopTenClients", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = startDateTime;
                cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = endDateTime;
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    ClientReport client = new ClientReport
                    {
                        ClientId = Convert.ToInt32(reader["Client_Id"]),
                        Client = reader["Client"].ToString(),
                        AgreementCount = Convert.ToInt32(reader["AgreementCount"])
                    };

                    clientReportList.Add(client);
                }

                connection.Close();

                return clientReportList;
            }
            catch(Exception ex)
            {
                throw new NotFoundException(nameof(Reports), ex.Message);
            }
        }

        public List<StorageTypeReport> GetMostUsedStorageTypeReport()
        {
            try
            {
                List<StorageTypeReport> storageTypes = new List<StorageTypeReport>();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("MostUsedStorageType", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    StorageTypeReport storageType = new StorageTypeReport
                    {
                        StorageTypeId = Convert.ToInt32(reader["Storage_Type_Id"]),
                        StorageDesc = reader["Storage_Type_Desc"].ToString(),
                        StorageypeCount = Convert.ToInt32(reader["StorageTypeCount"])
                    };

                    storageTypes.Add(storageType);
                }

                connection.Close();
                return storageTypes;

            }
            catch(Exception ex)
            {
                throw new BadRequestException($"Could not create report. ({ex.Message})");
            }
        }

        public List<StorageStatusReport> GetStorageStatusReport()
        {
            try
            {
                List<StorageStatusReport> statusList = new List<StorageStatusReport>();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetStorageStatusReport", connection);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StorageStatusReport storage = new StorageStatusReport
                    {
                        ActiveCount = Convert.ToInt32(reader["Active"]),
                        InactiveCount = Convert.ToInt32(reader["Inactive"])
                    };

                    statusList.Add(storage);
                }

                connection.Close();
                return statusList;

            }
            catch(Exception ex)
            {
                throw new BadRequestException($"Could not create report. ({ex.Message})");
            }
        }
    }
}