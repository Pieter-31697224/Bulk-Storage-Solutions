using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Storage_Solutions.DAL.SqlDbConnection
{
    public interface ISqlDbConnection
    {
        SqlConnection OpenDbConnection();
    }
}
