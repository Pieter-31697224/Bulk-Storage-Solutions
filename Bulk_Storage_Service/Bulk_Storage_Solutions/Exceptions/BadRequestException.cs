using System;

namespace Bulk_Storage_Solutions.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }
    }
}