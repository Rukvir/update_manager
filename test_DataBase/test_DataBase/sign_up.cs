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

namespace test_DataBase
{
    public partial class sign_up : Form
    {
        DataBase dataBase = new DataBase();
        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '•';
            //passwordNotVisible.Visible = false;
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var login = textBox_login.Text;
            var password = textBox_password.Text;

            string querysting = $"insert into register(login_user, password_user) values( ('{login}'), ('{password}'))";

            SqlCommand command = new SqlCommand(querysting, dataBase.getConnection());

            dataBase.openConnection();
            if (checkUser())
            {
                return;
            }
            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!");
                log_in frm_login = new log_in();
                this.Hide();
                frm_login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан!");
            }
            dataBase.closeConnection();
        }

        private Boolean checkUser()
        {
            var loginUser = textBox_login.Text;
            var passwordUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passwordUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользовать уже существует!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            log_in form_log_in = new log_in();
            form_log_in.Show();
            this.Hide();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox_login.Text = "";
            textBox_password.Text = "";
        }
    }
}
