using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Vehicle_Rental_System.DAO;
using Vehicle_Rental_System.MODEL;
using Vehicle_Rental_System.Validations;
using Vehicle_Rental_System.Exceptions;
using Vehicle_Rental_System.Interfaces;

namespace Vehicle_Rental_System.BLL
{
    public class VehicleBLL
    {
        private IVehicleStorage storage;

        public void UseStorage(IVehicleStorage vehicleStorage)
        {
            storage = vehicleStorage;
        }
        public async Task VehicleAddAsync(string brandModel, string mileage, string registrationNumber, string seatingCapacity, string rentalRate, string isAvailable)
        {
        
            Vehicle vehicle = new Vehicle
            {
                BrandModel = brandModel,
                Mileage = mileage,
                RegistrationNumber = registrationNumber,
                SeatingCapacity = seatingCapacity,
                RentalRate = rentalRate,
                IsAvailable = isAvailable
            };
            await storage.VehicleAddAsync(vehicle);
        }

        public async Task<bool> VehicleDeleteAsync(int id)
        {
            return await storage.VehicleDeleteAsync(id);
        }

        public async Task<List<Vehicle>> VehicleGetAllAsync()
        {
            return await storage.VehicleGetAllAsync();
        }
        public async Task<Vehicle> VehicleGetByIdAsync(int id)
        {
            return await storage.VehicleGetByIdAsync(id);
        }

        public async Task<bool> SignInAsync(string EmailId,string Password)
        {
            return await storage.SignInAsync(EmailId, Password);
        }

    }
}