using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Rental_System.Interfaces;
using Vehicle_Rental_System.MODEL;

namespace Vehicle_Rental_System.DAO
{
    public class VehicleDAL : IVehicleStorage
    {
        private readonly string connectionString;
        public VehicleDAL()
        {
            // Hardcoded connection string to bypass config issues if you use console or web then change this connection string use app.config
            connectionString = "Server=INHYNVSAINIKH01;Database=Vehicle_Rental_System;Integrated Security=True;";
        }

        public async Task VehicleAddAsync(Vehicle vehicle)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "INSERT INTO Vehicle (BrandModel, Mileage, RegistrationNumber, SeatingCapacity, RentalRate, IsAvailable) VALUES (@BrandModel, @Mileage, @RegistrationNumber, @SeatingCapacity, @RentalRate, @IsAvailable)";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BrandModel", vehicle.BrandModel);
                    cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                    cmd.Parameters.AddWithValue("@RegistrationNumber", vehicle.RegistrationNumber);
                    cmd.Parameters.AddWithValue("@SeatingCapacity", vehicle.SeatingCapacity);
                    cmd.Parameters.AddWithValue("@RentalRate", vehicle.RentalRate);
                    cmd.Parameters.AddWithValue("@IsAvailable", vehicle.IsAvailable);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<bool> VehicleDeleteAsync(int id)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "DELETE FROM Vehicle WHERE Id = @Id";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        //Console.WriteLine($"Vehicle with ID {id} deleted successfully.");
                        return true;
                    }
                    else
                    {
                        //Console.WriteLine($"{id} not found. ");
                        return false;
                    }
                }
            }
        }

        public async Task<List<Vehicle>> VehicleGetAllAsync()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM Vehicle";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using(SqlDataReader reader =await cmd.ExecuteReaderAsync())
                    {
                        while(await reader.ReadAsync())
                        {
                            Vehicle vehicle = new Vehicle
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                BrandModel = reader["BrandModel"].ToString(),
                                Mileage = reader["Mileage"].ToString(),
                                RegistrationNumber = reader["RegistrationNumber"].ToString(),
                                SeatingCapacity = reader["SeatingCapacity"].ToString(),
                                RentalRate = reader["RentalRate"].ToString(),
                                IsAvailable = reader["IsAvailable"].ToString()
                            };
                            vehicles.Add(vehicle);
                        }
                    }
                }
            }
            return vehicles;
        }

        public async Task<Vehicle> VehicleGetByIdAsync(int id)
        {
            Vehicle vehicle = null;
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "SELECT * FROM Vehicle WHERE Id = @Id";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using(SqlDataReader reader =await cmd.ExecuteReaderAsync())
                    {
                        if(await reader.ReadAsync())
                        {
                            vehicle = new Vehicle
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                BrandModel = reader["BrandModel"].ToString(),
                                Mileage = reader["Mileage"].ToString(),
                                RegistrationNumber = reader["RegistrationNumber"].ToString(),
                                SeatingCapacity = reader["SeatingCapacity"].ToString(),
                                RentalRate = reader["RentalRate"].ToString(),
                                IsAvailable = reader["IsAvailable"].ToString()
                            };
                        }
                    }
                }
            }
            return vehicle;
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "select * from Admin where EmailId = @email and Password = @password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }


    }
}