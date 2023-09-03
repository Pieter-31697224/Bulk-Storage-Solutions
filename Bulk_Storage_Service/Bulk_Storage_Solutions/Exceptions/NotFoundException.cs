using System;

namespace Bulk_Storage_Solutions.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key): base($"{name} ({key}) was not found.")
        {

        }
    }
}