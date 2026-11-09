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
    public partial class ManageImportDetail : Form
    {


        private string usernameMIPD;
        private string roleMIPD;
        private int employeeIdMIPD;

        public ManageImportDetail(string usernameAF, string roleAF, int employeeIdAF)
        {
            InitializeComponent();


            usernameMIPD = usernameAF;
            roleMIPD = roleAF;
            employeeIdMIPD = employeeIdAF;

            lbWelcome.Text = "Welcome " + usernameMIPD + "!";

            LoadImportDetailData();

        }



        private void LoadImportDetailData()
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "SELECT * FROM ImportDetail";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvTable.DataSource = table;
                connection.Close();
            }
        }




        private bool ValidateData(string ImportID,
                          string CakeID,
                          string ImportPrice,
                          string Quantity)
        {
            bool isValid = true;

            if (ImportID == null || ImportID == string.Empty)
            {
                MessageBox.Show(
                    "Import ID cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtImportID.Focus();
                isValid = false;
            }
            else if (CakeID == null || CakeID == string.Empty)
            {
                MessageBox.Show(
                    "Cake ID cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtProductID.Focus();
                isValid = false;
            }
            else if (ImportPrice == null || ImportPrice == string.Empty)
            {
                MessageBox.Show(
                    "Import Price cannot be blank",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtImportPrice.Focus();
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
            return isValid;
        }



        private void SearchImportDetail(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadImportDetailData();
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
                    string query = "SELECT * FROM ImportDetail WHERE ImportID LIKE @search " +
                                   "OR CakeID LIKE @search " +
                                   "OR ImportPrice LIKE @search " +
                                   "OR Quantity LIKE @search";

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




        private void AddImportDetail(int ImportID,
                     int CakeID,
                     Decimal ImportPrice,
                     int Quantity)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "INSERT INTO ImportDetail VALUES (@ImportID, " +
                             "@CakeID, @ImportPrice, " +
                             "@Quantity)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("ImportID", ImportID);
                command.Parameters.AddWithValue("CakeID", CakeID);
                command.Parameters.AddWithValue("ImportPrice", ImportPrice);
                command.Parameters.AddWithValue("Quantity", Quantity);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully add new import detail",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    ClearData();
                    LoadImportDetailData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot add new import detail",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                connection.Close();
            }
        }



        private void UpdateImportDetail(int ImportDetailID,
                        int ImportID,
                        int CakeID,
                        decimal ImportPrice,
                        int Quantity)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "UPDATE ImportDetail SET ImportID = @ImportID, " +
                             "CakeID = @CakeID, " +
                             "ImportPrice = @ImportPrice, " +
                             "Quantity = @Quantity " +
                             "WHERE ImportDetailID = @ImportDetailID";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("ImportID", ImportID);
                command.Parameters.AddWithValue("CakeID", CakeID);
                command.Parameters.AddWithValue("ImportPrice", ImportPrice);
                command.Parameters.AddWithValue("Quantity", Quantity);
                command.Parameters.AddWithValue("ImportDetailID", ImportDetailID);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully update import detail",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadImportDetailData();
                }
                else
                {
                    MessageBox.Show(
                        "Cannot update import detail",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                connection.Close();
            }
        }




        private void DeleteImportDetail(int ImportDetailID)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                connection.Open();
                string sql = "DELETE ImportDetail WHERE ImportDetailID = @ImportDetailID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("ImportDetailID", ImportDetailID);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show(
                        "Successfully delete user",
                        "Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ClearData();
                    LoadImportDetailData();
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
            txtImportID.Text = string.Empty;
            txtProductID.Text = string.Empty;
            txtImportPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;


        }


        private void dgvTable_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtImportID.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                txtProductID.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                txtImportPrice.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                txtQuantity.Text = dgvTable.CurrentRow.Cells[4].Value.ToString();

            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (roleMIPD)
            {
                case "Admin":
                    {
                        AdminForm adminForm = new AdminForm(usernameMIPD, roleMIPD, employeeIdMIPD);
                        this.Hide();
                        adminForm.Show();
                        break;
                    }
                case "Warehouse":
                    {
                        WarehouseForm WarehouseForm = new WarehouseForm(usernameMIPD, roleMIPD, employeeIdMIPD);
                        this.Hide();
                        WarehouseForm.Show();
                        break;
                    }
                case "Sale":
                    {
                        SaleForm SaleForm = new SaleForm(usernameMIPD, roleMIPD, employeeIdMIPD);
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
            string ImportID = txtImportID.Text;
            string CakeID = txtProductID.Text;
            string ImportPrice = txtImportPrice.Text;
            string Quantity = txtQuantity.Text;


            // Validate data
            bool isValid = ValidateData(ImportID,
                                        CakeID,
                                        ImportPrice,
                                        Quantity);

            if (isValid)
            {
                int ImportIDInt = Convert.ToInt32(ImportID);
                int CakeIDInt = Convert.ToInt32(CakeID);
                Decimal ImportPriceDec = Convert.ToDecimal(ImportPrice);
                int QuantityInt = Convert.ToInt32(Quantity);

                AddImportDetail(ImportIDInt, CakeIDInt, ImportPriceDec, QuantityInt);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // Get user input data
            int ImportDetailID = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            string ImportID = txtImportID.Text;
            string CakeID = txtProductID.Text;
            string ImportPrice = txtImportPrice.Text;
            string Quantity = txtQuantity.Text;


            // Validate data
            bool isValid = ValidateData(ImportID,
                                        CakeID,
                                        ImportPrice,
                                        Quantity);

            if (isValid)
            {

                int ImportIDInt = Convert.ToInt32(ImportID);
                int CakeIDInt = Convert.ToInt32(CakeID);
                Decimal ImportPriceDec = Convert.ToDecimal(ImportPrice);
                int QuantityInt = Convert.ToInt32(Quantity);

                UpdateImportDetail(ImportDetailID, ImportIDInt, CakeIDInt, ImportPriceDec, QuantityInt);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                "Do you want to delete this Import Detail?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            int employeeId = Convert.ToInt32(dgvTable.CurrentRow.Cells[0].Value);
            if (result == DialogResult.Yes)
            {
                DeleteImportDetail(employeeId);
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            SearchImportDetail(search);
        }
    }

}
