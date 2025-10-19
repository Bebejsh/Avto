using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;

namespace auto
{
    public partial class main : Form
    {
        private int userId;

        private const string connectionString = "Server=localhost;Port=3306;Database= pr2214_auto;Uid=root;Pwd=root;";

        public main(int id)
        {
            InitializeComponent();
            userId = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
        private void LoadUserData()
        {
            // Создание подключения к базе данных
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                // Запрос для получения данных пользователя по id
                string query = "SELECT name, surname, otchestvo, passports, passportn, adressreg, adresspro, work, dolgnost, phone, email " +
                               "FROM users WHERE idusers = @id";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", userId);  // Подставляем значение userId в запрос

                // Выполняем запрос и получаем данные
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())  // Проверяем, если запись найдена
                    {
                        // Заполняем текстовые поля данными из базы
                        textBox1.Text = reader["name"].ToString();
                        textBox2.Text = reader["surname"].ToString();
                        textBox3.Text = reader["otchestvo"].ToString();
                        textBox4.Text = reader["passports"].ToString();
                        textBox5.Text = reader["passportn"].ToString();
                        textBox6.Text = reader["adressreg"].ToString();
                        textBox7.Text = reader["adresspro"].ToString();
                        textBox8.Text = reader["work"].ToString();
                        textBox9.Text = reader["dolgnost"].ToString();
                        textBox10.Text = reader["phone"].ToString();
                        textBox11.Text = reader["email"].ToString();
                    }
                }
            }
        }
    }
}
