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
    public partial class WarehouseForm : Form
    {

        private string usernameAF;   // Biến lưu tên người đăng nhập
        private string roleAF;
        private int employeeIdAF;

        public WarehouseForm(string username, string role, int employeeId)
        {
            InitializeComponent();

            usernameAF = username;   // Gán giá trị nhận được từ Form Login
            roleAF = role;   // Gán giá trị nhận được từ Form Login
            employeeIdAF = employeeId;   // Gán giá trị nhận được từ Form Login

            lbWelcome.Text = "Welcome " + usernameAF + "!  (Warehouse)";

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
