﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.Models.DTO
{
    public class StorageTypeDTO
    {
        public int StorageTypeId { get; set; }
        public string StorageTypeDesc { get; set; }
        public int StorageTypeQtyAvailable { get; set; }
    }
}