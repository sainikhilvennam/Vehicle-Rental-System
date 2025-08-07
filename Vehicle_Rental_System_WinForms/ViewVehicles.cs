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
    public partial class ViewVehicles : Form
    {
        public ViewVehicles()
        {
            InitializeComponent();
            ConfigureDataGridView();
        }

        //private async void ViewVehicles_Load(object sender, EventArgs e)
        //{
        //    await VehicleGetAllAsync();
        //}

        private async void ViewVehicles_Load_1(object sender, EventArgs e)
        {
            await VehicleGetAllAsync();
        }

        private void ConfigureDataGridView()
        {
            dgGetAllVehicles.Location = new Point(0, 50);
            dgGetAllVehicles.Size = new Size(this.Width, this.Height - 50);
            dgGetAllVehicles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgGetAllVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgGetAllVehicles.ReadOnly = true;
            dgGetAllVehicles.AllowUserToAddRows = false;
            dgGetAllVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        //private async void dgGetAllVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    await VehicleGetAllAsync();
        //}
        public async Task VehicleGetAllAsync()
        {
            try
            {
                List<Vehicle> vehicles = await AppContext.VehicleBLL.VehicleGetAllAsync();
                

                if (vehicles.Count == 0)
                {
                    MessageBox.Show("No vehicles found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgGetAllVehicles.DataSource = null;
                }
                else
                {
                    dgGetAllVehicles.DataSource = vehicles;
                    // Improve column headers if needed
                    if (dgGetAllVehicles.Columns["BrandModel"] != null)
                        dgGetAllVehicles.Columns["BrandModel"].HeaderText = "Brand/Model";
                    if (dgGetAllVehicles.Columns["RegistrationNumber"] != null)
                        dgGetAllVehicles.Columns["RegistrationNumber"].HeaderText = "Registration";
                    if (dgGetAllVehicles.Columns["SeatingCapacity"] != null)
                        dgGetAllVehicles.Columns["SeatingCapacity"].HeaderText = "Seats";
                    if (dgGetAllVehicles.Columns["RentalRate"] != null)
                        dgGetAllVehicles.Columns["RentalRate"].HeaderText = "Rate";
                    if (dgGetAllVehicles.Columns["IsAvailable"] != null)
                        dgGetAllVehicles.Columns["IsAvailable"].HeaderText = "Available";
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

        private void dgGetAllVehicles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
