using Bulk_Storage_Solutions.Models.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Storage_Solutions.DAL.Features.Reports
{
    public interface IReports
    {
        List<ClientReport> GetClientsReport(string date, string endDate);

        List<StorageTypeReport> GetMostUsedStorageTypeReport();
        List<StorageStatusReport> GetStorageStatusReport();
    }
}
