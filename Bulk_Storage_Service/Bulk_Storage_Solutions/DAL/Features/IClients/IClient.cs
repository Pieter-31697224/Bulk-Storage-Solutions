using Bulk_Storage_Solutions.Models.DTO;
using System.Data;

namespace Bulk_Storage_Solutions.DAL.Features.IClients
{
    public interface IClient
    {
        DataSet GetAllRowsFromClients();
        ClientDTO GetClientById(int ClientId);
        void CreateNewClient(ClientDTO client);
        void UpdateClient(ClientDTO client);
        void DeleteClient(int clientId);
        DataSet SearchForClient(string search);
    }
}
