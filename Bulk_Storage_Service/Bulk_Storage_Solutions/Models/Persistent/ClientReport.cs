using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.Models.Persistent
{
    public class ClientReport
    {
        public int ClientId { get; set; }
        public string Client { get; set; }
        public int AgreementCount { get; set; }
    }
}