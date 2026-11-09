using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CakeStoreMng
{
    public partial class ManageEmployee : Form
    {
        private string usernameME;
        private string roleME;
        private int employeeIdME;

        public ManageEmployee(string usernameAF, string roleAF, int employeeIdAF)
        {
            InitializeComponent();

            usernameME = usernameAF;
            roleME = roleAF;
            employeeIdME = employeeIdAF;

            lbWelcome.Text = "Welcome " + usernameME + "!";

            LoadEmployeeData();
        }




        private void LoadEmployeeData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Employee";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvTable.DataSource = table;
                connection.Close();
            }
        }




        private bool ValidateData(string employeeCode,
                          string employeeName,
                          string username,
                          string employeePosition,
                          string role,
                          string password)
        {
            bool isValid = true;

            if (employeeCode == null || employeeCode == string.Empty)
            {
                MessageBox.Show(
                    "Employee Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCode.Focus();
                isValid = false;
            }
            else if (employeeName == null || employeeName == string.Empty)
            {
                MessageBox.Show(
                    "Employee Name cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtFullname.Focus();
                isValid = false;
            }
            else if (username == null || username == string.Empty)
            {
                MessageBox.Show(
                    "User Name cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtFullname.Focus();
                isValid = false;
            }
            else if (employeePosition == null || employeePosition == string.Empty)
            {
                MessageBox.Show(
                    "Employee Position cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPosition.Focus();
                isValid = false;
            }
            else if (role == null || role == string.Empty)
            {
                MessageBox.Show(
                    "Role cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                isValid = false;
            }
            else if (password == null || password == string.Empty)
            {
                MessageBox.Show(
                    "Password cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPassword.Focus();
                isValid = false;
            }

            return isValid;
        }



        private void SearchUser(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadEmployeeData();
            }
            else
            {
                // Open connection from DatabaseConnection class
                SqlConnection connection = DatabaseConnection.GetConnection();

                // Check connection
                if (connection != null)
                {
                    // Open the connection
                    connection.Open();

                    // Declare query to the database
                    string query = "SELECT * FROM Employee WHERE EmployeeCode LIKE @search " +
                                   "OR EmployeeName LIKE @search " +
                                   "OR Position LIKE @search " +
                                   "OR Role LIKE @search " +
                                   "OR Username LIKE @search " +
                                   "OR Password LIKE @search";

                    // Initialize SqlDataAdapter to translate query result to a data table
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("search", "%" + search + "%");

                    // Initialize data table
                    DataTable table = new DataTable();

                    // Fill the dataset by data queried from the database
                    adapter.Fill(table);

                    // Bind data to DataGridView
                    dgvTable.DataSource = table;

                    // Close connection
                    connection.Close();
                }
            }
        }




        private void AddUser(string employeeCode,
                     string employeeName,
                     string employeePosition,
                     string role,
                     string username,
                     string password)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "INSERT INTO Employee VALUES (@employeeCode, " +
                             "@employeeName, @employeePosition, " +
                             "@role, @username, @password)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("employeeCode", employeeCode);
                command.Parameters.AddWithValue("employeeName", employeeName);
                command.Parameters.AddWithValue("employeePosition", employeePosition);
                command.Parameters.AddWithValue("role", role);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully add new user",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ClearData();
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot add new user",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                connection.Close();
            }
        }



        private void UpdateUser(int employeeId,
                        string employeeCode,
                        string employeeName,
                        string employeePosition,
                        string role,
                        string username,
                        string password)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE Employee SET EmployeeCode = @employeeCode, " +
                             "EmployeeName = @employeeName, " +
                             "Position = @employeePosition, " +
                             "Role = @role, " +
                             "Username = @username, " +
                             "Password = @password " +
                             "WHERE EmployeeID = @employeeId";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("employeeCode", employeeCode);
                command.Parameters.AddWithValue("employeeName", employeeName);
                command.Parameters.AddWithValue("employeePosition", employeePosition);
                command.Parameters.AddWithValue("role", role);
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);
                command.Parameters.AddWithValue("employeeId", employeeId);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully update user",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot update user",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }




        private void DeleteUser(int employeeId)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "DELETE Employee WHERE EmployeeID = @employeeId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("employeeId", employeeId);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully delete user",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot delete user",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                connection.Close();
            }
        }




        private void ClearData()
        {
            txtCode.Text = string.Empty;
            txtFullname.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPosition.Text = string.Empty;
            cbRole.Text = string.Empty;
            cbRole.SelectedIndex = -1;
            cbRole.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }




        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCode.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                txtFullname.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                txtPosition.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                cbRole.Text = dgvTable.CurrentRow.Cells[4].Value.ToString();
                txtUsername.Text = dgvTable.CurrentRow.Cells[5].Value.ToString();
                txtPassword.Text = dgvTable.CurrentRow.Cells[6].Value.ToString();
            }
        }




        private void btnBack_Click_1(object sender, EventArgs e)
        {
            switch (roleME)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(usernameME, roleME, employeeIdME);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse":
                    {
                        WarehouseForm WarehouseForm = new WarehouseForm(usernameME, roleME, employeeIdME);
                        this.Hide();
                        WarehouseForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm SaleForm = new SaleForm(usernameME, roleME, employeeIdME);
                        this.Hide();
                        SaleForm.Show();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get user input data
            string employeeCode = txtCode.Text;
            string employeeName = txtFullname.Text;
            string employeePosition = txtPosition.Text;
            string role = cbRole.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate data
            bool isValid = ValidateData(employeeCode,
                                        employeeName,
                                        employeePosition,
                                        role,
                                        username,
                                        password);

            if (isValid)
            {
                AddUser(employeeCode, employeeName, employeePosition, role, username, password);
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get user input data
            int employeeId = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            string employeeCode = txtCode.Text;
            string employeeName = txtFullname.Text;
            string employeePosition = txtPosition.Text;
            string role = cbRole.SelectedItem.ToString();
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate data
            bool isValid = ValidateData(employeeCode,
                                        employeeName,
                                        employeePosition,
                                        role,
                                        username,
                                        password);

            if (isValid)
            {
                UpdateUser(employeeId, employeeCode, employeeName, employeePosition, role, username, password);
            }
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                "Do you want to delete this user?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            int employeeId = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            if (result == DialogResult.Yes)
            {
                DeleteUser(employeeId);
            }
        }




        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            SearchUser(search);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
