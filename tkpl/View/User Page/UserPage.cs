using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tkpl.Model.User;

namespace tkpl.View.User_Page
{
    public partial class UserPage : Form
    {
        private UserModel userModel;
        private UserMenuFacade userMenuFacade;

        public UserPage()
        {
            InitializeComponent();
            SetupTabelDinamis();


            // Initialize Model and Facade
            userModel = new UserModel();
            userMenuFacade = new UserMenuFacade(userModel, this);

            // Hide the placeholder static labels
            LB_Password.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

            // Generate user details labels dynamically
            userMenuFacade.ViewUserInfo();
            uploadReport();

            // Create Logout Button programmatically


            // Wire up navigation/exit button
            this.BtnExit.Click += (s, e) => this.Close();
        }

        private async void uploadReport()
        {
            bool isSaved = await ReportQuiz.SaveReportsToApiAsync();

            if (isSaved)
            {
                MessageBox.Show("Hasil kuis berhasil disimpan ke database!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);


                ReportQuiz.QuizItems.Clear();

            }
            else
            {
                MessageBox.Show("Gagal menyimpan hasil kuis. Periksa koneksi internet atau server API Anda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void GeneratLabel(string text, Point location, int size)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = location;
            label.Font = new Font("Segoe UI", size, FontStyle.Regular);
            label.AutoSize = true;
            label.ForeColor = Color.Black;
            this.Controls.Add(label);
        }

        private void SetupTabelDinamis()
        {
            // Sel tidak bisa diedit
            dataGridViewReport.ReadOnly = true;
            // Menghilangkan baris kosong tambahan di paling bawah
            dataGridViewReport.AllowUserToAddRows = false;
            // Pengguna tidak bisa menghapus baris dengan tombol Delete
            dataGridViewReport.AllowUserToDeleteRows = false;   
           
            
            // Data Binding: Menyambungkan DataSource tabel langsung ke BindingList kita
            dataGridViewReport.DataSource = ReportQuiz.QuizItems;

            // Pastikan tabel meng-generate kolom secara otomatis sesuai properti kelas
            dataGridViewReport.AutoGenerateColumns = true;

            //int id, string questionText, string correctAnswer, int questionIndex, bool isUserCorrect

            // Mengubah teks judul kolom agar lebih enak dibaca pengguna
            if (dataGridViewReport.Columns["id"] != null)
                dataGridViewReport.Columns["id"].HeaderText = "No.";

            if (dataGridViewReport.Columns["QuestionText"] != null)
                dataGridViewReport.Columns["QuestionText"].HeaderText = "Soal Evaluasi";


            if (dataGridViewReport.Columns["CorrectAnswer"] != null)
                dataGridViewReport.Columns["CorrectAnswer"].HeaderText = "Kunci Jawaban";

            if (dataGridViewReport.Columns["questionIndex"] != null)
                dataGridViewReport.Columns["questionIndex"].HeaderText = "Nomor Soal";

            if (dataGridViewReport.Columns["IsCorrect"] != null)
                dataGridViewReport.Columns["IsCorrect"].HeaderText = "Status (Benar/Salah)";


            // Membuat lebar kolom otomatis menyesuaikan panjang teks soal
            dataGridViewReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            userModel.Logout();
            MessageBox.Show("Anda telah logout dari sistem.", "Logout Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            loginPage.FormClosed += (s, args) => this.Close(); // Close UserPage when LoginPage is closed
            this.Close();
        }
    }
}
