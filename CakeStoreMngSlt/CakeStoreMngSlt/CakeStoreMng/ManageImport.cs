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
    public partial class ManageImport : Form
    {

        private string usernameMI;
        private string roleMI;
        private int employeeIdMI;
        public ManageImport(string usernameAF, string roleAF, int employeeIdAF)
        {
            InitializeComponent();

            usernameMI = usernameAF;
            roleMI = roleAF;
            employeeIdMI = employeeIdAF;

            lbWelcome.Text = "Welcome " + usernameMI + "!";

            LoadManageImportData();

        }


        private void LoadManageImportData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM Import";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvTable.DataSource = table;
                connection.Close();
            }
        }


        
 
        private bool ValidateData(string ImportDate,
                          string EmployeeID)
        {
            bool isValid = true;

            if (ImportDate == null || ImportDate == string.Empty)
            {
                MessageBox.Show(
                    "Import Date cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtImportDate.Focus();
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

            return isValid;
        }



        private void SearchImport(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadManageImportData();
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
                    string query = "SELECT * FROM Import WHERE ImportDate LIKE @search " +
                                   "OR EmployeeID LIKE @search";

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




        private void AddImport(DateTime ImportDate,
                     int EmployeeID)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "INSERT INTO Import VALUES (@ImportDate, " +
                             "@EmployeeID)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("ImportDate", ImportDate);
                command.Parameters.AddWithValue("EmployeeID", EmployeeID);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully add new import",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ClearData();
                    LoadManageImportData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot add new import",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                connection.Close();
            }
        }



        private void UpdateImport(int ImportID,
                        DateTime ImportDate,
                        int EmployeeID)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE Import SET ImportDate = @ImportDate, " +
                             "EmployeeID = @EmployeeID " +
                             "WHERE ImportID = @ImportID";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("ImportDate", ImportDate);
                command.Parameters.AddWithValue("EmployeeID", EmployeeID);
                command.Parameters.AddWithValue("ImportID", ImportID);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully update import",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadManageImportData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot update import",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }




        private void DeleteImport(int importId)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "DELETE Import WHERE ImportId = @importId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("importId", importId);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully delete import",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadManageImportData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot delete import",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                connection.Close();
            }
        }




        private void ClearData()
        {
            txtImportDate.Text = string.Empty;
            txtEmployeeID.Text = string.Empty;

        }



        private void dgvTable_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtImportDate.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                txtEmployeeID.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (roleMI)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(usernameMI, roleMI, employeeIdMI);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse":
                    {
                        WarehouseForm WarehouseForm = new WarehouseForm(usernameMI, roleMI, employeeIdMI);
                        this.Hide();
                        WarehouseForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm SaleForm = new SaleForm(usernameMI, roleMI, employeeIdMI);
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



        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Get user input data
            string ImportDate = txtImportDate.Text;
            string EmployeeID = txtEmployeeID.Text;

            // Validate data
            bool isValid = ValidateData(ImportDate,
                                        EmployeeID);

            if (isValid)
            {
                DateTime ImportDateDt = Convert.ToDateTime(txtImportDate.Text);
                int EmployeeIDInt = Convert.ToInt32(txtEmployeeID.Text);

                AddImport(ImportDateDt, EmployeeIDInt);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // Get user input data
            int importId = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            string importDate = txtImportDate.Text;
            string employeeID = txtEmployeeID.Text;

            // Validate data
            bool isValid = ValidateData(importDate,
                                        employeeID);

            if (isValid)
            {
                DateTime ImportDateDt = Convert.ToDateTime(importDate);
                int EmployeeIDInt = Convert.ToInt32(employeeID);

                UpdateImport(importId, ImportDateDt, EmployeeIDInt);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                "Do you want to delete this import?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            int importID = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            if (result == DialogResult.Yes)
            {
                DeleteImport(importID);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            SearchImport(search);
        }
    }
}
