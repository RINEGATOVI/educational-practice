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
    public partial class Form4 : Form
    {
        private string connectionString = "your_connection_string_here";

        public Form4()
        {
            InitializeComponent();
            SetActiveTab(button1);
            LoadOrders();
            LoadProducts();
            LoadProviders();
            LoadClients();
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

        private void button6_Click(object sender, EventArgs e)
        {
            SetActiveTab(button5);
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
            button6Orders.Visible = (activeButton == button1);
            button7Orders.Visible = (activeButton == button1);
            button8Orders.Visible = (activeButton == button1);
            textBox1Orders.Visible = (activeButton == button1);
            ordersOrders.Visible = (activeButton == button1);

            button7Products.Visible = (activeButton == button2);
            button8Products.Visible = (activeButton == button2);
            button9Products.Visible = (activeButton == button2);
            textBox1Products.Visible = (activeButton == button2);
            productsProducts.Visible = (activeButton == button2);

            button7Providers.Visible = (activeButton == button3);
            button8Providers.Visible = (activeButton == button3);
            button9Providers.Visible = (activeButton == button3);
            textBox1Providers.Visible = (activeButton == button3);
            providersProviders.Visible = (activeButton == button3);


            button7Clients.Visible = (activeButton == button4);
            button8Clients.Visible = (activeButton == button4);
            button9Clients.Visible = (activeButton == button4);
            textBox1Clients.Visible = (activeButton == button4);
            clientsClients.Visible = (activeButton == button4);

            label3Analys.Visible = (activeButton == button5);
            textBox1Analys.Visible = (activeButton == button5);
            textBox3Analys.Visible = (activeButton == button5);
            button7Analys.Visible = (activeButton == button5);
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
                    string query = "SELECT * FROM Orders WHERE Order_ID = @SearchValue OR Client_ID = @SearchValue";
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

        private void button9Products_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1Products.Text.Trim();
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
                    productsProducts.DataSource = dataTable;
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
                productsProducts.DataSource = dataTable;
            }
        }

        private void button9Providers_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1Providers.Text.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Providers WHERE Provider_ID = @SearchValue OR FullName LIKE @SearchValue";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchValue", searchValue);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    providersProviders.DataSource = dataTable;
                }
            }
            else
            {
                LoadProviders();
            }
        }

        private void LoadProviders()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Providers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                providersProviders.DataSource = dataTable;
            }
        }

        private void button9Clients_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1Clients.Text.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Clients WHERE Client_ID = @SearchValue OR LastName LIKE @SearchValue";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchValue", searchValue);
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    clientsClients.DataSource = dataTable;
                }
            }
            else
            {
                LoadClients();
            }
        }

        private void LoadClients()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Clients";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                clientsClients.DataSource = dataTable;
            }
        }

    }
}
