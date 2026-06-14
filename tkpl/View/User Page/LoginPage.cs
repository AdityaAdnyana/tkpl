using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using tkpl.Model.User;

namespace tkpl.View.User_Page
{
    public partial class LoginPage : Form
    {
        UserModel userModel = new UserModel();
        Homepage homepage = new Homepage();
        SigninPage signinPage = new SigninPage();
        public LoginPage()
        {
            InitializeComponent();
            TbPassword.UseSystemPasswordChar = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = TbUsername.Text;
            string password = TbPassword.Text;
            if (userModel.Login(username, password))
            {
                MessageBox.Show("Login Berhasil!");
                homepage.FormClosed += (s, args) => this.Close();
                homepage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Gagal! Pastikan username dan password benar.");
            }
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            signinPage.FormClosed += (s, args) => this.Close();
            signinPage.Show();
            this.Hide();
        }

        private void CbShowPss_CheckedChanged(object sender, EventArgs e)
        {
            if (CbShowPss.Checked)
            {
                // Jika dicentang, matikan sensor (password terlihat)
                TbPassword.UseSystemPasswordChar = false;
              
            }
            else
            {
                // Jika centang dihilangkan, aktifkan sensor kembali
                TbPassword.UseSystemPasswordChar = true;
               
            }
        }
    }
}
