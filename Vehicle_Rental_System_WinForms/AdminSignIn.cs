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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Vehicle_Rental_System.Validations;

namespace Vehicle_Rental_System_WinForms
{
    public partial class AdminSignIn : Form
    {
        public AdminSignIn()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                string email = CustomValidations.GetValidatedInputString_WindowForms(EmailId.Text, CustomValidations.IsValidEmail);
                string password = CustomValidations.GetValidatedInputString_WindowForms(Password.Text, CustomValidations.IsValidPassword);

                bool temp = await AppContext.VehicleBLL.SignInAsync(email, password);
                if (temp)
                {
                    MessageBox.Show("Sign-in successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.Show();
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
    