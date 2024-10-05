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

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        private string connectionString = "your_connection_string_here";

        public Form5()
        {
            InitializeComponent();
            LoadStaff();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Создаем новый экземпляр формы Form1
            Form1 form1 = new Form1();

            // Отображаем форму Form1
            form1.Show();

            // Закрываем текущую форму (MainForm)
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Staff WHERE Staff_ID = @SearchValue OR LastName LIKE @SearchValue";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchValue", searchValue);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            else
            {
                LoadStaff();
            }
        }

        private void LoadStaff()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Staff";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
