using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
