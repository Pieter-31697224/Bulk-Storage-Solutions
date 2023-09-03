using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.Enums
{
    public class enums
    {

        public enum Status
        {
            Active = 1,
            InActive = 2,
            Pending = 3,
            Discontinued = 4
        }

        public enum ChartType
        {
            Pie = 1,
            Bar = 2,
            Column = 3,
            Doughnut = 4,
            Line = 5
        }
    }
}