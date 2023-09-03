using Bulk_Storage_Solutions.DAL.SqlDbConnection;
using Bulk_Storage_Solutions.Models.DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Bulk_Storage_Solutions.DAL.Features.Cargo
{
    public class CargoFunctions : ICargo
    {
        private readonly ISqlDbConnection _db;

        public CargoFunctions(ISqlDbConnection db)
        {
            _db = db;
        }

        public DataSet GetAllRowsFromCargo()
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlDataAdapter da = new SqlDataAdapter("GetAllCargo", connection);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connection.Close();

                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }

        }

        public DataSet SearchForCargo(string search)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("SearchCargo", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@searchValue", search);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                connection.Close();

                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public void CreateNewCargo(CargoDTO cargo)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("CreateCargo", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cargoDesc", SqlDbType.VarChar).Value = cargo.CargoDesc;
                cmd.Parameters.Add("@cargoQty", SqlDbType.Int).Value = cargo.CargoQty;
                cmd.Parameters.Add("@cargoWeight", SqlDbType.Float).Value = cargo.CargoWeight;
                cmd.Parameters.Add("@cargoLong", SqlDbType.Float).Value = cargo.CargoLong;
                cmd.Parameters.Add("@cargoLat", SqlDbType.Float).Value = cargo.CargoLat;


                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public CargoDTO GetCargoById(int cargoId)
        {
            try
            {
                CargoDTO cargo = new CargoDTO();
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("GetCargoById", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cargoId", SqlDbType.Int).Value = cargoId;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cargo = new CargoDTO
                    {
                        CargoId = Convert.ToInt32(reader["Cargo_Id"]),
                        CargoDesc = reader["Cargo_Desc"].ToString(),
                        CargoQty = Convert.ToInt32(reader["Cargo_Qty"]),
                        CargoWeight = Convert.ToDouble(reader["Cargo_Weight"]),
                        CargoLong = Convert.ToDouble(reader["Cargo_Long"]),
                        CargoLat = Convert.ToDouble(reader["Cargo_Lat"])

                    };
                }

                connection.Close();

                return cargo;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public void UpdateCargo(CargoDTO cargo)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("UpdateCargo", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cargoId", SqlDbType.Int).Value = cargo.CargoId;
                cmd.Parameters.Add("@cargoDesc", SqlDbType.VarChar).Value = cargo.CargoDesc;
                cmd.Parameters.Add("@cargoQty", SqlDbType.Int).Value = cargo.CargoQty;
                cmd.Parameters.Add("@cargoweight", SqlDbType.Float).Value = cargo.CargoWeight;
                cmd.Parameters.Add("@cargoLong", SqlDbType.Float).Value = cargo.CargoLong;
                cmd.Parameters.Add("@cargoLat", SqlDbType.Float).Value = cargo.CargoLat;

                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }

        public void DeleteCargo(int cargoId)
        {
            try
            {
                var connection = _db.OpenDbConnection();
                SqlCommand cmd = new SqlCommand("DeleteCargo", connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cargoId", SqlDbType.Int).Value = cargoId;

                cmd.ExecuteNonQuery();

                connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
    }
}