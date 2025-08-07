using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vehicle_Rental_System_WinForms
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
        private void Btn_Change_Storage_Type_Click(object sender, EventArgs e)
        {
            SetStorage setStorage = new SetStorage();
            setStorage.Show();
            this.Hide();
        }

        private void Btn_View_All_Customers_Click(object sender, EventArgs e)
        {
            ViewCustomers customers = new ViewCustomers();
            customers.Show();
            this.Hide();
        }

        private void Btn_View_All_Vehicles_Click(object sender, EventArgs e)
        {
            ViewVehicles vehicles = new ViewVehicles();
            vehicles.Show();
            this.Hide();
        }

        private void Btn_Add_Vehicle_Click(object sender, EventArgs e)
        {
            AddVehicle addVehicle = new AddVehicle();
            addVehicle.Show();
            this.Hide();
        }

        private void Btn_Delete_Vehicle_Click(object sender, EventArgs e)
        {
            DeleteVehicle deleteVehicle = new DeleteVehicle();
            deleteVehicle.Show();
            this.Hide();
        }

        private void Btn_View_Customer_By_Id_Click(object sender, EventArgs e)
        {
            ViewCustomerById viewCustomerById = new ViewCustomerById();
            viewCustomerById.Show();
            this.Hide();
        }

        private void Btn_Delete_Customer_Click(object sender, EventArgs e)
        {

            DeleteCustomer deleteCustomer = new DeleteCustomer();
            deleteCustomer.Show();
            this.Hide();
        }

        private void Btn_GACAVD_Click(object sender, EventArgs e)
        {
            ViewAllCustomersAndVehicles viewAllCustomersAndVehicles = new ViewAllCustomersAndVehicles();
            viewAllCustomersAndVehicles.Show();
            this.Hide();
        }
    }
}
