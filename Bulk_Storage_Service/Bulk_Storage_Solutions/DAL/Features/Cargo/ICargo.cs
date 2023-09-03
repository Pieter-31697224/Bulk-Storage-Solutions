using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
