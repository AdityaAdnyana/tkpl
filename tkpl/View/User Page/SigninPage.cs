using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tkpl.View.User_Page
{
    public partial class SigninPage : Form
    {
        LoginPage loginPage = new LoginPage();
        Homepage homepage = new Homepage();
        public SigninPage()
        {
            InitializeComponent();
            TbPassword.UseSystemPasswordChar = true;
            TbConPass.UseSystemPasswordChar = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (CbShowPassword.Checked)
            {
                // Jika dicentang, matikan sensor (password terlihat)
                TbPassword.UseSystemPasswordChar = false;
                TbConPass.UseSystemPasswordChar = false;
            }
            else
            {
                // Jika centang dihilangkan, aktifkan sensor kembali
                TbPassword.UseSystemPasswordChar = true;
                TbConPass.UseSystemPasswordChar = true;
            }
        }

        private void BtSignIn_Click(object sender, EventArgs e)
        {
            homepage.FormClosed += (s, args) => this.Close();
            homepage.Show();
            this.Hide();
        }

        private void BtLogin_Click(object sender, EventArgs e)
        {
            loginPage.FormClosed += (s, args) => this.Close();
            loginPage.Show();
            this.Hide();
        }
    }
}
