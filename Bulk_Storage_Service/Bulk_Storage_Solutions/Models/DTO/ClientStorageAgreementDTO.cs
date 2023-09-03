namespace Bulk_Storage_Solutions.Models.DTO
{
    public class ClientStorageAgreementDTO
    {
        public int ClientId { get; set; }
        public string Client { get; set; }
        public int CargoId { get; set; }
        public string Cargo { get; set; }
        public int StorageId { get; set; }
        public string Storage { get; set; }
        public int ContractId { get; set; }
        public string Contract { get; set; }
    }
}