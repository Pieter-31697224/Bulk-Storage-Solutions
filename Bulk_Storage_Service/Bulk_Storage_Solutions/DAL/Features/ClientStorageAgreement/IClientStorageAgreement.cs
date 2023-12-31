﻿using Bulk_Storage_Solutions.Models.DTO;
using Bulk_Storage_Solutions.Models.Persistent;
using System.Collections.Generic;
using System.Data;

namespace Bulk_Storage_Solutions.DAL.Features.ClientStorageAgreement
{
    public interface IClientStorageAgreement
    {
        DataSet GetAllClientStorageAgreements();
        DataSet SearchForClientStorageAgreement(string search);
        ClientStorageAgreementDTO GetClientStorageAgreementById(int clientStorageAgreementId);
        List<Client> GetAllClientsForDropDownList();
        List<Models.Persistent.Cargo> GetAllCargoForDropDownList();
        List<Contract> GetAllContractsForDropDownList();
        List<Models.Persistent.Storage> GetAllStorageForDropDownList();
        void CreateClientStorageAgreement(ClientStorageAgreementDTO clientAgreement);
        void DeleteClientStorageAgreement(int clientStorageAgreementId);
    }
}
