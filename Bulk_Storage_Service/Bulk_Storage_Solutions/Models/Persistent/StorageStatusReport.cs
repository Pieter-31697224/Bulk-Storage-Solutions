using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.Models.Persistent
{
    public class StorageStatusReport
    {
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
    }
}