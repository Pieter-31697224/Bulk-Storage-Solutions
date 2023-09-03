

namespace Bulk_Storage_Solutions.DAL.Features.LoginValidation
{
    public interface IValidation
    {
        bool ValidateUser(string email, string password);
    }
}
