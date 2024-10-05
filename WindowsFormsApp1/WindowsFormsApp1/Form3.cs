using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private string connectionString = "your_connection_string_here";

        public Form3()
        {
            InitializeComponent();
            SetActiveTab(button1);
            LoadOrders();
            LoadProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetActiveTab(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveTab(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetActiveTab(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetActiveTab(button4);
        }

        private void SetActiveTab(Button activeButton)
        {
            // Список всех кнопок-вкладок
            Button[] tabButtons = { button1, button2, button3, button4 };

            // Устанавливаем цвет текста всех кнопок в серый
            foreach (Button button in tabButtons)
            {
                button.ForeColor = Color.Gray;
            }

            // Устанавливаем цвет текста активной кнопки в черный
            activeButton.ForeColor = Color.Black;

            // Управляем видимостью элементов в зависимости от активной кнопки
            label3Main.Visible = (activeButton == button1);
            label4Main.Visible = (activeButton == button1);
            label5Main.Visible = (activeButton == button1);
            label6Main.Visible = (activeButton == button1);
            label7Main.Visible = (activeButton == button1);
            label8Main.Visible = (activeButton == button1);
            button6Main.Visible = (activeButton == button1);

            button7Catalog.Visible = (activeButton == button2);
            button8Catalog.Visible = (activeButton == button2);
            productsCatalog.Visible = (activeButton == button2);
            textBox6Catalog.Visible = (activeButton == button2);

            button6Orders.Visible = (activeButton == button3);
            button7Orders.Visible = (activeButton == button3);
            ordersOrders.Visible = (activeButton == button3);
            textBox1Orders.Visible = (activeButton == button3);

            textBox1LK.Visible = (activeButton == button4);
            textBox2LK.Visible = (activeButton == button4);
            textBox3LK.Visible = (activeButton == button4);
            textBox4LK.Visible = (activeButton == button4);
            textBox5LK.Visible = (activeButton == button4);
            textBox6LK.Visible = (activeButton == button4);
            textBox7LK.Visible = (activeButton == button4);
            button6LK.Visible = (activeButton == button4);
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

        private void button6Orders_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1Orders.Text.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Orders WHERE Order_ID = @SearchValue OR DateOfTheOrder = @SearchValue";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchValue", searchValue);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    ordersOrders.DataSource = dataTable;
                }
            }
            else
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Orders";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                ordersOrders.DataSource = dataTable;
            }
        }

        private void button7Catalog_Click(object sender, EventArgs e)
        {
            string searchValue = textBox6Catalog.Text.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Products WHERE Product_ID = @SearchValue OR ProductName LIKE @SearchValue";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchValue", searchValue);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    productsCatalog.DataSource = dataTable;
                }
            }
            else
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                productsCatalog.DataSource = dataTable;
            }
        }
    }
}
