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
    public partial class ManageOrderDetail : Form
    {
        private string usernameMOD;
        private string roleMOD;
        private int employeeIdMOD;

        public ManageOrderDetail(string usernameAF, string roleAF, int employeeIdAF)
        {
            InitializeComponent();

            usernameMOD = usernameAF;
            roleMOD = roleAF;
            employeeIdMOD = employeeIdAF;

            lbWelcome.Text = "Welcome " + usernameMOD + "!";

            LoadOrderDetailData();

        }



        private void LoadOrderDetailData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM OrderDetail";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvTable.DataSource = table;
                connection.Close();
            }
        }




        private bool ValidateData(string OrderID,
                          string CakeID,
                          string Quantity,
                          string UnitPrice)
        {
            bool isValid = true;

            if (OrderID == null || OrderID == string.Empty)
            {
                MessageBox.Show(
                    "Order ID cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtOrderID.Focus();
                isValid = false;
            }
            else if (CakeID == null || CakeID == string.Empty)
            {
                MessageBox.Show(
                    "Product ID cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCakeID.Focus();
                isValid = false;
            }
            else if (Quantity == null || Quantity == string.Empty)
            {
                MessageBox.Show(
                    "Quantity cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtQuantity.Focus();
                isValid = false;
            }
            else if (UnitPrice == null || UnitPrice == string.Empty)
            {
                MessageBox.Show(
                    "Unit Price cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtUnitPrice.Focus();
                isValid = false;
            }

            return isValid;
        }



        private void SearchOrderDetail(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadOrderDetailData();
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
                    string query = "SELECT * FROM OrderDetail WHERE OrderID LIKE @search " +
                                   "OR CakeID LIKE @search " +
                                   "OR Quantity LIKE @search " +
                                   "OR UnitPrice LIKE @search";

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




        private void AddOrderDetail(int OrderID,
                     int CakeID,
                     int Quantity,
                     decimal UnitPrice)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "INSERT INTO OrderDetail VALUES (@OrderID, " +
                             "@CakeID, @Quantity, " +
                             "@UnitPrice)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("OrderID", OrderID);
                command.Parameters.AddWithValue("CakeID", CakeID);
                command.Parameters.AddWithValue("Quantity", Quantity);
                command.Parameters.AddWithValue("UnitPrice", UnitPrice);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully add new Order Detail",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ClearData();
                    LoadOrderDetailData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot add new OrderDetail",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                connection.Close();
            }
        }



        private void UpdateOrderDetail(int OrderDetailID,
                        int OrderID,
                        int CakeID,
                        int Quantity,
                        decimal UnitPrice)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE OrderDetail SET OrderID = @OrderID, " +
                             "CakeID = @CakeID, " +
                             "Quantity = @Quantity, " +
                             "UnitPrice = @UnitPrice " +
                             "WHERE OrderDetailID = @OrderDetailID";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("OrderID", OrderID);
                command.Parameters.AddWithValue("CakeID", CakeID);
                command.Parameters.AddWithValue("Quantity", Quantity);
                command.Parameters.AddWithValue("UnitPrice", UnitPrice);
                command.Parameters.AddWithValue("OrderDetailID", OrderDetailID);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully update Order Detail",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadOrderDetailData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot update Order Detail",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }




        private void DeleteOrderDetail(int OrderDetailID)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "DELETE OrderDetail WHERE OrderDetailID = @OrderDetailID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("OrderDetailID", OrderDetailID);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully delete Order Detail",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadOrderDetailData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot delete Order Detail",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                connection.Close();
            }
        }




        private void ClearData()
        {
            txtOrderID.Text = string.Empty;
            txtCakeID.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
        }




        private void dgvTable_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtOrderID.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                txtCakeID.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                txtQuantity.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                txtUnitPrice.Text = dgvTable.CurrentRow.Cells[4].Value.ToString();

            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (roleMOD)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(usernameMOD, roleMOD, employeeIdMOD);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse":
                    {
                        WarehouseForm WarehouseForm = new WarehouseForm(usernameMOD, roleMOD, employeeIdMOD);
                        this.Hide();
                        WarehouseForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm SaleForm = new SaleForm(usernameMOD, roleMOD, employeeIdMOD);
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
            string OrderID = txtOrderID.Text;
            string CakeID = txtCakeID.Text;
            string Quantity = txtQuantity.Text;
            string UnitPrice = txtUnitPrice.Text;


            // Validate data
            bool isValid = ValidateData(OrderID,
                                        CakeID,
                                        Quantity,
                                        UnitPrice);

            if (isValid)
            {

                int OrderIDInt = Convert.ToInt32(OrderID);
                int CakeIDInt = Convert.ToInt32(CakeID);
                int QuantityInt = Convert.ToInt32(Quantity);
                decimal UnitPriceDec = Convert.ToDecimal(UnitPrice);

                AddOrderDetail(OrderIDInt, CakeIDInt, QuantityInt, UnitPriceDec);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // Get user input data
            int OrderDetailID = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            string OrderID = txtOrderID.Text;
            string CakeID = txtCakeID.Text;
            string Quantity = txtQuantity.Text;
            string UnitPrice = txtUnitPrice.Text;

            // Validate data
            bool isValid = ValidateData(OrderID,
                                        CakeID,
                                        Quantity,
                                        UnitPrice);

            if (isValid)
            {

                int OrderIDInt = Convert.ToInt32(OrderID);
                int CakeIDInt = Convert.ToInt32(CakeID);
                int QuantityInt = Convert.ToInt32(Quantity);
                decimal UnitPriceDec = Convert.ToDecimal(UnitPrice);

                UpdateOrderDetail(OrderDetailID, OrderIDInt, CakeIDInt, QuantityInt, UnitPriceDec);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                "Do you want to delete this OrderDetail?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            int OrderDetailID = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            if (result == DialogResult.Yes)
            {
                DeleteOrderDetail(OrderDetailID);
            }
        }            

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            SearchOrderDetail(search);
        }
    }


}
