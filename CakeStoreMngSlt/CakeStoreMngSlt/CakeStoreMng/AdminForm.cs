using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CakeStoreMng
{
    public partial class AdminForm : Form
    {
        private string usernameAF;   // Biến lưu tên người đăng nhập
        private string roleAF;
        private int employeeIdAF;
        public AdminForm(string username, string role, int employeeId)
        {
            InitializeComponent();

            usernameAF = username;   // Gán giá trị nhận được từ Form Login
            roleAF = role;   // Gán giá trị nhận được từ Form Login
            employeeIdAF = employeeId;   // Gán giá trị nhận được từ Form Login

            lbWelcome.Text = "Welcome " + usernameAF + "!  (Admin)";

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Hide();
            Login.Show();
        }



        private void btnCategory_Click(object sender, EventArgs e)
        {
            ManageCategory ManageCategory = new ManageCategory(usernameAF, roleAF, employeeIdAF);
            this.Hide();
            ManageCategory.Show();
        }




        private void btnProduct_Click(object sender, EventArgs e)
        {
            ManageProduct ManageProduct = new ManageProduct(usernameAF, roleAF, employeeIdAF);
            this.Hide();
            ManageProduct.Show();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            ManageEmployee ManageEmployee = new ManageEmployee(usernameAF, roleAF, employeeIdAF);
            this.Hide();
            ManageEmployee.Show();

        }


        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ManageCustomer ManageCustomer = new ManageCustomer(usernameAF, roleAF, employeeIdAF);
            this.Hide();
            ManageCustomer.Show();
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            ManageOrders ManageOrders = new ManageOrders(usernameAF, roleAF, employeeIdAF);
            this.Hide();
            ManageOrders.Show();
        }

        private void btnOrderDetail_Click(object sender, EventArgs e)
        {
            ManageOrderDetail ManageOrderDetail = new ManageOrderDetail(usernameAF, roleAF, employeeIdAF);
            this.Hide();
            ManageOrderDetail.Show();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ManageImport ManageImport = new ManageImport(usernameAF, roleAF, employeeIdAF);
            this.Hide();
            ManageImport.Show();
        }

        private void btnImportDetail_Click(object sender, EventArgs e)
        {
            ManageImportDetail ManageImportDetail = new ManageImportDetail(usernameAF, roleAF, employeeIdAF);
            this.Hide();
            ManageImportDetail.Show();
        }
    }
}
