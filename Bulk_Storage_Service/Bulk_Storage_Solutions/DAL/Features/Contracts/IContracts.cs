using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Storage_Solutions.DAL.Features.Contracts
{
    public interface IContracts
    {
        DataSet GetAllRowsFromContracts();
        ContractDTO GetContractById(int contractId);
        void CreateNewContract(ContractDTO contract);
        void UpdateContract(ContractDTO contract);
        void DeleteContract(int contractId);
        DataSet SearchForContract(string search);
    }
}
