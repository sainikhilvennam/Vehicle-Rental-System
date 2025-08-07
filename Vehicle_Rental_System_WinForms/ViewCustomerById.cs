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
using Vehicle_Rental_System.MODEL;
using Vehicle_Rental_System.Validations;

namespace Vehicle_Rental_System_WinForms
{
    public partial class ViewCustomerById : Form
    {
        public ViewCustomerById()
        {
            InitializeComponent();
            ConfigureInputControls();
            ConfigureDataGridView();
        }

        private void ConfigureInputControls()
        {
            // Position back button at top-left
            if (this.Controls.Find("btnBack", true).Length > 0)
            {
                var backButton = this.Controls.Find("btnBack", true)[0];
                backButton.Location = new Point(12, 12);
                backButton.Size = new Size(75, 30);
            }
            
            // Position input controls below back button
            if (this.Controls.Find("label1", true).Length > 0)
            {
                var label = this.Controls.Find("label1", true)[0];
                label.Location = new Point(20, 50);
                label.Text = "Customer ID:";
            }
            
            txtCustomerId.Location = new Point(120, 47);
            txtCustomerId.Size = new Size(100, 26);
            
            if (this.Controls.Find("button1", true).Length > 0)
            {
                var button = this.Controls.Find("button1", true)[0];
                button.Location = new Point(240, 45);
                button.Size = new Size(80, 30);
                button.Text = "Search";
            }
        }

        private void ConfigureDataGridView()
        {
            // Position DataGridView below input controls (leave more space at top for back button)
            dataGridCustomerGetById.Location = new Point(10, 90);
            dataGridCustomerGetById.Size = new Size(this.Width - 40, this.Height - 130);
            dataGridCustomerGetById.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridCustomerGetById.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridCustomerGetById.ReadOnly = true;
            dataGridCustomerGetById.AllowUserToAddRows = false;
            dataGridCustomerGetById.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await CustomerLoadAsync();
        }
        public async Task CustomerLoadAsync()
        {
            try
            {
                int customerId;
                if (!int.TryParse(txtCustomerId.Text, out customerId))
                {
                    MessageBox.Show("Please enter a valid customer ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CustomValidations.GetValidatedInputInt_WindowForms(customerId, CustomValidations.IsValidId);
                var customer = await AppContext.CustomerBLL.CustomerGetByIdAsync(customerId);
                if (customer == null)
                {
                    MessageBox.Show("Customer not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Display customer in DataGridView
                List<CustomerSignUp> customerList = new List<CustomerSignUp> { customer };
                dataGridCustomerGetById.DataSource = customerList;

                // Improve column headers
                if (dataGridCustomerGetById.Columns["EmailId"] != null)
                    dataGridCustomerGetById.Columns["EmailId"].HeaderText = "Email";
                if (dataGridCustomerGetById.Columns["PhoneNumber"] != null)
                    dataGridCustomerGetById.Columns["PhoneNumber"].HeaderText = "Phone";

                // Hide password column
                if (dataGridCustomerGetById.Columns["Password"] != null)
                    dataGridCustomerGetById.Columns["Password"].Visible = false;
            }
            catch (IncorrectUserDataException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Hide();
        }

        private void dataGridCustomerGetById_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
