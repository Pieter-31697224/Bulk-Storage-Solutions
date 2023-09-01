using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulk_Storage_Solutions.DAL.Features.Storage
{
    public interface IStorage
    {
        DataSet GetAllStorage();
        DataSet SearchForStorage(string search);
        StorageDTO GetStorageById(int storageId); 
        void DeleteStorage(int storageId);
        List<Models.Persistent.StorageType> GetAllStorageTypesForDropDownList();
        void CreateStorage(StorageDTO storage);
        void UpdateStorage(StorageDTO storage);
    }
}
