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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_Customer_Sign_Up_Click(object sender, EventArgs e)
        {
            CustomerSignUpWinForms customerSignUp = new CustomerSignUpWinForms();
            customerSignUp.Show();
            this.Hide();
        }

        private void btn_Customer_Sign_In_Click(object sender, EventArgs e)
        {
            CustomerSignIn customerSignIn = new CustomerSignIn();
            customerSignIn.Show();
            this.Hide();
        }

        private void btn_Admin_Sign_In_Click(object sender, EventArgs e)
        {
            AdminSignIn adminSignIn = new AdminSignIn();
            adminSignIn.Show();
            this.Hide();
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
