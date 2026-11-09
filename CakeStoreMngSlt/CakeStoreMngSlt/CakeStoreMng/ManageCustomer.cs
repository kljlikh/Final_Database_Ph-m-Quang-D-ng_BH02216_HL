using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CakeStoreMng
{
    public partial class ManageCustomer : Form
    {

        private string usernameMC;
        private string roleMC;
        private int employeeIdMC;

        public ManageCustomer(string usernameAF, string roleAF, int employeeIdAF)
        {
            InitializeComponent();

            usernameMC = usernameAF;
            roleMC = roleAF;
            employeeIdMC = employeeIdAF;

            lbWelcome.Text = "Welcome " + usernameMC + "!";

            LoadCustomerData();
        }




        private void LoadCustomerData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Customer";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvTable.DataSource = table;
                connection.Close();
            }
        }




        private bool ValidateData(string customerCode,
                          string customerName,
                          string phone,
                          string address)
        {
            bool isValid = true;

            if (customerCode == null || customerCode == string.Empty)
            {
                MessageBox.Show(
                    "Customer Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCustomerCode.Focus();
                isValid = false;
            }
            else if (customerName == null || customerName == string.Empty)
            {
                MessageBox.Show(
                    "Customer Name cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCustomerName.Focus();
                isValid = false;
            }
            else if (phone == null || phone == string.Empty)
            {
                MessageBox.Show(
                    "Phone cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCustomerName.Focus();
                isValid = false;
            }
            else if (address == null || address == string.Empty)
            {
                MessageBox.Show(
                    "Address Position cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtPhoneNumber.Focus();
                isValid = false;
            }

            return isValid;
        }



        private void SearchCustomer(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadCustomerData();
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
                    string query = "SELECT * FROM Customer WHERE CustomerCode LIKE @search " +
                                   "OR CustomerName LIKE @search " +
                                   "OR PhoneNumber LIKE @search " +
                                   "OR Address LIKE @search";

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




        private void AddCustomer(string customerCode,
                          string customerName,
                          string phone,
                          string address)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "INSERT INTO Customer VALUES (@CustomerCode, " +
                             "@CustomerName, @PhoneNumber, " +
                             "@Address)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("CustomerCode", customerCode);
                command.Parameters.AddWithValue("CustomerName", customerName);
                command.Parameters.AddWithValue("PhoneNumber", phone);
                command.Parameters.AddWithValue("Address", address);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully add new customer",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ClearData();
                    LoadCustomerData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot add new customer",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                connection.Close();
            }
        }



        private void UpdateCustomer(int customerId,
                          string customerCode,
                          string customerName,
                          string phone,
                          string address)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE Customer SET CustomerCode = @customerCode, " +
                             "CustomerName = @customerName, " +
                             "PhoneNumber = @phone, " +
                             "Address = @address " +
                             "WHERE CustomerID = @customerId";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("customerId", customerId);
                command.Parameters.AddWithValue("customerCode", customerCode);
                command.Parameters.AddWithValue("customerName", customerName);
                command.Parameters.AddWithValue("phone", phone);
                command.Parameters.AddWithValue("address", address);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully update customer",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadCustomerData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot update customer",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }




        private void DeleteCustomer(int customerId)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "DELETE Customer WHERE CustomerID = @customerId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("customerId", customerId);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully delete customer",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadCustomerData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot delete customer",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                connection.Close();
            }
        }




        private void ClearData()
        {
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
        }






        private void dgvTable_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCustomerCode.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                txtCustomerName.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                txtPhoneNumber.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                txtAddress.Text = dgvTable.CurrentRow.Cells[4].Value.ToString();
            }
        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (roleMC)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(usernameMC, roleMC, employeeIdMC);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse":
                    {
                        WarehouseForm WarehouseForm = new WarehouseForm(usernameMC, roleMC, employeeIdMC);
                        this.Hide();
                        WarehouseForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm SaleForm = new SaleForm(usernameMC, roleMC, employeeIdMC);
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
            string customerCode = txtCustomerCode.Text;
            string customerName = txtCustomerName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string address = txtAddress.Text;


            // Validate data
            bool isValid = ValidateData(customerCode,
                                        customerName,
                                        phoneNumber,
                                        address);

            if (isValid)
            {
                AddCustomer(customerCode, customerName, phoneNumber, address);
            }
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get user input data
            int customerId = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            string customerCode = txtCustomerCode.Text;
            string customerName = txtCustomerName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string address = txtAddress.Text;

            // Validate data
            bool isValid = ValidateData(customerCode,
                                        customerName,
                                        phoneNumber,
                                        address);

            if (isValid)
            {
                UpdateCustomer(customerId, customerCode, customerName, phoneNumber, address);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                "Do you want to delete this customer?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            int customerId = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            if (result == DialogResult.Yes)
            {
                DeleteCustomer(customerId);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Search = txtSearch.Text;
            SearchCustomer(Search);
        }
    }
}
