using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CakeStoreMng
{
    public partial class Admin : Form
    {
        private string currentUser;   // Biến lưu tên người đăng nhập
        private string currentrole;
        private int currentemployeeId;
        public Admin(string  username, string role, int employeeId)
        {
            InitializeComponent();    // Khởi tạo giao diện Form Admin
            currentUser = username;   // Gán giá trị nhận được từ Form Login
            currentrole = role;   // Gán giá trị nhận được từ Form Login
            currentemployeeId = employeeId;   // Gán giá trị nhận được từ Form Login

        }


        // HAM CHAY FORM +  KET NOI VOI DATABASE
        private void Admin_Load_1(object sender, EventArgs e)
        {
            lbWelcome.Text = $"Welcome {currentUser} (Admin)!";

            string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_Mng;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            

        }


        private void lbUser_Click(object sender, EventArgs e)
        {

        }


        // ANH NEN (BACKGROUD)
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        // CAC HAM BANG TU DATABASE
        private void LoadCategoryData()
        {
            string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
            string query = "SELECT CategoryID, categoryName FROM Category";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTable.DataSource = dt;
                // Tự động điều chỉnh kích thước cột vừa nội dung
                dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Cho phép hiển thị tiêu đề cột rõ ràng
                dgvTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Cho phép cuộn ngang nếu nội dung dài
                dgvTable.ScrollBars = ScrollBars.Both;

            }
        }

        private void LoadCakeData()
        {
            string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
            string query = "SELECT CakeID, CakeCode, Cakename, UnitPrice, CategoryID, StockQuantity  FROM Cake";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTable.DataSource = dt;
                // Tự động điều chỉnh kích thước cột vừa nội dung
                dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Cho phép hiển thị tiêu đề cột rõ ràng
                dgvTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Cho phép cuộn ngang nếu nội dung dài
                dgvTable.ScrollBars = ScrollBars.Both;

            }
        }

        private void LoadEmployeeData()
        {
            string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
            string query = "SELECT EmployeeID, EmployeeCode, EmployeeName, Position, Password  FROM Employee";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTable.DataSource = dt;
                // Tự động điều chỉnh kích thước cột vừa nội dung
                dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Cho phép hiển thị tiêu đề cột rõ ràng
                dgvTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Cho phép cuộn ngang nếu nội dung dài
                dgvTable.ScrollBars = ScrollBars.Both;

            }
        }

        private void LoadCustomerData()
        {
            string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
            string query = "SELECT CustomerID, CustomerCode, CustomerName, PhoneNumber, Address  FROM Customer";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTable.DataSource = dt;
                // Tự động điều chỉnh kích thước cột vừa nội dung
                dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Cho phép hiển thị tiêu đề cột rõ ràng
                dgvTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Cho phép cuộn ngang nếu nội dung dài
                dgvTable.ScrollBars = ScrollBars.Both;

            }
        }

        private void LoadOrdersData()
        {
            string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
            string query = "SELECT OrderID, OrderDate, EmployeeID, CustomerID, TotalMount  FROM Orders";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTable.DataSource = dt;
                // Tự động điều chỉnh kích thước cột vừa nội dung
                dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Cho phép hiển thị tiêu đề cột rõ ràng
                dgvTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Cho phép cuộn ngang nếu nội dung dài
                dgvTable.ScrollBars = ScrollBars.Both;

            }
        }

        private void LoadOrderDetailData()
        {
            string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
            string query = "SELECT OrderDetailID, OrderID, CakeID, Quantity, UnitPrice  FROM OrderDetail";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTable.DataSource = dt;
                // Tự động điều chỉnh kích thước cột vừa nội dung
                dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Cho phép hiển thị tiêu đề cột rõ ràng
                dgvTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Cho phép cuộn ngang nếu nội dung dài
                dgvTable.ScrollBars = ScrollBars.Both;

            }
        }

        private void LoadImportData()
        {
            string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
            string query = "SELECT ImportID, ImportDate, EmployeeID  FROM Import";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTable.DataSource = dt;
                // Tự động điều chỉnh kích thước cột vừa nội dung
                dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Cho phép hiển thị tiêu đề cột rõ ràng
                dgvTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Cho phép cuộn ngang nếu nội dung dài
                dgvTable.ScrollBars = ScrollBars.Both;

            }
        }

        private void LoadImportDetailData()
        {
            string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
            string query = "SELECT ImportDetailID, ImportID, CakeID, ImportPrice, Quantity  FROM ImportDetail";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTable.DataSource = dt;
                // Tự động điều chỉnh kích thước cột vừa nội dung
                dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Cho phép hiển thị tiêu đề cột rõ ràng
                dgvTable.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                // Cho phép cuộn ngang nếu nội dung dài
                dgvTable.ScrollBars = ScrollBars.Both;

            }
        }


        // SU KIEN THAY DOI BANG (TEXT CHANGED)
        private void cbbSurvice_TextChanged(object sender, EventArgs e)
        {
            string survice = cbbSurvice.Text;
            if (survice == "Category")
            {
                LoadCategoryData();
                ClearData();

                lbInfor1.Visible = true;
                txtInfor1.Visible= true;

                lbInfor2.Visible = true;
                txtInfor2.Visible = true;

                lbInfor3.Visible = false;
                txtInfor3.Visible = false;

                lbInfor4.Visible = false;
                txtInfor4.Visible = false;
                cbbInfor4.Visible = false;

                lbInfor5.Visible = false;
                txtInfor5.Visible = false;

                lbInfor6.Visible = false;
                txtInfor6.Visible = false;

                lbInfor1.Text = "CategoryID";
                lbInfor2.Text = "categoryName";

          
            }
            else if (survice == "Cake")
            {

                LoadCakeData();
                ClearData();


                lbInfor1.Visible = true;
                txtInfor1.Visible = true;

                lbInfor2.Visible = true;
                txtInfor2.Visible = true;

                lbInfor3.Visible = true;
                txtInfor3.Visible = true;

                lbInfor4.Visible = true;
                txtInfor4.Visible = true;
                cbbInfor4.Visible = false;

                lbInfor5.Visible = true;
                txtInfor5.Visible = true;

                lbInfor6.Visible = true;
                txtInfor6.Visible = true;

                lbInfor1.Text = "CakeID";
                lbInfor2.Text = "CakeCode";
                lbInfor3.Text = "Cakename";
                lbInfor4.Text = "UnitPrice";
                lbInfor5.Text = "CategoryID";
                lbInfor6.Text = "StockQuantity";
            }
            else if (survice == "Employee")
            {
                LoadEmployeeData();
                ClearData();

                lbInfor1.Visible = true;
                txtInfor1.Visible = true;

                lbInfor2.Visible = true;
                txtInfor2.Visible = true;

                lbInfor3.Visible = true;
                txtInfor3.Visible = true;

                lbInfor4.Visible = true;
                txtInfor4.Visible = false;
                cbbInfor4.Visible = true;

                lbInfor5.Visible = true;
                txtInfor5.Visible = true;
                
                lbInfor6.Visible = false;
                txtInfor6.Visible = false;


                lbInfor1.Text = "EmployeeID"; 
                lbInfor2.Text = "EmployeeCode";
                lbInfor3.Text = "EmployeeName";
                lbInfor4.Text = "Position";
                lbInfor5.Text = "Password";

            }
            else if (survice == "Customer")
            {
                LoadCustomerData();
                ClearData();


                lbInfor1.Visible = true;
                txtInfor1.Visible = true;

                lbInfor2.Visible = true;
                txtInfor2.Visible = true;

                lbInfor3.Visible = true;
                txtInfor3.Visible = true;

                lbInfor4.Visible = true;
                txtInfor4.Visible = true;
                cbbInfor4.Visible = false;

                lbInfor5.Visible = false;
                txtInfor5.Visible = false;

                lbInfor6.Visible = false;
                txtInfor6.Visible = false;


                lbInfor1.Text = "CustomerID";
                lbInfor2.Text = "CustomerCode";
                lbInfor3.Text = "CustomerName";
                lbInfor4.Text = "PhoneNumber";
            }
            else if (survice == "Orders")
            {
                LoadOrdersData();
                ClearData();


                lbInfor1.Visible = true;
                txtInfor1.Visible = true;

                lbInfor2.Visible = true;
                txtInfor2.Visible = true;

                lbInfor3.Visible = true;
                txtInfor3.Visible = true;

                lbInfor4.Visible = true;
                txtInfor4.Visible = true;
                cbbInfor4.Visible = false;

                lbInfor5.Visible = true;
                txtInfor5.Visible = true;

                lbInfor6.Visible = false;
                txtInfor6.Visible = false;

                lbInfor1.Text = "OrderID";
                lbInfor2.Text = "OrderDate";
                lbInfor3.Text = "EmployeeID";
                lbInfor4.Text = "CustomerID";
                lbInfor5.Text = "TotalMount";
            }
            else if (survice == "OrderDetail")
            {
                LoadOrderDetailData();
                ClearData();


                lbInfor1.Visible = true;
                txtInfor1.Visible = true;

                lbInfor2.Visible = true;
                txtInfor2.Visible = true;

                lbInfor3.Visible = true;
                txtInfor3.Visible = true;

                lbInfor4.Visible = true;
                txtInfor4.Visible = true;
                cbbInfor4.Visible = false;

                lbInfor5.Visible = true;
                txtInfor5.Visible = true;

                lbInfor6.Visible = false;
                txtInfor6.Visible = false;


                lbInfor1.Text = "OrderDetailID";
                lbInfor2.Text = "OrderID";
                lbInfor3.Text = "CakeID";
                lbInfor4.Text = "Quantity";
                lbInfor5.Text = "UnitPrice";
            }
            else if (survice == "Import")
            {
                LoadImportData();
                ClearData();


                lbInfor1.Visible = true;
                txtInfor1.Visible = true;

                lbInfor2.Visible = true;
                txtInfor2.Visible = true;

                lbInfor3.Visible = true;
                txtInfor3.Visible = true;

                lbInfor4.Visible = false;
                txtInfor4.Visible = false;
                cbbInfor4.Visible = false;

                lbInfor5.Visible = false;
                txtInfor5.Visible = false;

                lbInfor6.Visible = false;
                txtInfor6.Visible = false;

                lbInfor1.Text = "ImportID";
                lbInfor2.Text = "ImportDate";
                lbInfor3.Text = "EmployeeID";

            }
            else if (survice == "ImportDetail")
            {
                LoadImportDetailData();
                ClearData();


                lbInfor1.Visible = true;
                txtInfor1.Visible = true;

                lbInfor2.Visible = true;
                txtInfor2.Visible = true;

                lbInfor3.Visible = true;
                txtInfor3.Visible = true;

                lbInfor4.Visible = true;
                txtInfor4.Visible = true;
                cbbInfor4.Visible = false;

                lbInfor5.Visible = true;
                txtInfor5.Visible = true;

                lbInfor6.Visible = false;
                txtInfor6.Visible = false;


                lbInfor1.Text = "ImportDetailID";
                lbInfor2.Text = "ImportID";
                lbInfor3.Text = "CakeID";
                lbInfor4.Text = "ImportPrice";
                lbInfor5.Text = "Quantity";
            }
            else
            {
                MessageBox.Show("Please select a valid survice!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        // SU KIEN CLICK DGV
        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string survice = cbbSurvice.Text;
            if (e.RowIndex >= 0)
            {
                if (survice == "Category")
                {
                    txtInfor1.Text = dgvTable.CurrentRow.Cells[0].Value.ToString();
                    txtInfor2.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();

                }
                else if (survice == "Cake")
                {
                    txtInfor1.Text = dgvTable.CurrentRow.Cells[0].Value.ToString();
                    txtInfor2.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                    txtInfor3.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                    txtInfor4.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                    txtInfor5.Text = dgvTable.CurrentRow.Cells[4].Value.ToString();
                    txtInfor6.Text = dgvTable.CurrentRow.Cells[5].Value.ToString();
                }
                else if (survice == "Employee")
                {
                    txtInfor1.Text = dgvTable.CurrentRow.Cells[0].Value.ToString();
                    txtInfor2.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                    txtInfor3.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                    cbbInfor4.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                    txtInfor5.Text = dgvTable.CurrentRow.Cells[4].Value.ToString();
                }
                else if (survice == "Customer")
                {
                    txtInfor1.Text = dgvTable.CurrentRow.Cells[0].Value.ToString();
                    txtInfor2.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                    txtInfor3.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                    txtInfor4.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                }
                else if (survice == "Orders")
                {
                    txtInfor1.Text = dgvTable.CurrentRow.Cells[0].Value.ToString();
                    txtInfor2.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                    txtInfor3.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                    txtInfor4.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                    txtInfor5.Text = dgvTable.CurrentRow.Cells[4].Value.ToString();
                }
                else if (survice == "OrderDetail")
                {
                    txtInfor1.Text = dgvTable.CurrentRow.Cells[0].Value.ToString();
                    txtInfor2.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                    txtInfor3.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                    txtInfor4.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                    txtInfor5.Text = dgvTable.CurrentRow.Cells[4].Value.ToString();
                }
                else if (survice == "Import")
                {
                    txtInfor1.Text = dgvTable.CurrentRow.Cells[0].Value.ToString();
                    txtInfor2.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                    txtInfor3.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                }
                else if (survice == "ImportDetail")
                {
                    txtInfor1.Text = dgvTable.CurrentRow.Cells[0].Value.ToString();
                    txtInfor2.Text = dgvTable.CurrentRow.Cells[1].Value.ToString();
                    txtInfor3.Text = dgvTable.CurrentRow.Cells[2].Value.ToString();
                    txtInfor4.Text = dgvTable.CurrentRow.Cells[3].Value.ToString();
                    txtInfor5.Text = dgvTable.CurrentRow.Cells[4].Value.ToString();
                }
            }
        }


        //CLEAR DATA
        private void ClearData()
        {
            txtInfor1.Clear();
            txtInfor2.Clear();
            txtInfor3.Clear();
            txtInfor4.Clear();
            txtInfor5.Clear();
            txtInfor6.Clear();
            cbbInfor4.Text = string.Empty;

        }




        // UPDATE BUTTON
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string survice = cbbSurvice.Text;

            if (survice == "Category")
            {
                // 1️ Lấy thông tin từ các textbox
                string CategoryID = txtInfor1.Text;
                string CategoryName = txtInfor2.Text;

                // 2️ Viết câu lệnh SQL Update
                string query = @"UPDATE Category SET 
                                     CategoryName = @CategoryName
                                        WHERE CategoryID = @CategoryID";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryName", CategoryName);


                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCategoryData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Cake")
            {
                // 1️ Lấy thông tin từ các textbox
                string CakeID = txtInfor1.Text;
                string CakeCode = txtInfor2.Text;
                string CakeName = txtInfor3.Text;
                decimal UnitPrice = Convert.ToDecimal(txtInfor4.Text);
                string CategoryID = txtInfor5.Text;
                string StockQuantity = txtInfor6.Text;

                // 2️ Viết câu lệnh SQL Update
                string query = @"UPDATE Cake SET 
                                     CakeCode = @CakeCode,
                                     CakeName = @CakeName,
                                     UnitPrice = @UnitPrice,
                                     CategoryID = @CategoryID,
                                     StockQuantity = @StockQuantity
                                        WHERE CakeID = @CakeID";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CakeID", CakeID);
                    cmd.Parameters.AddWithValue("@CakeCode", CakeCode);
                    cmd.Parameters.AddWithValue("@CakeName", CakeName);
                    cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = UnitPrice;
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                    cmd.Parameters.AddWithValue("@StockQuantity", StockQuantity);


                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCakeData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Employee") 
            {
                // 1️ Lấy thông tin từ các textbox
                string EmployeeID = txtInfor1.Text;
                string EmployeeCode = txtInfor2.Text;
                string EmployeeName = txtInfor3.Text;
                string Position = cbbInfor4.Text;
                string Password = txtInfor5.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = @"UPDATE Employee SET 
                                     EmployeeCode = @EmployeeCode, 
                                     EmployeeName = @EmployeeName, 
                                     Position = @Position, 
                                     Password = @Password 
                                        WHERE EmployeeID = @EmployeeID";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    cmd.Parameters.AddWithValue("@EmployeeCode", EmployeeCode);
                    cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                    cmd.Parameters.AddWithValue("@Position", Position);
                    cmd.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployeeData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Customer")
            {
                // 1️ Lấy thông tin từ các textbox
                string CustomerID = txtInfor1.Text;
                string CustomerCode = txtInfor2.Text;
                string CustomerName = txtInfor3.Text;
                string PhoneNumber = txtInfor4.Text;
                string Address = txtInfor4.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = @"UPDATE Customer SET 
                                     CustomerCode = @CustomerCode, 
                                     CustomerName = @CustomerName, 
                                     PhoneNumber = @PhoneNumber 
                                     Address = @Address 
                                        WHERE CustomerID = @CustomerID";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@CustomerCode", CustomerCode);
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", Address);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomerData();

                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Orders")
            {
                // 1️ Lấy thông tin từ các textbox
                string OrderID = txtInfor1.Text;
                string OrderDate = txtInfor2.Text;
                string EmployeeID = txtInfor3.Text;
                string CustomerID = txtInfor4.Text;
                string TotalMount = txtInfor5.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = @"UPDATE Orders SET 
                                     OrderDate = @OrderDate, 
                                     EmployeeID = @EmployeeID, 
                                     CustomerID = @CustomerID, 
                                     TotalMount = @TotalMount 
                                        WHERE OrderID = @OrderID";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Parse(txtInfor2.Text));
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@TotalMount", TotalMount);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrdersData();

                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "OrderDetail")
            {
                // 1️ Lấy thông tin từ các textbox
                string OrderDetailID = txtInfor1.Text;
                string OrderID = txtInfor2.Text;
                string CakeID = txtInfor3.Text;
                string Quantity = txtInfor4.Text;
                decimal UnitPrice = Convert.ToDecimal(txtInfor5.Text);


                // 2️ Viết câu lệnh SQL Update
                string query = @"UPDATE OrderDetail SET 
                                     OrderID = @OrderID, 
                                     CakeID = @CakeID, 
                                     Quantity = @Quantity,
                                     UnitPrice = @UnitPrice 
                                        WHERE OrderDetailID = @OrderDetailID";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderDetailID", OrderDetailID);
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    cmd.Parameters.AddWithValue("@CakeID", CakeID);
                    cmd.Parameters.AddWithValue("@Quantity", Quantity);
                    cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = UnitPrice;

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrderDetailData();
 
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Import")
            {
                // 1️ Lấy thông tin từ các textbox
                string ImportID = txtInfor1.Text;
                string ImportDate = txtInfor2.Text;
                string EmployeeID = txtInfor3.Text;



                // 2️ Viết câu lệnh SQL Update
                string query = @"UPDATE Import SET 
                                     ImportDate = @ImportDate, 
                                     EmployeeID = @EmployeeID 
                                        WHERE ImportID = @ImportID";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ImportID", ImportID);
                    cmd.Parameters.AddWithValue("@ImportDate", ImportDate);
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadImportData();

                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "ImportDetail")
            {
                // 1️ Lấy thông tin từ các textbox
                string ImportDetailID = txtInfor1.Text;
                string ImportID = txtInfor2.Text;
                string CakeID = txtInfor3.Text;
                decimal ImportPrice = Convert.ToDecimal(txtInfor4.Text);
                string Quantity = txtInfor5.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = @"UPDATE ImportDetail SET 
                                     ImportID = @ImportID, 
                                     CakeID = @CakeID, 
                                     ImportPrice = @ImportPrice, 
                                     Quantity = @Quantity 
                                        WHERE ImportDetailID = @ImportDetailID";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ImportDetailID", ImportDetailID);
                    cmd.Parameters.AddWithValue("@ImportID", ImportID);
                    cmd.Parameters.AddWithValue("@CakeID", CakeID);
                    cmd.Parameters.Add("@ImportPrice", SqlDbType.Decimal).Value = ImportPrice;
                    cmd.Parameters.AddWithValue("@Quantity", Quantity);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadImportDetailData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
        }


        // ADD BUTON
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string survice = cbbSurvice.Text;
            if (survice == "Category")
            {
                // 1️ Lấy thông tin từ các textbox
                string categoryName = txtInfor2.Text;



                // 2️ Viết câu lệnh SQL Update
                string query = @"INSERT INTO Category (categoryName)
                                           VALUES (@categoryName);";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryName", categoryName);


                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCategoryData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Cake")
            {
                // 1️ Lấy thông tin từ các textbox
                string CakeCode = txtInfor2.Text;
                string Cakename = txtInfor3.Text;
                decimal UnitPrice = Convert.ToDecimal(txtInfor4.Text);
                string CategoryID = txtInfor5.Text;
                string StockQuantity = txtInfor6.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = @"INSERT INTO Cake (CakeCode, Cakename, UnitPrice, CategoryID, StockQuantity)
                                           VALUES (@CakeCode, @Cakename, @UnitPrice, @CategoryID, @StockQuantity);";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CakeCode", CakeCode);
                    cmd.Parameters.AddWithValue("@Cakename", Cakename);
                    cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = UnitPrice;
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                    cmd.Parameters.AddWithValue("@StockQuantity", StockQuantity);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCakeData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Employee")
            {
                // 1️ Lấy thông tin từ các textbox
                string EmployeeCode = txtInfor2.Text;
                string EmployeeName = txtInfor3.Text;
                string Position = cbbInfor4.Text;
                string Password = txtInfor5.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = @"INSERT INTO Employee (EmployeeCode, EmployeeName, Position, Password)
                                           VALUES (@EmployeeCode, @EmployeeName, @Position, @Password);";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeCode", EmployeeCode);
                    cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                    cmd.Parameters.AddWithValue("@Position", Position);
                    cmd.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployeeData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Customer")
            {
                // 1️ Lấy thông tin từ các textbox
                string CustomerCode = txtInfor2.Text;
                string CustomerName = txtInfor3.Text;
                string PhoneNumber = txtInfor4.Text;
                string Address = txtInfor5.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = @"INSERT INTO Customer (CustomerCode, CustomerName, PhoneNumber, Address)
                                           VALUES (@CustomerCode, @CustomerName, @PhoneNumber, @Address);";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerCode", CustomerCode);
                    cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", Address);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomerData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Orders")
            {
                // 1️ Lấy thông tin từ các textbox
                string OrderDate = txtInfor2.Text;
                string EmployeeID = txtInfor3.Text;
                string CustomerID = txtInfor4.Text;
                string TotalMount = txtInfor5.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = @"INSERT INTO Orders (OrderDate, EmployeeID, CustomerID, TotalMount)
                                           VALUES (@OrderDate, @EmployeeID, @CustomerID, @TotalMount);";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.Parameters.AddWithValue("@TotalMount", TotalMount);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrdersData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "OrderDetail")
            {
                // 1️ Lấy thông tin từ các textbox
                string OrderID = txtInfor2.Text;
                string CakeID = txtInfor3.Text;
                string Quantity = txtInfor4.Text;
                decimal UnitPrice = Convert.ToDecimal(txtInfor5.Text);


                // 2️ Viết câu lệnh SQL Update
                string query = @"INSERT INTO OrderDetail (OrderID, CakeID, Quantity, UnitPrice)
                                           VALUES (@OrderID, @CakeID, @Quantity, @UnitPrice);";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    cmd.Parameters.AddWithValue("@CakeID", CakeID);
                    cmd.Parameters.AddWithValue("@Quantity", Quantity);
                    cmd.Parameters.Add("@UnitPrice", SqlDbType.Decimal).Value = UnitPrice;

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrderDetailData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Import")
            {
                // 1️ Lấy thông tin từ các textbox
                string ImportDate = txtInfor2.Text;
                string EmployeeID = txtInfor3.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = @"INSERT INTO Import (ImportDate, EmployeeID)
                                           VALUES (@ImportDate, @EmployeeID);";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ImportDate", ImportDate);
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);


                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadImportData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "ImportDetail")
            {
                // 1️ Lấy thông tin từ các textbox
                string ImportID = txtInfor2.Text;
                string CakeID = txtInfor3.Text;
                decimal ImportPrice = Convert.ToDecimal(txtInfor4.Text);
                string Quantity = txtInfor5.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = @"INSERT INTO ImportDetail (ImportID, CakeID, ImportPrice, Quantity)
                                           VALUES (@ImportID, @CakeID, @ImportPrice, @Quantity);";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ImportID", ImportID);
                    cmd.Parameters.AddWithValue("@CakeID", CakeID);
                    cmd.Parameters.Add("@ImportPrice", SqlDbType.Decimal).Value = ImportPrice;
                    cmd.Parameters.AddWithValue("@Quantity", Quantity);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadImportDetailData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }

        }


        // DELETE BUTTON
        private void btnDelete_Click(object sender, EventArgs e)
        {

            string survice = cbbSurvice.Text;

            if (survice == "Category")
            {
                // 1️ Lấy thông tin từ các textbox
                string CategoryID = txtInfor1.Text;

                // 2️ Viết câu lệnh SQL Update
                string query = $"DELETE FROM Category WHERE CategoryID = @CategoryID;";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", CategoryID);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCategoryData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Cake")
            {
                // 1️ Lấy thông tin từ các textbox
                string CakeID = txtInfor1.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = $"DELETE FROM Cake WHERE CakeID = @CakeID;";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CakeID", CakeID);



                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCakeData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Employee")
            {
                // 1️ Lấy thông tin từ các textbox
                string EmployeeID = txtInfor1.Text;

                // 2️ Viết câu lệnh SQL Update
                string query = $"DELETE FROM Employee WHERE Employee = @Employee;";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployeeData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Customer")
            {
                // 1️ Lấy thông tin từ các textbox
                string CustomerID = txtInfor1.Text;

                // 2️ Viết câu lệnh SQL Update
                string query = $"DELETE FROM Customer WHERE CustomerID = @CustomerID;";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomerData();

                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Orders")
            {
                // 1️ Lấy thông tin từ các textbox
                string OrderID = txtInfor1.Text;

                // 2️ Viết câu lệnh SQL Update
                string query = $"DELETE FROM Order WHERE OrderID = @OrderID;";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrdersData();

                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "OrderDetail")
            {
                // 1️ Lấy thông tin từ các textbox
                string OrderDetailID = txtInfor1.Text;


                // 2️ Viết câu lệnh SQL Update
                string query = $"DELETE FROM OrderDetail WHERE OrderDetailID = @OrderDetailID;";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderDetailID", OrderDetailID);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrderDetailData();

                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "Import")
            {
                // 1️ Lấy thông tin từ các textbox
                string ImportID = txtInfor1.Text;

                // 2️ Viết câu lệnh SQL Update
                string query = $"DELETE FROM Import WHERE ImportID = @ImportID;";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ImportID", ImportID);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadImportData();

                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }
            else if (survice == "ImportDetail")
            {
                // 1️ Lấy thông tin từ các textbox
                string ImportDetailID = txtInfor1.Text;

                // 2️ Viết câu lệnh SQL Update
                string query = $"DELETE FROM ImportDetail WHERE ImportDetailID = @ImportDetailID;";

                // 3️ Kết nối và thực thi
                string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ImportDetailID", ImportDetailID);

                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                        if (rows > 0)
                        {
                            MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadImportDetailData();
                        }
                        else
                        {
                            MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                    }
                }
            }



















            /*

            // 1️ Lấy thông tin từ các textbox
            string EmployeeID = txtInfor1.Text;
            string EmployeeCode = txtInfor2.Text;
            string EmployeeName = txtInfor3.Text;
            string Position = cbbInfor4.Text;
            string Password = txtInfor5.Text;


            // 2️ Viết câu lệnh SQL Update
            string query = $"DELETE FROM Employee WHERE EmployeeID = @EmployeeID;";

            // 3️ Kết nối và thực thi
            string connectionString = "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery(); // Trả về số dòng bị ảnh hưởng
                    if (rows > 0)
                    {
                        MessageBox.Show("Success!", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string survice = cbbSurvice.Text;
                        if (survice == "Category")
                        {
                            LoadCategoryData();
                        }
                        else if (survice == "Cake")
                        {
                            LoadCakeData();
                        }
                        else if (survice == "Employee")
                        {
                            LoadEmployeeData();
                        }
                        else if (survice == "Customer")
                        {
                            LoadCustomerData();
                        }
                        else if (survice == "Orders")
                        {
                            LoadOrdersData();
                        }
                        else if (survice == "OrderDetail")
                        {
                            LoadOrderDetailData();
                        }
                        else if (survice == "Import")
                        {
                            LoadImportData();
                        }
                        else if (survice == "ImportDetail")
                        {
                            LoadImportDetailData();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }
            */
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}

