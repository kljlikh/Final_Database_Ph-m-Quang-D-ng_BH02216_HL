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
    public partial class ManageCategory : Form
    {

        private string usernameMC;
        private string roleMC;
        private int employeeIdMC;




        public ManageCategory(string usernameAF, string roleAF, int employeeIdAF)
        {
            InitializeComponent();

            usernameMC = usernameAF;
            roleMC = roleAF;
            employeeIdMC = employeeIdAF;

            lbWelcome.Text = "Welcome " + usernameMC + "!";

            LoadCategoryData();
        }




        private void LoadCategoryData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Category";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvTable.DataSource = table;
                connection.Close();
            }
        }




        private bool ValidateData(string CategoryName)
        {
            bool isValid = true;


            if (CategoryName == null || CategoryName == string.Empty)
            {
                MessageBox.Show(
                    "Category Name cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtCategoryName.Focus();
                isValid = false;
            }

            return isValid;
        }



        private void SearchCategory(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadCategoryData();
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
                    string query = "SELECT * FROM Category WHERE categoryName LIKE @search";

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





        private void AddCategory(string CategoryName)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "INSERT INTO Category VALUES (@CategoryName)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("CategoryName", CategoryName);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully add new category",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ClearData();
                    LoadCategoryData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot add new category",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                connection.Close();
            }
        }



        private void UpdateCategory(int CategoryId, string CategoryName)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE Category SET CategoryName = @CategoryName " +
                             "WHERE CategoryID = @CategoryId";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("CategoryName", CategoryName);
                command.Parameters.AddWithValue("CategoryId", CategoryId);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully update category",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadCategoryData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot update category",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }




        private void DeleteCategory(int CategoryId)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "DELETE Category WHERE CategoryID = @CategoryId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("CategoryId", CategoryId);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully delete category",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadCategoryData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot delete category",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                connection.Close();
            }
        }




        private void ClearData()
        {
            txtCategoryName.Text = string.Empty;
        }





        private void dgvTable_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCategoryName.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
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
            string CategoryName = txtCategoryName.Text;


            // Validate data
            bool isValid = ValidateData(CategoryName);

            if (isValid)
            {
                AddCategory(CategoryName);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get user input data
            int categoryId = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            string employeeName = txtCategoryName.Text;


            // Validate data
            bool isValid = ValidateData(employeeName);

            if (isValid)
            {
                UpdateCategory(categoryId, employeeName);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                "Do you want to delete this category?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            int categoryId = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            if (result == DialogResult.Yes)
            {
                DeleteCategory(categoryId);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Search = txtSearch.Text;
            SearchCategory(Search);
        }
    }
}
