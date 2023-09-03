using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Storage_Solutions.DAL.Features.LoginValidation
{
    public interface IValidation
    {
        bool ValidateUser(string email, string password);
    }
}
