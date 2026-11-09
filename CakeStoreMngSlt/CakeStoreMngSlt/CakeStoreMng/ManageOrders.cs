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

namespace CakeStoreMng
{
    public partial class ManageOrders : Form
    {

        private string usernameMO;
        private string roleMO;
        private int employeeIdMO;

        public ManageOrders(string usernameAF, string roleAF, int employeeIdAF)
        {
            InitializeComponent();

            usernameMO = usernameAF;
            roleMO = roleAF;
            employeeIdMO = employeeIdAF;

            lbWelcome.Text = "Welcome " + usernameMO + "!";

            LoadOrdersData();

        }



        private void LoadOrdersData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Orders";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvTable.DataSource = table;
                connection.Close();
            }
        }




        private bool ValidateData(string OrderDate,
                          string EmployeeID,
                          string CustomerID,
                          string TotalMount)
        {
            bool isValid = true;

            if (OrderDate == null || OrderDate == string.Empty)
            {
                MessageBox.Show(
                    "Order Date cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtOrderDate.Focus();
                isValid = false;
            }
            else if (EmployeeID == null || EmployeeID == string.Empty)
            {
                MessageBox.Show(
                    "Employee ID cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtEmployeeID.Focus();
                isValid = false;
            }
            else if (CustomerID == null || CustomerID == string.Empty)
            {
                MessageBox.Show(
                    "Customer ID cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCustomerID.Focus();
                isValid = false;
            }
            else if (TotalMount == null || TotalMount == string.Empty)
            {
                MessageBox.Show(
                    "TotalMount cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtTotalMount.Focus();
                isValid = false;
            }

            return isValid;
        }



        private void SearchOrders(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadOrdersData();
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
                    string query = "SELECT * FROM Orders WHERE OrderDate LIKE @search " +
                                   "OR EmployeeID LIKE @search " +
                                   "OR CustomerID LIKE @search " +
                                   "OR TotalMount LIKE @search";

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




        private void AddUser(DateTime OrderDate,
                     int EmployeeID,
                     int CustomerID,
                     int TotalMount)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "INSERT INTO Orders VALUES (@OrderDate, " +
                             "@EmployeeID, @CustomerID, " +
                             "@TotalMount)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("OrderDate", OrderDate);
                command.Parameters.AddWithValue("EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("CustomerID", CustomerID);
                command.Parameters.AddWithValue("TotalMount", TotalMount);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully add new Order",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ClearData();
                    LoadOrdersData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot add new Order",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                connection.Close();
            }
        }



        private void UpdateUser(int OrderID,
                        DateTime OrderDate,
                        int EmployeeID,
                        int CustomerID,
                        int TotalMount)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE Orders SET OrderDate = @OrderDate, " +
                             "EmployeeID = @EmployeeID, " +
                             "CustomerID = @CustomerID, " +
                             "TotalMount = @TotalMount " +
                             "WHERE OrderID = @OrderID";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("OrderDate", OrderDate);
                command.Parameters.AddWithValue("EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("CustomerID", CustomerID);
                command.Parameters.AddWithValue("TotalMount", TotalMount);
                command.Parameters.AddWithValue("OrderID", OrderID);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully update Order",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadOrdersData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot update Order",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }




        private void DeleteUser(int OrderID)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "DELETE Orders WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("OrderID", OrderID);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully delete Order",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadOrdersData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot delete Order",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                connection.Close();
            }
        }




        private void ClearData()
        {
            txtOrderDate.Text = string.Empty;
            txtEmployeeID.Text = string.Empty;
            txtTotalMount.Text = string.Empty;
            txtCustomerID.Text = string.Empty;
        }




        private void dgvTable_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtOrderDate.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                txtEmployeeID.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                txtCustomerID.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                txtTotalMount.Text = dgvTable.CurrentRow.Cells[4].Value.ToString();
            }
        }





        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (roleMO)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(usernameMO, roleMO, employeeIdMO);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse":
                    {
                        WarehouseForm WarehouseForm = new WarehouseForm(usernameMO, roleMO, employeeIdMO);
                        this.Hide();
                        WarehouseForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm SaleForm = new SaleForm(usernameMO, roleMO, employeeIdMO);
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
    



                private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Get user input data
            string OrderDate = txtOrderDate.Text;
            string EmployeeID = txtEmployeeID.Text;
            string CustomerID = txtCustomerID.Text;
            string TotalMount = txtTotalMount.Text;

            // Validate data
            bool isValid = ValidateData(OrderDate,
                                        EmployeeID,
                                        CustomerID,
                                        TotalMount);

            if (isValid)
            {

                DateTime OrderDateDt =  DateTime.Parse(OrderDate);
                int EmployeeIDInt = Convert.ToInt32(EmployeeID);
                int CustomerIDInt = Convert.ToInt32(CustomerID);
                int TotalMountInt = Convert.ToInt32(TotalMount);

                AddUser(OrderDateDt, EmployeeIDInt, CustomerIDInt, TotalMountInt);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // Get user input data
            int OrderID = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            string OrderDate = txtOrderDate.Text;
            string EmployeeID = txtEmployeeID.Text;
            string CustomerID = txtCustomerID.Text;
            string TotalMount = txtTotalMount.Text;

            // Validate data
            bool isValid = ValidateData(OrderDate,
                                        EmployeeID,
                                        CustomerID,
                                        TotalMount);

            if (isValid)
            {

                DateTime OrderDateDt = DateTime.Parse(OrderDate);
                int EmployeeIDInt = Convert.ToInt32(EmployeeID);
                int CustomerIDInt = Convert.ToInt32(CustomerID);
                int TotalMountInt = Convert.ToInt32(TotalMount);

                UpdateUser(OrderID, OrderDateDt, EmployeeIDInt, CustomerIDInt, TotalMountInt);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                "Do you want to delete this user?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            int OrderID = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            if (result == DialogResult.Yes)
            {
                DeleteUser(OrderID);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            SearchOrders(search);
        }
    }

}
