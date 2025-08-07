using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Rental_System.MODEL;

namespace Vehicle_Rental_System.Interfaces
{
    public interface IVehicleStorage
    {
        Task<List<Vehicle>> VehicleGetAllAsync();
        Task<Vehicle> VehicleGetByIdAsync(int id);
        Task VehicleAddAsync(Vehicle vehicle);
        Task<bool> VehicleDeleteAsync(int id);
        Task<bool> SignInAsync(string EmailId, string Password);
    }
}