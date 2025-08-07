using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Rental_System.Exceptions;
using Vehicle_Rental_System.Validations;

namespace Vehicle_Rental_System_WinForms
{
    public partial class DeleteVehicle : Form
    {
        public DeleteVehicle()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int vehicleId;
                if (!int.TryParse(txtVehicleId.Text, out vehicleId))
                {
                    MessageBox.Show("Please enter a valid vehicle ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                CustomValidations.GetValidatedInputInt_WindowForms(vehicleId, CustomValidations.IsValidId);
                bool results=await AppContext.VehicleBLL.VehicleDeleteAsync(vehicleId);
                if(results)
                {
                    MessageBox.Show("Vehicle deleted successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Vehicle not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (IncorrectUserDataException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Hide();
        }

        private void ClearForm()
        {
            txtVehicleId.Clear();
        }
    }
}
