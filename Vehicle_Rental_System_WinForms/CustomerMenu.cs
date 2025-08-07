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
    public partial class CustomerMenu : Form
    {
        public CustomerMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Customer_Sign_Out_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for using our Vehicle Rental System!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Btn_Customer_View_All_Vehicles_Click(object sender, EventArgs e)
        {
            View_Vehicles_By_Customer view_Vehicles_By_Customer = new View_Vehicles_By_Customer();
            view_Vehicles_By_Customer.Show();
            this.Hide();
        }
    }
}
