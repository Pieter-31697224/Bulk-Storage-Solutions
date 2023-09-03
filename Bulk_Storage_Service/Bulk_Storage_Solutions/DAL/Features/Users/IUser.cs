using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Storage_Solutions.DAL.Features.Users
{
    public interface IUser
    {
        void CreateNewUser(UserDTO user);

        void CheckPassword(UserDTO user);
    }
}
