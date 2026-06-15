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

        private async void BtSignIn_Click(object sender, EventArgs e)
        {
           
            
            string inputUsername = TbUsername.Text;
            string inputPassword = TbPassword.Text;
            string inputConfirm = TbConPass.Text;

            
            // Cek apakah ada kolom yang kosong
            if (string.IsNullOrWhiteSpace(inputUsername) || string.IsNullOrWhiteSpace(inputPassword))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Hentikan proses
            }

            // Cek apakah konfirmasi password cocok
            if (inputPassword != inputConfirm)
            {
                MessageBox.Show("Konfirmasi password tidak cocok! Silakan periksa kembali.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Hentikan proses
            }

           
            // Ubah teks tombol sementara agar user tahu aplikasi sedang loading
            BtSignIn.Text = "Menyimpan...";
            BtSignIn.Enabled = false;

            // Panggil metode dari RepoUser
            bool isSuccess = await RepoUser.RegisterUserAsync(inputUsername, inputPassword);

            // 4. HASILNYA
            if (isSuccess)
            {
                MessageBox.Show("Pendaftaran berhasil! Silakan Login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opsional: Bersihkan form atau langsung pindah ke halaman Home
                TbUsername.Clear();
                TbPassword.Clear();
                TbConPass.Clear();
            }
            else
            {
                MessageBox.Show("Pendaftaran gagal. Server API mungkin sedang mati atau username sudah dipakai.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Kembalikan tombol seperti semula
            BtSignIn.Text = "Sign In";
            BtSignIn.Enabled = true;
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
