using System;
using System.Windows.Forms;
using tkpl.Controller;
using tkpl.Model;

namespace tkpl.View
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        // 1. Fungsi Klik untuk Tombol Level 1
        private void btnStartQuiq_Click(object sender, EventArgs e)
        {
            // Ambil objek Singleton LogicLevel untuk mengontrol status level game
            LogicLevel gameLogic = LogicLevel.Instance();

            // Pastikan indeks diset ke Modul 0, Bab 0 (Level 1 / Kinematika)
            // Menggunakan method bawaan untuk loncat level secara aman jika dibutuhkan
            // atau langsung panggil data spesifik dari RepoLevel
            LoadQuizSession(0, 0);
        }

        // 2. Fungsi Klik untuk Tombol Level 2
        private void btnStartLevel2_Click(object sender, EventArgs e)
        {
            LoadQuizSession(0, 1); // Modul 0, Bab 1 (Hukum Newton I)
        }

        // 3. Fungsi Klik untuk Tombol Level 3
        private void btnStartLevel3_Click(object sender, EventArgs e)
        {
            LoadQuizSession(0, 2); // Modul 0, Bab 2 (Hukum Newton II)
        }

        // 4. HELPER METHOD (SRP): Fungsi tunggal khusus untuk merakit dan memuat jendela kuis
        private void LoadQuizSession(int moduleIdx, int lessonIdx)
        {
            try
            {
                // Ambil data modul dan bab yang tepat dari RepoLevel berdasarkan pilihan tombol
                Module targetModule = RepoLevel.MasterTable[moduleIdx];
                Lesson targetLesson = targetModule.ReadOnlyLessons[lessonIdx];

                // Buat hasil cetakan (instance) baru dari tampilan QuizView
                QuizView quizWindow = new QuizView();

                // Rakit ke dalam QuizSessionController dengan mengoper instance Singleton LogicLevel
                QuizSessionController session = new QuizSessionController(targetLesson, quizWindow, LogicLevel.Instance());

                // Sembunyikan Homepage agar layar tidak menumpuk penuh
                this.Hide();

                // Jika jendela kuis ditutup, munculkan kembali Homepage ini secara otomatis
                quizWindow.FormClosed += (s, args) => this.Show();

                // Mulai jalankan kuisnya
                session.StartSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat kuis: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. Fungsi Klik untuk Tombol Exit
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}