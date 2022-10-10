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
    public partial class log_in : Form
    {
        DataBase database = new DataBase();
        public log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            //textBox_password.UseSystemPasswordChar = true;
        }

        private void log_in_Load(object sender, EventArgs e)
        {

            textBox_password.PasswordChar = '•';
            //passwordNotVisible.Visible = false;
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }


        private void btnEnter_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            var passwordUser = textBox_password.Text;
            string roleUser = "user";
            string roleAdmin = "admin";

            SqlDataAdapter adapterUser = new SqlDataAdapter();
            SqlDataAdapter adapterAdmin = new SqlDataAdapter();
            DataTable tableAccountUser = new DataTable();
            DataTable tableAccountAdmin = new DataTable();

            string querystringAccountUser = $"select id_user, login_user, password_user, role_user from register where " +
                $"login_user = '{loginUser}' and password_user = '{passwordUser}' and role_user = '{roleUser}'";
            string querystringAccountAdmin = $"select id_user, login_user, password_user, role_user from register where " +
                $"login_user = '{loginUser}' and password_user = '{passwordUser}' and role_user = '{roleAdmin}'";

            SqlCommand checkAccountUser = new SqlCommand(querystringAccountUser, database.getConnection());
            SqlCommand checkAccountAdmin = new SqlCommand(querystringAccountAdmin, database.getConnection());

            adapterUser.SelectCommand = checkAccountUser;
            adapterUser.Fill(tableAccountUser);

            adapterAdmin.SelectCommand = checkAccountAdmin;
            adapterAdmin.Fill(tableAccountAdmin);

            if ((tableAccountUser.Rows.Count == 1))
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form frm_NavigationUser = new NavigationUser();
                this.Hide();
                frm_NavigationUser.ShowDialog();
                this.Show();
                
            }
            else if (tableAccountAdmin.Rows.Count == 1)
            {
                MessageBox.Show("АДМИН МЫ СКУЧАЛИ ПО ТЕБЕ!", "С возвращением!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form frm_Navigation = new Navigation();
                this.Hide();
                frm_Navigation.ShowDialog();
                this.Show();
            }
            else
            MessageBox.Show("Такого аккаунта не существует!", "Увы!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sign_up form_sign = new sign_up();
            form_sign.Show();
            this.Hide();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox_login.Text = "";
            textBox_password.Text = "";
        }

        private void passwordNotVisible_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = true;
            //passwordVisible.Visible = true;
            //passwordNotVisible.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e) // passwordVisible
        {
            textBox_password.UseSystemPasswordChar = false;
           //passwordVisible.Visible = false;
            //passwordNotVisible.Visible = true;
        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void textBox_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_Click(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
