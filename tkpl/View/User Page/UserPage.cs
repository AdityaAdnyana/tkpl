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

            // Create Logout Button programmatically
            Button btnLogout = new Button();
            btnLogout.Text = "Logout";
            btnLogout.Location = new Point(800, 20);
            btnLogout.Size = new Size(150, 40);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.BackColor = Color.FromArgb(220, 53, 69);
            btnLogout.ForeColor = Color.White;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Click += btnLogout_Click;
            this.Controls.Add(btnLogout);

            // Wire up navigation/exit button
            this.BtnExit.Click += (s, e) => this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            userModel.Logout();
            MessageBox.Show("Anda telah logout dari sistem.", "Logout Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
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
            // Data Binding: Menyambungkan DataSource tabel langsung ke BindingList kita
            dataGridViewReport.DataSource = ReportQuiz.QuizItems;

            // Pastikan tabel meng-generate kolom secara otomatis sesuai properti kelas
            dataGridViewReport.AutoGenerateColumns = true;

            // Merapikan Tampilan Kolom
            if (dataGridViewReport.Columns["Lesson"] != null)
            {
                dataGridViewReport.Columns["Lesson"].Visible = false;
            }

            // Mengubah teks judul kolom agar lebih enak dibaca pengguna
            if (dataGridViewReport.Columns["id"] != null)
                dataGridViewReport.Columns["id"].HeaderText = "No.";

            if (dataGridViewReport.Columns["QuestionText"] != null)
                dataGridViewReport.Columns["QuestionText"].HeaderText = "Soal Evaluasi";

            if (dataGridViewReport.Columns["IsCorrect"] != null)
                dataGridViewReport.Columns["IsCorrect"].HeaderText = "Status (Benar/Salah)";

            if (dataGridViewReport.Columns["CorrectAnswer"] != null)
                dataGridViewReport.Columns["CorrectAnswer"].HeaderText = "Kunci Jawaban";

            // Membuat lebar kolom otomatis menyesuaikan panjang teks soal
            dataGridViewReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
