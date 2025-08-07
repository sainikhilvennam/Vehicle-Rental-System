using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Rental_System.MODEL;
using Newtonsoft.Json;
using Vehicle_Rental_System.Interfaces;

namespace Vehicle_Rental_System.DAO
{
    public class JSonVehicleStorageDAL : IVehicleStorage
    {
        private readonly string filePath = "C:\\Users\\vsainikhil\\source\\repos\\Vehicle_Rental_System\\Vehicle_Rental_System\\Data\\vehicles.json";
        private readonly string adminFilePath = "C:\\Users\\vsainikhil\\source\\repos\\Vehicle_Rental_System\\Vehicle_Rental_System\\Data\\admin.json";

        public async Task VehicleAddAsync(Vehicle vehicle)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            
            if (File.Exists(filePath))
            {
                using(StreamReader sr = new StreamReader(filePath))
                {
                    string json=await sr.ReadToEndAsync();
                    vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(json) ?? new List<Vehicle>();
                }
            }
            
            vehicle.Id = vehicles.Count > 0 ? vehicles.Max(v => v.Id) + 1 : 1;
            vehicles.Add(vehicle);
            
            string updatedJson = JsonConvert.SerializeObject(vehicles, Formatting.Indented);
            using(StreamWriter sw = new StreamWriter(filePath))
            {
                await sw.WriteAsync(updatedJson);
            }
        }

        public async Task<bool> VehicleDeleteAsync(int id)
        {
            if (!File.Exists(filePath)) return false;
            
            List<Vehicle> vehicles;
            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = await sr.ReadToEndAsync();
                vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(json) ?? new List<Vehicle>();
            }

            int removedCount = vehicles.RemoveAll(v => v.Id == id);
            if(removedCount == 0)
            {
                //Console.WriteLine($"No vehicle found with ID: {id}");
                return false;
            }

            string updatedJson = JsonConvert.SerializeObject(vehicles, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                await sw.WriteAsync(updatedJson);
            }
            //Console.WriteLine($"Vehicle with ID {id} deleted successfully.");
            return true;
        }

        public async Task<List<Vehicle>> VehicleGetAllAsync()
        {
            if (!File.Exists(filePath)) return new List<Vehicle>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = await sr.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<Vehicle>>(json) ?? new List<Vehicle>();
            }
        }

        public async Task<Vehicle> VehicleGetByIdAsync(int id)
        {
            if (!File.Exists(filePath)) return null;
            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = await sr.ReadToEndAsync();
                List<Vehicle> vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(json) ?? new List<Vehicle>();

                return vehicles.FirstOrDefault(v => v.Id == id);
            }
        }

        public async Task VehicleUpdateAsync(int id, Vehicle vehicle)
        {
            if (!File.Exists(filePath)) return;
            List<Vehicle> vehicles;
            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = await sr.ReadToEndAsync();
                vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(json) ?? new List<Vehicle>();
            }
            var existingVehicle = vehicles.FirstOrDefault(v => v.Id == id);
            if (existingVehicle != null)
            {
                existingVehicle.BrandModel = vehicle.BrandModel;
                existingVehicle.Mileage = vehicle.Mileage;
                existingVehicle.RegistrationNumber = vehicle.RegistrationNumber;
                existingVehicle.SeatingCapacity = vehicle.SeatingCapacity;
                existingVehicle.RentalRate = vehicle.RentalRate;
                existingVehicle.IsAvailable = vehicle.IsAvailable;
                
                string updatedJson = JsonConvert.SerializeObject(vehicles, Formatting.Indented);
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    await sw.WriteAsync(updatedJson);
                }
            }
        }

        public async Task<bool> SignInAsync(string email, string password)
        {
            if (!File.Exists(adminFilePath)) return false;
            
            using (StreamReader sr = new StreamReader(adminFilePath))
            {
                string json = await sr.ReadToEndAsync();
                var admin = JsonConvert.DeserializeObject<dynamic>(json);
                
                return admin?.EmailId == email && admin?.Password == password;
            }
        }

        //public async Task<bool> SignInAsync(string email, string password)
        //{
        //    if (!File.Exists(filePath)) return false;
        //    List<Vehicle> vehicle;
        //    using (StreamReader reader = new StreamReader(filePath))
        //    {
        //        string json = await reader.ReadToEndAsync();
        //        vehicle = JsonConvert.DeserializeObject<List<vehicle>>(json) ?? new List<vehicle>();
        //    }
        //    return vehicle.Any(c => c.EmailId == email && c.Password == password);
        //}
    }
}