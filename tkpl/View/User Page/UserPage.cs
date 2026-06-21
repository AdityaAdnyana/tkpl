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
        private UserMenuControler userMenuControler;

        public UserPage()
        {
            InitializeComponent();
            //SetupTabelDinamis();


            userModel = new UserModel();
            userMenuControler = new UserMenuControler(userModel, this);

            // Hide the placeholder static labels
            LB_Password.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

            // Generate user details labels dynamically
            userMenuControler.ViewUserInfo();
            uploadReport();

            // Create Logout Button programmatically


            // Wire up navigation/exit button
            this.BtnExit.Click += (s, e) => this.Close();
        }

        private async void uploadReport()
        {
            if (ReportQuiz.QuizItems.Count == 0) return;
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

        public void AddModuleReport(Panel reportCard)
        {
            flowLayoutPanel1.Controls.Add(reportCard);
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
            this.Close();
            loginPage.FormClosed += (s, args) => this.Close(); // Close UserPage when LoginPage is closed
        }
    }
}
