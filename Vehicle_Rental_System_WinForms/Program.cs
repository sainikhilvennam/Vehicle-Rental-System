using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Rental_System.DAL;
using Vehicle_Rental_System.DAO;

namespace Vehicle_Rental_System_WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load and configure persistent storage
            LoadPersistentStorage();

            Application.Run(new Form1());
        }

        private static void LoadPersistentStorage()
        {
            const string CONFIG_FILE = "storage_config.txt";
            int choice = 1; // Default to SQL

            try
            {
                if (File.Exists(CONFIG_FILE))
                {
                    string savedChoice = File.ReadAllText(CONFIG_FILE);
                    if (int.TryParse(savedChoice, out int parsedChoice))
                    {
                        choice = parsedChoice;
                    }
                }
            }
            catch
            {
                choice = 1; // Default to SQL on error
            }

            // Configure storage based on saved choice
            ConfigureAppStorage(choice);
        }

        private static void ConfigureAppStorage(int storageChoice)
        {
            if (storageChoice == 1) // SQL
            {
                AppContext.CustomerBLL.UseStorage(new CustomerDAL());
                AppContext.VehicleBLL.UseStorage(new VehicleDAL());
            }
            else // JSON
            {
                AppContext.CustomerBLL.UseStorage(new JSonCustomerStorageDAL());
                AppContext.VehicleBLL.UseStorage(new JSonVehicleStorageDAL());
            }
        }
    }
}
