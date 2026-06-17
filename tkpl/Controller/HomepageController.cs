using System;
using System.Collections.Generic;
using System.Windows.Forms;
using tkpl.Model;
using tkpl.Model.Level;
using tkpl.Model.User;
using tkpl.View;

namespace tkpl.Controller
{
    public class HomepageController
    {
        private readonly Homepage _homepageView;

        public HomepageController(Homepage homepageView)
        {
            _homepageView = homepageView;

            // Mendaftarkan event listener ke tombol-tombol yang ada di View
            _homepageView.GetBtnStartLevel1().Click += (sender, e) => LoadLevelSession(1);
            _homepageView.GetBtnStartLevel2().Click += (sender, e) => LoadLevelSession(2);
            _homepageView.GetBtnStartLevel3().Click += (sender, e) => LoadLevelSession(3);
            _homepageView.GetBtnExit().Click += (sender, e) => ExitApplication();

            // Atur status tombol level saat inisialisasi
            RefreshLevelButtons();
        }

        public void RefreshLevelButtons()
        {
            UserModel userModel = new UserModel();
            int unlockedLevel = userModel.GetUnlockedLevel();
            _homepageView.GetBtnStartLevel1().Enabled = unlockedLevel >= 1;
            _homepageView.GetBtnStartLevel2().Enabled = unlockedLevel >= 2;
            _homepageView.GetBtnStartLevel3().Enabled = unlockedLevel >= 3;
        }

        public void LoadLevelSession(int level)
        {
            try
            {
                LevelQuizService quizService = new LevelQuizService();
                List<IQuestion> levelQuestions = quizService.GenerateQuizForLevel(level);

                // Buat Lesson sementara untuk menampung soal-soal hasil filter untuk level ini
                Lesson levelLesson = new Lesson($"Level {level} Quiz", "Kuis berdasarkan tingkat kesulitan.");
                levelLesson.Questions = levelQuestions;

                QuizView quizWindow = new QuizView();

                // Ambil objek Singleton LogicLevel untuk mengontrol status level game
                QuizSessionController session = new QuizSessionController(level, levelLesson, quizWindow, LogicLevel.Instance());

                _homepageView.Hide();

                // Jika jendela kuis ditutup, munculkan kembali Homepage ini secara otomatis
                quizWindow.FormClosed += (s, args) => 
                {
                    _homepageView.Show();
                    RefreshLevelButtons();
                };

                session.StartSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat kuis level {level}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExitApplication()
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
