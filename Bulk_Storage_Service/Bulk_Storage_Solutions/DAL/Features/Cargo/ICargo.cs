using Bulk_Storage_Solutions.Models.DTO;
using System.Data;

namespace Bulk_Storage_Solutions.DAL.Features.Cargo
{
    public interface ICargo
    {
        DataSet GetAllRowsFromCargo();
        CargoDTO GetCargoById(int CargoId);
        void CreateNewCargo(CargoDTO Cargo);
        void UpdateCargo(CargoDTO Cargo);
        void DeleteCargo(int CargoId);
        DataSet SearchForCargo(string search);
    }
}
