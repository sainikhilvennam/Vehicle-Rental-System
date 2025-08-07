using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Rental_System.BLL;
using Vehicle_Rental_System.DAL;
using Vehicle_Rental_System.DAO;

namespace Vehicle_Rental_System_WinForms
{
    public static class AppContext
    {
        public static CustomerBLL CustomerBLL { get; set; } = new CustomerBLL();
        public static VehicleBLL VehicleBLL { get; set; } = new VehicleBLL();

        
    }
}
