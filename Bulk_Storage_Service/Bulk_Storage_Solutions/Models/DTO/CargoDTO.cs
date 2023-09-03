using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.Models.DTO
{
    public class CargoDTO
    {
        public int CargoId { get; set; }
        public string CargoDesc { get; set; }
        public int CargoQty { get; set; }
        public double CargoWeight { get; set; }
        public double CargoLong { get; set; }
        public double CargoLat { get; set; }


    }
}