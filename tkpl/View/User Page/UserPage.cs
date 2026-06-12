using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tkpl.View.User_Page
{
    public partial class UserPage : Form
    {
        public UserPage()
        {
            InitializeComponent();
            SetupTabelDinamis();

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
            label.Font = new Font(label.Font.FontFamily, size);
            this.Controls.Add(label);
        }

        private void SetupTabelDinamis()
        {
            // 1. Data Binding: Menyambungkan DataSource tabel langsung ke BindingList kita
            dataGridViewReport.DataSource = ReportQuiz.QuizItems;

            // 2. Pastikan tabel meng-generate kolom secara otomatis sesuai properti kelas
            dataGridViewReport.AutoGenerateColumns = true;

            // 3. Merapikan Tampilan Kolom (Opsional tapi sangat disarankan)
            // Karena properti 'Lesson' adalah sebuah objek (bukan string/int),
            // tabel akan menampilkan tulisan "[Namespace].Lesson" yang jelek dilihat.
            // Kita bisa menyembunyikan kolom tersebut:
            if (dataGridViewReport.Columns["Lesson"] != null)
            {
                dataGridViewReport.Columns["Lesson"].Visible = false;
            }

            // 4. Mengubah teks judul kolom agar lebih enak dibaca pengguna
            if (dataGridViewReport.Columns["id"] != null)
                dataGridViewReport.Columns["id"].HeaderText = "No.";

            if (dataGridViewReport.Columns["QuestionText"] != null)
                dataGridViewReport.Columns["QuestionText"].HeaderText = "Soal Evaluasi";

            if (dataGridViewReport.Columns["IsCorrect"] != null)
                dataGridViewReport.Columns["IsCorrect"].HeaderText = "Status (Benar/Salah)";

            if (dataGridViewReport.Columns["CorrectAnswer"] != null)
                dataGridViewReport.Columns["CorrectAnswer"].HeaderText = "Kunci Jawaban";

            // 5. Membuat lebar kolom otomatis menyesuaikan panjang teks soal
            dataGridViewReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
