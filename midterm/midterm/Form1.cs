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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void registerTxt_Click(object sender, EventArgs e)
        {
            if(usernameTxt.Text == "" && passwordTxt.Text == "" && compasswordTxt.Text == "")
            {
                MessageBox.Show("User name and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (passwordTxt.Text == compasswordTxt.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_users VALUES('" + usernameTxt.Text + "','" + passwordTxt.Text + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                usernameTxt.Text = "";
                passwordTxt.Text = "";
                compasswordTxt.Text = "";
                MessageBox.Show("You have been registered", "Registration complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password does not match", "Registration faield", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTxt.Text = "";
                compasswordTxt.Text = "";
                passwordTxt.Focus();
            }
        }

        private void showpassChkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (showpassChkbx.Checked)
            {
                passwordTxt.PasswordChar = '\0';
                compasswordTxt.PasswordChar = '\0';
            }
            else
            {
                passwordTxt.PasswordChar = '*';
                compasswordTxt.PasswordChar = '*';
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login loginForm = new Login();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            usernameTxt.Text = "";
            passwordTxt.Text = "";
            compasswordTxt.Text = "";
            usernameTxt.Focus();
        }
    }
}
