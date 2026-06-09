using System;
using System.Windows.Forms;
using tkpl.Model;

namespace tkpl.Controller
{
    public class QuizSessionController
    {
        private Lesson lesson;
        private QuizView quizView;
        private LogicLevel gameLogic;
        private int currentQuestionIndex = 0;

        public QuizSessionController(Lesson lesson, QuizView quizView, LogicLevel logic)
        {
            this.lesson = lesson;
            this.quizView = quizView;
            this.gameLogic = logic;
        }

        public void StartSession()
        {
            currentQuestionIndex = 0;
            if (lesson.Questions.Count > 0)
            {
                ShowQuestion(currentQuestionIndex);
                quizView.Show();
            }
            else
            {
                MessageBox.Show("Tidak ada soal dalam lesson ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Metode ini menampilkan soal berdasarkan indeks saat ini, dengan
        private void ShowQuestion(int index)
        {
            // Pengecekan Batas Akhir Bab & Tamat Modul Pertama
            if (index >= lesson.Questions.Count)
            // Pengecekan Batas Akhir Bab & Tamat Modul Pertama
            if (index >= lesson.Questions.Count)
            {
                HandleLessonTransition();
                return;
            }

            IQuestion currentQuestion = lesson.Questions[index];
            quizView.SetQuestionText(currentQuestion.QuestionText);
            quizView.ClearControls();

            // Delegasi rendering kontrol UI visual (SRP)
            if (currentQuestion is IObjectiveQuiz objectiveQuiz)
            {
                RenderObjectiveControls(objectiveQuiz);
            }
            else if (currentQuestion is IEssayQuiz essayQuiz)
            {
                RenderEssayControls(essayQuiz);
            }
        }

        // Bagian ini menangani transisi antar bab dan modul, termasuk logika tamat untuk Bab 3 Modul 1
        private void HandleLessonTransition()
        {
            int currentLessonIdx = gameLogic._currentLessIdx;
            int currentModIdx = gameLogic._currentModIdx;
            int totalLessonsInCurrentModule = RepoLevel.MasterTable[currentModIdx].ReadOnlyLessons.Count;

            // KUNCI TAMAT: Otomatis memotong program saat Bab 3 Modul 1 (Mekanika Klasik) Selesai
            if (currentModIdx == 0 && currentLessonIdx == totalLessonsInCurrentModule - 1)
            {
                MessageBox.Show($"Selamat! Anda telah menyelesaikan seluruh bab di modul {RepoLevel.MasterTable[currentModIdx].ModuleName}. Program akan dihentikan.", "MODUL SELESAI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quizView.Close();
                Application.Exit();
                return;
            }

            gameLogic.ForceAdvanceLevel();

            // Refresh data pelajaran ke bab baru setelah dimajukan
            var nextMod = RepoLevel.MasterTable[gameLogic._currentModIdx];
            this.lesson = nextMod.ReadOnlyLessons[gameLogic._currentLessIdx];

            currentQuestionIndex = 0;
            ShowQuestion(currentQuestionIndex);
        }

        // Render kontrol untuk soal objektif dengan Button untuk setiap opsi
        private void RenderObjectiveControls(IObjectiveQuiz objectiveQuiz)
        {
            foreach (var opt in objectiveQuiz.GetStringOptions())
            {
                Button btn = QuizView.GenerateAnswerButton(opt);
                btn.Click += (sender, e) => HandleAnswer(objectiveQuiz.ValidateAnswer(opt));
                quizView.AddControl(btn);
            }
        }

        // Render kontrol untuk soal essay dengan TextBox dan Button Submit
        private void RenderEssayControls(IEssayQuiz essayQuiz)
        {
            TextBox txtAnswer = QuizView.GenerateAnswerTextBox();
            Button btnSubmit = QuizView.GenerateSubmitButton();

            btnSubmit.Click += (sender, e) => HandleAnswer(essayQuiz.ValidateAnswer(txtAnswer.Text));

            quizView.AddControl(txtAnswer);
            quizView.AddControl(btnSubmit);
        }


        // Logika penanganan jawaban dengan feedback dan pengurangan nyawa
        private void HandleAnswer(bool isCorrect)
        {
            if (isCorrect)
            {
                MessageBox.Show("Jawaban Anda Benar!", "Hasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentQuestionIndex++;
                ShowQuestion(currentQuestionIndex);
            }
            else
            {
                gameLogic._currentLives--;
                MessageBox.Show($"Jawaban Anda Salah.\nSisa Nyawa: {gameLogic._currentLives}", "Hasil", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (gameLogic._currentLives <= 0)
                {
                    MessageBox.Show("NYAWA HABIS! Jendela kuis akan ditutup.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    quizView.Close();
                    Application.Exit();
                }
            }
        }

        private void InitHealth()
        {
            currentHealth = lesson.questions.Count / 4;
            quizView.UpdateHealthVal(currentHealth);
        }

        private void DecreaseHealth(int decreaseVal)
        {
            currentHealth -= decreaseVal;
            quizView.UpdateHealthVal(currentHealth);
        }
    }
}