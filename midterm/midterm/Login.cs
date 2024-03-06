using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace midterm
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void registerTxt_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username = '" + usernameTxt.Text + "' and password = '" + passwordTxt.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new mainManu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalide Username or Password, Please Try again","Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTxt.Text = "";
                passwordTxt.Text = "";
                usernameTxt.Focus();
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            usernameTxt.Text = "";
            passwordTxt.Text = "";
            usernameTxt.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();

            register registerForm = new register();
            registerForm.FormClosed += (s, args) => this.Close();
            registerForm.Show();
        }

        private void showpassChkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassChkbx.Checked)
            {
                passwordTxt.PasswordChar = '\0';
            }
            else
            {
                passwordTxt.PasswordChar = '*';
            }
        }
    }
}
