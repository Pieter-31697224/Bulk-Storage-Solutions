using Bulk_Storage_Solutions.Models.DTO;
using System.Data;

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
