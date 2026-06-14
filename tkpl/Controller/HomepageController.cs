using System;
using System.Collections.Generic;
using System.Windows.Forms;
using tkpl.Model;
using tkpl.Model.Level;
using tkpl.View;

namespace tkpl.Controller
{
    public class HomepageController
    {
        private readonly Homepage _homepageView;

        public HomepageController(Homepage homepageView)
        {
            _homepageView = homepageView;
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
                QuizSessionController session = new QuizSessionController(levelLesson, quizWindow, LogicLevel.Instance());

                _homepageView.Hide();

                // Jika jendela kuis ditutup, munculkan kembali Homepage ini secara otomatis
                quizWindow.FormClosed += (s, args) => _homepageView.Show();

                session.StartSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat kuis level {level}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadQuizSession(int moduleIndex, int lessonIndex)
        {
            try
            { 
                Module targetModule = RepoLevel.MasterTable[moduleIndex];
                Lesson targetLesson = (Lesson)targetModule.ReadOnlyComponents[lessonIndex];

                QuizView quizWindow = new QuizView();

                // Ambil objek Singleton LogicLevel untuk mengontrol status level game
                QuizSessionController session = new QuizSessionController(targetLesson, quizWindow, LogicLevel.Instance());

                _homepageView.Hide();

                // Jika jendela kuis ditutup, munculkan kembali Homepage ini secara otomatis dan termasuk penerapan DRY
                quizWindow.FormClosed += (s, args) => _homepageView.Show();

                session.StartSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat kuis: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
