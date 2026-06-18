using System;
using System.Windows.Forms;
using tkpl.Controller;
using tkpl.View.Materi_Page;
using tkpl.View.User_Page;

namespace tkpl.View
{
    public partial class Homepage : Form
    {
        private readonly HomepageController _controller;

        public Homepage()
        {
            InitializeComponent();
        
        }

        

        private void btnStartQuiq_Click(object sender, EventArgs e)
        {
            // Ambil objek Singleton LogicLevel untuk mengontrol status level game
            LogicLevel gameLogic = LogicLevel.Instance();

            LoadQuizSession(0, 0);
        }

        private void btnStartLevel2_Click(object sender, EventArgs e)
        {
            LoadQuizSession(0, 1);
        }

        private void btnStartLevel3_Click(object sender, EventArgs e)
        {
            LoadQuizSession(0, 2);
        }

        private void LoadQuizSession(int moduleIdx, int lessonIdx)
        {
            try
            {

                Module targetModule = RepoLevel.MasterTable[moduleIdx];
                Lesson targetLesson = (Lesson)targetModule.ReadOnlyComponents[lessonIdx];

                QuizView quizWindow = new QuizView();

                QuizSessionController session = new QuizSessionController(targetLesson, quizWindow, LogicLevel.Instance());

                this.Hide();

                // Jika jendela kuis ditutup, munculkan kembali Homepage ini secara otomatis dan termasuk penerapan DRY
                quizWindow.FormClosed += (s, args) => this.Show();

                session.StartSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat kuis: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnUser_Click_1(object sender, EventArgs e)
        {
            UserPage userProfile = new UserPage();
            userProfile.Show();
        }

        public Button GetBtnStartLevel1() => btnStartLevel1;
        public Button GetBtnStartLevel2() => btnStartLevel2;
        public Button GetBtnStartLevel3() => btnStartLevel3;
        public Button GetBtnExit() => btnExit;

        private void btnToMateri_Click(object sender, EventArgs e)
        {
            MateriMenuPage materiMenuPage = new MateriMenuPage();
            materiMenuPage.Show();
        }
    }

}