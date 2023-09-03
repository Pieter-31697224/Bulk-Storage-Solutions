using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Storage_Solutions.DAL.Features.Clients
{
    internal interface IClients
    {
        DataSet GetAllClients();
        ClientDTO GetClientById(int Clientid);
        void CreateNewClient(ClienttDTO client);
        void UpdateClient(ClientDTO client);
        DataSet SearchClient(string search);
    }
}`