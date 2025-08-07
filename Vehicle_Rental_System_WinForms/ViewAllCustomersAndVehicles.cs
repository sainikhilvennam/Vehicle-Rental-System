using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicle_Rental_System.MODEL;



namespace Vehicle_Rental_System_WinForms
{
    public partial class ViewAllCustomersAndVehicles : Form
    {
        public ViewAllCustomersAndVehicles()
        {
            InitializeComponent();
            ConfigureDataGridViews();
        }

        private void ConfigureDataGridViews()
        {
            ConfigureLayout();
            ConfigureCustomersGrid();
            ConfigureVehiclesGrid();
            ConfigureBackButton();
        }

        private void ConfigureLayout()
        {
            // Customers DataGridView - Left half
            dataGridViewCustomers.Location = new Point(10, 60);
            dataGridViewCustomers.Size = new Size((this.ClientSize.Width / 2) - 15, this.ClientSize.Height - 100);
            dataGridViewCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            
            // Vehicles DataGridView - Right half
            dataGridViewVehicles.Location = new Point((this.ClientSize.Width / 2) + 5, 60);
            dataGridViewVehicles.Size = new Size((this.ClientSize.Width / 2) - 15, this.ClientSize.Height - 100);
            dataGridViewVehicles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            
            // Handle resize event to maintain split
            this.Resize += ViewAllCustomersAndVehicles_Resize;
        }

        private void ViewAllCustomersAndVehicles_Resize(object sender, EventArgs e)
        {
            // Recalculate positions when window resizes
            dataGridViewCustomers.Size = new Size((this.ClientSize.Width / 2) - 15, this.ClientSize.Height - 100);
            dataGridViewVehicles.Location = new Point((this.ClientSize.Width / 2) + 5, 60);
            dataGridViewVehicles.Size = new Size((this.ClientSize.Width / 2) - 15, this.ClientSize.Height - 100);
        }

        private void ConfigureCustomersGrid()
        {
            dataGridViewCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCustomers.ReadOnly = true;
            dataGridViewCustomers.AllowUserToAddRows = false;
            dataGridViewCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ConfigureVehiclesGrid()
        {
            dataGridViewVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewVehicles.ReadOnly = true;
            dataGridViewVehicles.AllowUserToAddRows = false;
            dataGridViewVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ConfigureBackButton()
        {
            if (this.Controls.Find("btnBack", true).Length > 0)
            {
                var backButton = this.Controls.Find("btnBack", true)[0];
                backButton.Location = new Point(12, 12);
                backButton.Size = new Size(75, 30);
                backButton.Text = "Back";
            }
        }

        private async void ViewAllCustomersAndVehicles_Load(object sender, EventArgs e)
        {
            Task customerTask = CustomerLoadAsync();
            Task vehicleTask = VehiclesLoadAsync();
            await Task.WhenAll(customerTask, vehicleTask);
        }

        public async Task CustomerLoadAsync()
        {
            try
            {
                List<CustomerSignUp> customers = await AppContext.CustomerBLL.CustomerGetAllAsync();

                if (customers.Count == 0)
                {
                    MessageBox.Show("No customers found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewCustomers.DataSource = null;
                }
                else
                {
                    dataGridViewCustomers.DataSource = customers;

                    // Hide password column
                    if (dataGridViewCustomers.Columns["Password"] != null)
                        dataGridViewCustomers.Columns["Password"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task VehiclesLoadAsync()
        {
            try
            {
                List<Vehicle> vehicles = await AppContext.VehicleBLL.VehicleGetAllAsync();
                
                if (vehicles.Count == 0)
                {
                    MessageBox.Show("No vehicles found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewVehicles.DataSource = null;
                }
                else
                {
                    dataGridViewVehicles.DataSource = vehicles;
                    
                    // Improve column headers if needed
                    if (dataGridViewVehicles.Columns["BrandModel"] != null)
                        dataGridViewVehicles.Columns["BrandModel"].HeaderText = "Brand/Model";
                    if (dataGridViewVehicles.Columns["RegistrationNumber"] != null)
                        dataGridViewVehicles.Columns["RegistrationNumber"].HeaderText = "Registration";
                    if (dataGridViewVehicles.Columns["SeatingCapacity"] != null)
                        dataGridViewVehicles.Columns["SeatingCapacity"].HeaderText = "Seats";
                    if (dataGridViewVehicles.Columns["RentalRate"] != null)
                        dataGridViewVehicles.Columns["RentalRate"].HeaderText = "Rate";
                    if (dataGridViewVehicles.Columns["IsAvailable"] != null)
                        dataGridViewVehicles.Columns["IsAvailable"].HeaderText = "Available";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Hide();
        }

        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
