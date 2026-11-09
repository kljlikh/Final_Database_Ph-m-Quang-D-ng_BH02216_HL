using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CakeStoreMng
{
    internal class DatabaseConnection
    {
            private static string _connectionString =
                "Data Source=LAPTOP-VK6173RO\\SQLEXPRESS;Initial Catalog=Cake_mng;Integrated Security=True;";

            public static SqlConnection GetConnection()
            {
                SqlConnection connection = null;
                try
                {
                    connection = new SqlConnection(_connectionString);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                        "Error while connecting to the database:\n" + ex.Message,
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                return connection;
            }
    }

}
