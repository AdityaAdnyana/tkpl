using tkpl.Model;
namespace tkpl.Controller
{
    internal class QuizSessionController
    {
        private Lesson lesson;
        private QuizView quizView;
        private int currentQuestionIndex = 0;

        //Meminta lesson dan view agar controller dapat mengelola sesi kuis dengan data dan tampilan yang sesuai.
        public QuizSessionController(Lesson lesson, QuizView quizView)
        {
            this.lesson = lesson;
            this.quizView = quizView;
        }

        //Mulai sesi
        public void StartSession()
        {
            currentQuestionIndex = 0;
            if (lesson.questions.Count > 0)
            {
                ShowQuestion(currentQuestionIndex);
                quizView.Show();
            }
            else
            {
                MessageBox.Show("Tidak ada soal dalam lesson ini.");
            }
        }

        private void ShowQuestion(int index)
        {
            if (index >= lesson.questions.Count)
            {
                MessageBox.Show("Kuis Selesai!", "Selesai", MessageBoxButtons.OK);
                quizView.Close();
                return;
            }

            IQuestion currentQuestion = lesson.questions[index];
            quizView.SetQuestionText(currentQuestion.QuestionText);
            quizView.ClearControls();

            // Jika soal adalah ObjectiveQuiz, tampilkan opsi jawaban sebagai tombol.
            bool isObjectiveQuiz = currentQuestion is ObjectiveQuiz<string> || currentQuestion is ObjectiveQuiz<int>;
            if (isObjectiveQuiz)
            {
                var objectiveQuiz = currentQuestion as dynamic; // Menggunakan dynamic untuk menangani kedua jenis ObjectiveQuiz
                foreach (var opt in objectiveQuiz.GetStringOptions())
                {
                    Button btn = QuizView.GenerateAnswerButton(opt);
                    
                    // Menangani klik pada tombol jawaban. Mengirimkan jawaban yang dipilih ke metode validasi.
                    btn.Click += (sender, e) => HandleAnswer(objectiveQuiz.ValidateAnswer(opt));
                    quizView.AddControl(btn);
                }
            }
            // Jika soal adalah EssayQuiz, tampilkan TextBox untuk jawaban dan tombol submit.
            else if (currentQuestion is EssayQuiz essayQuiz)
            {
                TextBox txtAnswer = QuizView.GenerateAnswerTextBox();
                Button btnSubmit = QuizView.GenerateSubmitButton();

                // Menangani klik pada tombol submit. Mengirimkan jawaban yang dimasukkan ke metode validasi.
                btnSubmit.Click += (sender, e) => HandleAnswer(essayQuiz.ValidateAnswer(txtAnswer.Text));

                quizView.AddControl(txtAnswer);
                quizView.AddControl(btnSubmit);
            }
        }

        //Dipanggil oleh event handler tombol jawaban atau submit. Metode ini memvalidasi jawaban dan memberikan umpan balik kepada pengguna.
        private void HandleAnswer(bool isCorrect)
        {
            //Jika jawaban benar, lanjutkan ke soal berikutnya. Jika salah, coba lagi.
            if (isCorrect)
            {
                MessageBox.Show("Jawaban Anda Benar!", "Hasil", MessageBoxButtons.OK);
                currentQuestionIndex++;
                ShowQuestion(currentQuestionIndex);
            }
            else
            {
                MessageBox.Show("Jawaban Anda Salah, silakan coba lagi.", "Hasil", MessageBoxButtons.OK);
            }
        }
    }
}
