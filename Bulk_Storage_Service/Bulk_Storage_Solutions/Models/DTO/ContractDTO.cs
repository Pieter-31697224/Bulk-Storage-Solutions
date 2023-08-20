using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.Models.DTO
{
    public class ContractDTO
    {
        public int ContractId { get; set; }
        public string ContractDescription { get; set; }
        public string ContractStatus { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
    }
}