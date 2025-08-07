using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Rental_System.BLL;
using Vehicle_Rental_System.DAL;
using Vehicle_Rental_System.DAO;
using Vehicle_Rental_System.Interfaces;

namespace Vehicle_Rental_System_WinForms
{
    public partial class SetStorage : Form
    {
        private const string CONFIG_FILE = "storage_config.txt";
        
        public SetStorage()
        {
            InitializeComponent();
            LoadCurrentStorageSelection();
        }

        private void LoadCurrentStorageSelection()
        {
            try
            {
                if (File.Exists(CONFIG_FILE))
                {
                    string savedChoice = File.ReadAllText(CONFIG_FILE);
                    if (savedChoice == "1")
                    {
                        radioButton1.Checked = true; // SQL
                    }
                    else if (savedChoice == "2")
                    {
                        radioButton2.Checked = true; // JSON
                    }
                }
                else
                {
                    radioButton1.Checked = true; // Default to SQL
                }
            }
            catch
            {
                radioButton1.Checked = true; // Default to SQL on error
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Get choice from radio buttons (1 for SQL, 2 for JSON)
            int choice = radioButton1.Checked ? 1 : 2;
            
            // Save choice to file
            SaveStorageChoice(choice);
            
            // Configure storage
            ConfigureStorage(choice);
            
            // Show confirmation
            string storageType = choice == 1 ? "SQL Database" : "JSON File";
            MessageBox.Show($"Storage set to: {storageType}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveStorageChoice(int choice)
        {
            try
            {
                File.WriteAllText(CONFIG_FILE, choice.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving storage choice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureStorage(int storageChoice)
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Hide();
        }
    }
}
