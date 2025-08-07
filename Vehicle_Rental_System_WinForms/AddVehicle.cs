using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Vehicle_Rental_System.Exceptions;
using Vehicle_Rental_System.Validations;

namespace Vehicle_Rental_System_WinForms
{
    public partial class AddVehicle : Form
    {
        public AddVehicle()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            txtBrandModel.Clear();
            txtMileage.Clear();
            txtRegistrationNumber.Clear();
            txtSeatingCapacity.Clear();
            txtRentalRate.Clear();
            txtIsAvailable.Clear();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string brandModel = CustomValidations.GetValidatedInputString_WindowForms(txtBrandModel.Text.Trim(), CustomValidations.IsValidName);
                string mileage = CustomValidations.GetValidatedInputString_WindowForms(txtMileage.Text.Trim(), CustomValidations.IsValidMileage);
                string registrationNumber = CustomValidations.GetValidatedInputString_WindowForms(txtRegistrationNumber.Text.Trim(), CustomValidations.IsValidRegistrationNumber);
                string seatingCapacity = CustomValidations.GetValidatedInputString_WindowForms(txtSeatingCapacity.Text.Trim(), CustomValidations.IsValidSeatingCapacity);
                string rentalRate = CustomValidations.GetValidatedInputString_WindowForms(txtRentalRate.Text.Trim(), CustomValidations.IsValidRentalRate);
                string isAvailable = CustomValidations.GetValidatedInputString_WindowForms(txtIsAvailable.Text.Trim(), CustomValidations.IsValidIsAvailable);

                await AppContext.VehicleBLL.VehicleAddAsync(brandModel, mileage, registrationNumber, seatingCapacity, rentalRate, isAvailable);
                MessageBox.Show("Vehicle Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                //AdminMenu adminMenu = new AdminMenu();
                //adminMenu.Show();
                //this.Hide();
            }
            catch (IncorrectUserDataException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Hide();
        }

        private void AddVehicle_Load(object sender, EventArgs e)
        {

        }

        private void txtBrandModel_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
