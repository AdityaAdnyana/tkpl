using tkpl.Model;
using tkpl.Model.tkpl.Model;
namespace tkpl.Controller
{
    public class QuizSessionController
    {
        private Lesson lesson;
        private QuizView quizView;
        private int currentQuestionIndex = 0;
        public LogicLevel gameLogic;

        //Meminta lesson dan view agar controller dapat mengelola sesi kuis dengan data dan tampilan yang sesuai.
        public QuizSessionController(Lesson lesson, QuizView quizView, LogicLevel logic)
        {
            this.lesson = lesson;
            this.quizView = quizView;
            this.gameLogic = logic;
        }

        // Mulai sesi
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
                MessageBox.Show("Tidak ada soal dalam lesson ini.??????");
            }
        }
        // Memperlihatkan soal berdasarkan indeks saat ini. Metode ini
        private void ShowQuestion(int index)
        {
            // Evaluasi Alur & Batas Akhir Bab (Navigation Guard)
            if (index >= lesson.Questions.Count)
            {
                HandleLessonTransition();
                return;
            }

            // Mengambil data soal aktif
            IQuestion currentQuestion = lesson.Questions[index];
            quizView.SetQuestionText(currentQuestion.QuestionText);
            quizView.ClearControls();

            // Delegasikan urusan rendering berdasarkan tipe soalnya
            if (currentQuestion is IObjectiveQuiz objectiveQuiz)
            {
                RenderObjectiveControls(objectiveQuiz);
            }
            else if (currentQuestion is IEssayQuiz essayQuiz)
            {
                RenderEssayControls(essayQuiz);
            }
        }

        // Metode ini menangani transisi antar soal, dan jika sudah mencapai akhir bab,
        private void HandleLessonTransition()
        {
            int currentLessonIdx = gameLogic._currentLessIdx;
            int currentModIdx = gameLogic._currentModIdx;
            int totalLessonsInCurrentModule = RepoLevel.MasterTable[currentModIdx].ReadOnlyLessons.Count;

            if (currentModIdx == 0 && currentLessonIdx == totalLessonsInCurrentModule - 1)
            {
                MessageBox.Show($"Selamat! Anda telah menyelesaikan seluruh bab di modul {RepoLevel.MasterTable[currentModIdx].ModuleName}. Program akan dihentikan.", "MODUL SELESAI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                quizView.Close();
                Application.Exit();
                return;
            }

            gameLogic.ForceAdvanceLevel();

            var nextMod = RepoLevel.MasterTable[gameLogic._currentModIdx];
            this.lesson = nextMod.ReadOnlyLessons[gameLogic._currentLessIdx];

            currentQuestionIndex = 0;
            ShowQuestion(currentQuestionIndex);
        }

        // Metode ini bertanggung jawab untuk merender kontrol jawaban untuk soal objektif. Untuk setiap opsi jawaban yang tersedia,
        // metode ini membuat tombol dan menambahkan event handler yang memanggil metode HandleAnswer dengan hasil validasi jawaban.
        private void RenderObjectiveControls(IObjectiveQuiz objectiveQuiz)
        {
            foreach (var opt in objectiveQuiz.GetStringOptions())
            {
                Button btn = QuizView.GenerateAnswerButton(opt);
                btn.Click += (sender, e) => HandleAnswer(objectiveQuiz.ValidateAnswer(opt));
                quizView.AddControl(btn);
            }
        }

        // Metode ini bertanggung jawab untuk merender kontrol jawaban untuk soal esai. Metode ini membuat TextBox untuk input jawaban dan tombol submit.
        private void RenderEssayControls(IEssayQuiz essayQuiz)
        {
            TextBox txtAnswer = QuizView.GenerateAnswerTextBox();
            Button btnSubmit = QuizView.GenerateSubmitButton();

            btnSubmit.Click += (sender, e) => HandleAnswer(essayQuiz.ValidateAnswer(txtAnswer.Text));

            quizView.AddControl(txtAnswer);
            quizView.AddControl(btnSubmit);
        }
        // Dipanggil oleh event handler tombol jawaban atau submit. Metode ini menerima hasil validasi
        // (sudah dilakukan pada event handler) dan memberikan umpan balik kepada pengguna.
        private void HandleAnswer(bool isCorrect)
        {
            if (isCorrect)
            {
                MessageBox.Show("Jawaban Anda Benar!", "Hasil", MessageBoxButtons.OK);

                currentQuestionIndex++;
                ShowQuestion(currentQuestionIndex);
            }
            else
            {
                gameLogic._currentLives--;

                MessageBox.Show($"Jawaban Anda Salah, silakan coba lagi. Sisa Nyawa: {gameLogic._currentLives}", "Hasil", MessageBoxButtons.OK);

                if (gameLogic._currentLives <= 0)
                {
                    MessageBox.Show("Sesi kuis ditutup karena nyawa Anda habis.", "Game Over", MessageBoxButtons.OK);

                    gameLogic.ProcessAnswer("salah_konsekuensi_nyawa_habis");
                    quizView.Close();
                }
            }
        }
    }
}
