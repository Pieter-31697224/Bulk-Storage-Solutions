﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulk_Storage_Solutions.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}