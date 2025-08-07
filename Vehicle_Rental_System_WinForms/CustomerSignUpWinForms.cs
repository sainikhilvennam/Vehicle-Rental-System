using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Rental_System.BLL;
using Vehicle_Rental_System.Exceptions;
using Vehicle_Rental_System.Interfaces;
using Vehicle_Rental_System.MODEL;
using Vehicle_Rental_System.DAL;
using Vehicle_Rental_System.Validations;

namespace Vehicle_Rental_System_WinForms
{
    public partial class CustomerSignUpWinForms : Form
    {
        
        
        public CustomerSignUpWinForms()
        {

            InitializeComponent();
            
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try { 
            string name=CustomValidations.GetValidatedInputString_WindowForms(txtName.Text.Trim(), CustomValidations.IsValidName);
            string phoneNumber = CustomValidations.GetValidatedInputString_WindowForms(txtPhoneNumber.Text.Trim(), CustomValidations.IsValidPhoneNumber);
                string email = CustomValidations.GetValidatedInputString_WindowForms(txtEmailId.Text.Trim(), CustomValidations.IsValidEmail);
                string address = CustomValidations.GetValidatedInputString_WindowForms(txtAddress.Text.Trim(), CustomValidations.IsValidAddress);
                string password = CustomValidations.GetValidatedInputString_WindowForms(txtPassword.Text.Trim(), CustomValidations.IsValidPassword);

                // Check if email already exists
                bool emailExists = await AppContext.CustomerBLL.IsEmailExistsAsync(email);
                if (emailExists)
                {
                    MessageBox.Show("Email already exists. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
           
                await AppContext.CustomerBLL.CustomerAddAsync(name, phoneNumber, email, address, password);
                MessageBox.Show("Customer Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            catch(IncorrectUserDataException ex)
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
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
