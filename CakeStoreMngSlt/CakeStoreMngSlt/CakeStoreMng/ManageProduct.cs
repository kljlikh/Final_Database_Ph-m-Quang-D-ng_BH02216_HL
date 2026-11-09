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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CakeStoreMng
{
    public partial class ManageProduct : Form
    {

        private string usernameMP;
        private string roleMP;
        private int employeeIdMP;

        public ManageProduct(string usernameAF, string roleAF, int employeeIdAF)
        {
            InitializeComponent();

            usernameMP = usernameAF;
            roleMP = roleAF;
            employeeIdMP = employeeIdAF;

            lbWelcome.Text = "Welcome " + usernameMP + "!";

            LoadProductData();

        }


        private void LoadProductData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Cake";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvTable.DataSource = table;
                connection.Close();
            }
        }




        private bool ValidateData(string CakeCode,
                          string Cakename,
                          string UnitPrice,
                          string CategoryID,
                          string StockQuantity)
        {
            bool isValid = true;

            if (CakeCode == null || CakeCode == string.Empty)
            {
                MessageBox.Show(
                    "Product Code Code cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtProductCode.Focus();
                isValid = false;
            }
            else if (Cakename == null || Cakename == string.Empty)
            {
                MessageBox.Show(
                    "Product Name cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtProductName.Focus();
                isValid = false;
            }
            else if (UnitPrice == null || UnitPrice == string.Empty)
            {
                MessageBox.Show(
                    "Unit Price cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtProductName.Focus();
                isValid = false;
            }
            else if (CategoryID == null || CategoryID == string.Empty)
            {
                MessageBox.Show(
                    "Category ID cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtUnitPrice.Focus();
                isValid = false;
            }
            else if (StockQuantity == null || StockQuantity == string.Empty)
            {
                MessageBox.Show(
                    "Stock Quantity cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                isValid = false;
            }

            return isValid;
        }



        private void SearchProduct(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadProductData();
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
                    string query = "SELECT * FROM Cake WHERE CakeCode LIKE @search " +
                                   "OR Cakename LIKE @search " +
                                   "OR UnitPrice LIKE @search " +
                                   "OR CategoryID LIKE @search " +
                                   "OR StockQuantity LIKE @search";

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




        private void AddProduct(string CakeCode,
                          string Cakename,
                          decimal UnitPrice,
                          int CategoryID,
                          int StockQuantity)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "INSERT INTO Cake VALUES (@cakeCode, " +
                             "@Cakename, @UnitPrice, " +
                             "@CategoryID, @StockQuantity)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("cakeCode", CakeCode);
                command.Parameters.AddWithValue("cakename", Cakename);
                command.Parameters.AddWithValue("unitPrice", UnitPrice);
                command.Parameters.AddWithValue("categoryID", CategoryID);
                command.Parameters.AddWithValue("stockQuantity", StockQuantity);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully add new product",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ClearData();
                    LoadProductData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot add new product",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                connection.Close();
            }
        }



        private void UpdateProduct(int CakeID,
                        string CakeCode,
                        string Cakename,
                        decimal UnitPrice,
                        int CategoryID,
                        int StockQuantity)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE Cake SET CakeCode = @CakeCode, " +
                             "Cakename = @Cakename, " +
                             "UnitPrice = @UnitPrice, " +
                             "CategoryID = @CategoryID, " +
                             "StockQuantity = @StockQuantity " +
                             "WHERE CakeID = @CakeID";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("cakeID", CakeID);
                command.Parameters.AddWithValue("cakeCode", CakeCode);
                command.Parameters.AddWithValue("cakename", Cakename);
                command.Parameters.AddWithValue("unitPrice", UnitPrice);
                command.Parameters.AddWithValue("categoryID", CategoryID);
                command.Parameters.AddWithValue("stockQuantity", StockQuantity);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully update product",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadProductData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot update product",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }




        private void DeleteProduct(int CakeID)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "DELETE Cake WHERE CakeID = @CakeID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("CakeID", CakeID);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully delete product",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadProductData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot delete product",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                connection.Close();
            }
        }




        private void ClearData()
        {
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtCategoryID.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtStockQuantity.Text = string.Empty;
;
        }



        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtProductCode.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                txtProductName.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                txtUnitPrice.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                txtCategoryID.Text = dgvTable.CurrentRow.Cells[4].Value.ToString();
                txtStockQuantity.Text = dgvTable.CurrentRow.Cells[5].Value.ToString();
            }
        }




        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (roleMP)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(usernameMP, roleMP, employeeIdMP);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse":
                    {
                        WarehouseForm WarehouseForm = new WarehouseForm(usernameMP, roleMP, employeeIdMP);
                        this.Hide();
                        WarehouseForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm SaleForm = new SaleForm(usernameMP, roleMP, employeeIdMP);
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
            string CakeCode = txtProductCode.Text;
            string Cakename = txtProductName.Text;
            string UnitPrice = txtCategoryID.Text;
            string CategoryID = txtUnitPrice.Text;
            string StockQuantity = txtStockQuantity.Text;

            // Validate data
            bool isValid = ValidateData(CakeCode,
                                        Cakename,
                                        UnitPrice,
                                        CategoryID,
                                        StockQuantity);

            if (isValid)
            {
                decimal UnitPriceDec = decimal.Parse(txtUnitPrice.Text);
                int CategoryIDInt = Convert.ToInt32(txtCategoryID.Text);
                int StockQuantityInt = Convert.ToInt32(txtStockQuantity.Text);

                AddProduct(CakeCode, Cakename, UnitPriceDec, CategoryIDInt, StockQuantityInt);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get user input data
            int CakeID = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            string CakeCode = txtProductCode.Text;
            string Cakename = txtProductName.Text;
            string UnitPrice = txtCategoryID.Text;
            string CategoryID = txtUnitPrice.Text;
            string StockQuantity = txtStockQuantity.Text;

            // Validate data
            bool isValid = ValidateData(CakeCode,
                                        Cakename,
                                        UnitPrice,
                                        CategoryID,
                                        StockQuantity);

            if (isValid)
            {
                decimal UnitPriceDec = decimal.Parse(txtUnitPrice.Text);
                int CategoryIDInt = Convert.ToInt32(txtCategoryID.Text);
                int StockQuantityInt = Convert.ToInt32(txtStockQuantity.Text);

                UpdateProduct(CakeID, CakeCode, Cakename, UnitPriceDec, CategoryIDInt, StockQuantityInt);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                "Do you want to delete this product?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            int CakeID = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            if (result == DialogResult.Yes)
            {
                DeleteProduct(CakeID);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            SearchProduct(search);
        }
    }
}
