using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Rental_System.DAL;
using Vehicle_Rental_System.MODEL;

namespace Vehicle_Rental_System_WinForms
{
    public partial class ViewCustomers : Form
    {
        public ViewCustomers()
        {
            InitializeComponent();
            ConfigureDataGridView();
        }

        private async void ViewCustomers_Load(object sender, EventArgs e)
        {
            await CustomerGetAllAsync();
        }

        private void ConfigureDataGridView()
        {
            txtViewCustomers.Location = new Point(0, 50);
            txtViewCustomers.Size = new Size(this.Width, this.Height - 50);
            txtViewCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtViewCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtViewCustomers.ReadOnly = true;
            txtViewCustomers.AllowUserToAddRows = false;
            txtViewCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public async Task CustomerGetAllAsync()
        {
            try
            {
                List<CustomerSignUp> customers = await AppContext.CustomerBLL.CustomerGetAllAsync();
                
                if (customers.Count == 0)
                {
                    MessageBox.Show("No customers found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtViewCustomers.DataSource = null; 
                }
                else
                {
                    txtViewCustomers.DataSource = customers;
                    
                    // Hide password column
                    if (txtViewCustomers.Columns["Password"] != null)
                        txtViewCustomers.Columns["Password"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu(); 
            adminMenu.Show();
            this.Hide();
        }

        private void txtViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
