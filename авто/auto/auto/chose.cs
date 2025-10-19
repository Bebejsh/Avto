using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace auto
{
    public partial class chose : Form
    {

        private int userId;
        private const string connectionString = "Server=localhost;Port=3306;Database= pr2214_auto;Uid=root;Pwd=root;";
        public chose()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void chose_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT idusers, name, surname, otchestvo FROM users";
                var command = new MySqlCommand(query, connection);


                var adapter = new MySqlDataAdapter(command);
                var table = new DataTable();
                adapter.Fill(table);


                dataGridView1.DataSource = table;
                dataGridView1.Columns["idusers"].Visible = false;

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                int selectedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idusers"].Value);


                main mainForm = new main(selectedId);
                mainForm.Show();
                this.Hide();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
