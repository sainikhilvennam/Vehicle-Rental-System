using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Rental_System.MODEL
{
    public class Vehicle
    {
        public int Id { get; set; }                        
        public string BrandModel { get; set; }             
        public string Mileage { get; set; }               
        public string RegistrationNumber { get; set; }     
        public string SeatingCapacity { get; set; }           
        public string RentalRate { get; set; }            
        public string IsAvailable { get; set; }
    }
}
