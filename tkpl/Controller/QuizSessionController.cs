using tkpl.Model;
using tkpl.Model.tkpl.Model;
namespace tkpl.Controller
{
    public class QuizSessionController
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
            if (currentQuestion is IObjectiveQuiz objectiveQuiz)
            {
                foreach (var opt in objectiveQuiz.GetStringOptions())
                {
                    Button btn = QuizView.GenerateAnswerButton(opt);

                    // Menangani klik pada tombol jawaban.
                    // objectiveQuiz mewarisi IQuestion, sehingga otomatis punya ValidateAnswer(object)
                    btn.Click += (sender, e) => HandleAnswer(objectiveQuiz.ValidateAnswer(opt));
                    quizView.AddControl(btn);
                }
            }
            // Jika soal adalah EssayQuiz, tampilkan TextBox untuk jawaban dan tombol submit.
            else if (currentQuestion is IEssayQuiz)
            {
                TextBox txtAnswer = QuizView.GenerateAnswerTextBox();
                Button btnSubmit = QuizView.GenerateSubmitButton();

                // Menangani klik pada tombol submit. Mengirimkan jawaban yang dimasukkan ke metode validasi.
                btnSubmit.Click += (sender, e) =>
                {
                    try
                    {
                        HandleAnswer(currentQuestion.ValidateAnswer(txtAnswer.Text));
                    }
                    catch (FormatException ex)
                    {
                        // Menampilkan GUI MessageBox peringatan jika konversi format (misal: huruf ke angka) gagal
                        MessageBox.Show(ex.Message, "Peringatan Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        // Menampilkan GUI MessageBox error untuk masalah lainnya
                        MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };


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
