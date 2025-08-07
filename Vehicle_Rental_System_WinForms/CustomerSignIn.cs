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
    public partial class CustomerSignIn : Form
    {
        public CustomerSignIn()
        {
            InitializeComponent();
        }
        private async void btnSubmit_Click_1(object sender, EventArgs e)
        {
            try
            {
                string email = CustomValidations.GetValidatedInputString_WindowForms(txtEmailId.Text, CustomValidations.IsValidEmail);
                string password = CustomValidations.GetValidatedInputString_WindowForms(txtPassword.Text, CustomValidations.IsValidPassword);
                bool result = await AppContext.CustomerBLL.SignInAsync(email, password);
                if (result)
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CustomerMenu customerMenu = new CustomerMenu();
                    customerMenu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid email or password. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (IncorrectUserDataException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"SignIn Failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
