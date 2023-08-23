using Bulk_Storage_Solutions.Models.DTO;
using System.Data;

namespace Bulk_Storage_Solutions.DAL.Features.StorageType
{
    public interface IStorageType
    {
        DataSet GetAllStorageTypes();
        DataSet SearchStorageType(string searchValue);
        StorageTypeDTO GetStorageTypeById(int storageTypeId);
        void CreateStorageType(StorageTypeDTO storageType);
        void UpdateStorageType(StorageTypeDTO storageType);
        void DeleteStorageType(int storageTpeId);


    }
}
