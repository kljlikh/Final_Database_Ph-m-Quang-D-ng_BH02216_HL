using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CakeStoreMng
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }
        private void lbCakeStore_Click(object sender, EventArgs e)
        {

       

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void ClearData()
        {
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cbRole.SelectedIndex = -1;
            cbRole.Text = string.Empty;
        }
        private bool ValidateData(string username, string password, string role)
        {
            bool isValid = true;
            if (username == null || username == string.Empty)
            {
                MessageBox.Show(
                    "Username cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtName.Focus();
            }
            else if (password == null || password == string.Empty)
            {
                MessageBox.Show(
                    "Password cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtPassword.Focus();
            }
            else if (role == null || role == string.Empty)
            {
                MessageBox.Show(
                    "No role selected",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                cbRole.Focus();
            }
            return isValid;
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtName.Text;
            string password = txtPassword.Text;
            string role = cbRole.Text;

            // Valid data
            bool isValid = ValidateData(username, password, role);
            if (isValid)
            {
                // Open connection by call the GetConnection function in DatabaseConnection class
                SqlConnection connection = DatabaseConnection.GetConnection();

                // Check the connection
                if (connection != null)
                {
                    // Define query to execute (Remember to enter the correct table name)
                    // To avoid exception
                    string query = "SELECT EmployeeId FROM Employee WHERE Username = @username" +
                                   " AND [Password] = @password AND Role = @role";

                    connection.Open();

                    // Initialize a SqlCommand variable to execute query
                    SqlCommand command = new SqlCommand(query, connection);

                    // Add params to query
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("password", password);
                    command.Parameters.AddWithValue("role", role);

                    // Retrieve data from database
                    SqlDataReader reader = command.ExecuteReader();

                    int employeeId = 0;


                    while (reader.Read())
                    {
                        employeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                    }



                    if (employeeId > 0)
                    {
                        MessageBox.Show(
                            "Login success",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        switch (role)
                        {
                            case "Admin":
                                AdminForm AdminForm = new AdminForm(username, role, employeeId);
                                this.Hide();
                                AdminForm.Show();
                                break;
                            case "Sale":
                                SaleForm SaleForm = new SaleForm(username, role, employeeId);
                                this.Hide();
                                SaleForm.Show();
                                break;
                            case "Warehouse":
                                WarehouseForm WarehouseForm = new WarehouseForm(username, role, employeeId);
                                this.Hide();
                                WarehouseForm.Show();
                                break;
                        }

                    }
                    else
                    {
                        MessageBox.Show(
                            "Invalid login credential",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        ClearData();
                    }

                    // Close the connection
                    connection.Close();
                }
            }
        }
    }
}
