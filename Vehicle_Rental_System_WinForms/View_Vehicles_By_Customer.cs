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
    public partial class View_Vehicles_By_Customer : Form
    {
        public View_Vehicles_By_Customer()
        {
            InitializeComponent();
            ConfigureDataGridView();
        }
        private async void View_Vehicles_By_Customer_Load(object sender, EventArgs e)
        {
            await VehicleGetAllAsync();
        }

        private void ConfigureDataGridView()
        {
            DataGrid_View.Location = new Point(0, 50);
            DataGrid_View.Size = new Size(this.Width, this.Height - 50);
            DataGrid_View.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGrid_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGrid_View.ReadOnly = true;
            DataGrid_View.AllowUserToAddRows = false;
            DataGrid_View.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public async Task VehicleGetAllAsync()
        {
            try
            {
                List<Vehicle> vehicles = await AppContext.VehicleBLL.VehicleGetAllAsync();


                if (vehicles.Count == 0)
                {
                    MessageBox.Show("No vehicles found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGrid_View.DataSource = null;
                }
                else
                {
                    DataGrid_View.DataSource = vehicles;
                    // Improve column headers if needed
                    if (DataGrid_View.Columns["BrandModel"] != null)
                        DataGrid_View.Columns["BrandModel"].HeaderText = "Brand/Model";
                    if (DataGrid_View.Columns["RegistrationNumber"] != null)
                        DataGrid_View.Columns["RegistrationNumber"].HeaderText = "Registration";
                    if (DataGrid_View.Columns["SeatingCapacity"] != null)
                        DataGrid_View.Columns["SeatingCapacity"].HeaderText = "Seats";
                    if (DataGrid_View.Columns["RentalRate"] != null)
                        DataGrid_View.Columns["RentalRate"].HeaderText = "Rate";
                    if (DataGrid_View.Columns["IsAvailable"] != null)
                        DataGrid_View.Columns["IsAvailable"].HeaderText = "Available";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vehicles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn_Back_Click(object sender, EventArgs e)
        {
            CustomerMenu customerMenu = new CustomerMenu();
            customerMenu.Show();
            this.Hide();
        }

        private void DataGrid_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
