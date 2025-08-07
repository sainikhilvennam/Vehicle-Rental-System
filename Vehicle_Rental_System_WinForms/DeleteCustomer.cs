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
    public partial class DeleteCustomer : Form
    {
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int customerId;
                if (!int.TryParse(txtCustomerId.Text, out customerId))
                {
                    MessageBox.Show("Please enter a valid customer ID Must be Integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                customerId = CustomValidations.GetValidatedInputInt_WindowForms(customerId, CustomValidations.IsValidId);
                bool results=await AppContext.CustomerBLL.CustomerDeleteAsync(customerId);
                if(results)
                {
                    MessageBox.Show("Customer deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Customer not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }catch(IncorrectUserDataException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBack_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Hide();
        }

        private void ClearForm()
        {
            txtCustomerId.Clear();
        }
    }
}
