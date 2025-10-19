using MySql.Data.MySqlClient;

namespace auto
{
    public partial class Form1 : Form
    {
        private int failedAttempts = 0;
        private DateTime? lockTime = null;

        private const string connectionString = "Server=localhost;Port=3306;Database= pr2214_auto;Uid=root;Pwd=root;";

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;


            if (lockTime.HasValue && lockTime.Value > DateTime.Now)
            {
                MessageBox.Show("�� �������������. ���������� ����� ����� " + (lockTime.Value - DateTime.Now).Minutes + " �����.");
                return;
            }


            if (AuthenticateUser(login, password))
            {
                // �������� �����������
                MessageBox.Show("����� ����������!");


                chose choseForm = new chose();
                choseForm.Show();
                this.Hide();

                failedAttempts = 0;
            }
            else
            {
                failedAttempts++;
                MessageBox.Show("�������� ����� ��� ������.");

                if (failedAttempts >= 3)
                {

                    lockTime = DateTime.Now.AddMinutes(1);
                    MessageBox.Show("��������� ���������� �������. �� ������������� �� 1 ������.");
                }
            }
        }

        private bool AuthenticateUser(string login, string password)
        {

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM logpas WHERE login = @login";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        string dbPassword = reader["password"].ToString();

                        return dbPassword == password;
                    }
                }
            }

            return false;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;


            if (lockTime.HasValue && lockTime.Value > DateTime.Now)
            {
                MessageBox.Show("�� �������������. ���������� ����� ����� " + (lockTime.Value - DateTime.Now).Minutes + " �����.");
                return;
            }


            if (AuthenticateUser(login, password))
            {
                // �������� �����������
                MessageBox.Show("����� ����������!");


                chose choseForm = new chose();
                choseForm.Show();
                this.Hide();

                failedAttempts = 0;
            }
            else
            {
                failedAttempts++;
                MessageBox.Show("�������� ����� ��� ������.");

                if (failedAttempts >= 3)
                {

                    lockTime = DateTime.Now.AddMinutes(1);
                    MessageBox.Show("��������� ���������� �������. �� ������������� �� 1 ������.");
                }
            }
        }
    }
}
