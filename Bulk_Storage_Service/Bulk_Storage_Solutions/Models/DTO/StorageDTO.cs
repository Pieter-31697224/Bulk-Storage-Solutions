﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.Models.DTO
{
    public class StorageDTO
    {
        public int storageId { get; set; }
        public string storageDescription { get; set; }
        public string storageStatus { get; set; }
        public int storageTypeId { get; set; }

    }
}