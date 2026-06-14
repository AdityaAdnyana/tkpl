using System;
using System.Collections.Generic;
using System.Windows.Forms;
using tkpl.Model;
using tkpl.View;
using tkpl.View.Factory.QuizControl;
using tkpl.View.Factory.ScoreCard;

namespace tkpl.Controller
{
    public class QuizSessionController
    {
        private Lesson lesson;
        private QuizView quizView;
        private LogicLevel gameLogic;
        private int currentQuestionIndex = 0;
        private readonly List<(string QuestionText, string UserAnswer, string Status)> _answerRecords = new();

        public QuizSessionController(Lesson lesson, QuizView quizView, LogicLevel logic)
        {
            this.lesson = lesson;
            this.quizView = quizView;
            this.gameLogic = logic;

            SetupGuiQuizViewEvent();
        }

        private void SetupGuiQuizViewEvent()
        {
            quizView.GetBtSkip().Click += HandleSkipQuestion;
        }

        private void HandleSkipQuestion(object sender, EventArgs e)
        {
            if (currentQuestionIndex >= lesson.Questions.Count) return;

            string questionText = lesson.Questions[currentQuestionIndex].QuestionText;
            _answerRecords.Add((questionText, "-", "Skipped"));

            quizView.UpdateProgressBarValue(currentQuestionIndex + 1);
            currentQuestionIndex++;
            ShowQuestion(currentQuestionIndex);
        }

        public void StartSession()
        {
            // Mendaftarkan Observer (QuizView) ke Publisher (LogicLevel)
            gameLogic.Subscribe(quizView);

            // Reset nyawa berdasarkan jumlah soal pada sesi ini (integer div 3)
            gameLogic.ResetLives(lesson.Questions.Count);

            // Inisialisasi GUI nyawa awal
            quizView.UpdateHealthVal(gameLogic._currentLives);

            currentQuestionIndex = 0;
            _answerRecords.Clear();

            if (lesson.Questions.Count > 0)
            {
                quizView.InitProgressBar(lesson.Questions.Count, currentQuestionIndex);
                ShowQuestion(currentQuestionIndex);
                quizView.Show();
            }
            else
            {
                MessageBox.Show("Tidak ada soal dalam lesson ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Metode ini menampilkan soal berdasarkan indeks saat ini
        private void ShowQuestion(int index)
        {
            // Pengecekan Batas Akhir Kuis
            if (index >= lesson.Questions.Count)
            {
                quizView.UpdateProgressBarValue(lesson.Questions.Count);
                ShowSessionResult();
                return;
            }

            quizView.UpdateProgressBarValue(index);
            IQuestion currentQuestion = lesson.Questions[index];
            quizView.SetQuestionText(currentQuestion.QuestionText);
            quizView.ClearControls();

            // Menggunakan Factory untuk gambar jika soal memiliki gambar
            if (!string.IsNullOrEmpty(currentQuestion.ImagePath))
            {
                tkpl.View.Factory.ImageControl.ImageControlCreator imageCreator = new tkpl.View.Factory.ImageControl.QuestionImageCreator();
                Control imgControl = imageCreator.CreateImageControl(currentQuestion.ImagePath);
                quizView.AddControl(imgControl);
            }

            // Menggunakan Factory Method Pattern untuk membuat kontrol UI quiz.
            // Client code bekerja dengan Creator melalui base interface (QuizControlCreator),
            // sehingga dapat menerima ConcreteCreator apapun tanpa perlu tahu class spesifiknya.
            QuizControlCreator creator;

            //NOTE DARI @ADITYA: Mungkin ini perlu diperbaiki karena ini terasa tidak scaleable.
            if (currentQuestion is IObjectiveQuiz objectiveQuiz)
            {
                creator = new ObjectiveQuizControlCreator(objectiveQuiz, HandleAnswer);
            }
            else if (currentQuestion is IEssayQuiz essayQuiz)
            {
                creator = new EssayQuizControlCreator(essayQuiz, HandleAnswer);
            }
            else
            {
                return;
            }

            // Client code — bekerja dengan creator melalui base interface
            creator.RenderControls(quizView);
        }



        // Logika penanganan jawaban dengan feedback, pelacakan hasil, dan pengurangan nyawa
        private void HandleAnswer(bool isCorrect, string userAnswer)
        {
            string questionText = lesson.Questions[currentQuestionIndex].QuestionText;

            if (isCorrect)
            {
                _answerRecords.Add((questionText, userAnswer, "Correct"));
                quizView.UpdateProgressBarValue(currentQuestionIndex + 1);
                MessageBox.Show("Jawaban Anda Benar!", "Hasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentQuestionIndex++;
                ShowQuestion(currentQuestionIndex);
            }
            else
            {
                _answerRecords.Add((questionText, userAnswer, "Wrong"));
                
                // Mengurangi nyawa via Publisher, Observer (QuizView) akan otomatis di-update
                gameLogic.DecreaseLives();
                
                MessageBox.Show($"Jawaban Anda Salah.\nSisa Nyawa: {gameLogic._currentLives}", "Hasil", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (gameLogic._currentLives <= 0)
                {
                    MessageBox.Show("NYAWA HABIS!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ShowSessionResult();
                }
            }
        }

        /// <summary>
        /// Menampilkan GUI QuizSessionResult menggunakan Factory Method Pattern
        /// untuk membuat score card berdasarkan hasil jawaban selama sesi quiz.
        /// Setiap record jawaban dibuatkan score card melalui ScoreCardCreator yang sesuai.
        /// </summary>
        private void ShowSessionResult()
        {
            QuizSessionResult resultView = new QuizSessionResult();
            resultView.ClearScoreCards();

            SetupGuiSessionResultEvent(resultView);
          
            int correctCount = 0;

            foreach (var record in _answerRecords)
            {
                // Menggunakan Factory Method Pattern — client code bekerja dengan
                // ScoreCardCreator melalui base interface, tanpa perlu tahu
                // concrete creator class mana yang sedang digunakan.
                ScoreCardCreator creator;

                switch (record.Status)
                {
                    case "Correct":
                        creator = new CorrectScoreCardCreator(record.QuestionText, record.UserAnswer);
                        correctCount++;
                        break;
                    case "Wrong":
                        creator = new IncorrectScoreCardCreator(record.QuestionText, record.UserAnswer);
                        break;
                    default:
                        creator = new SkippedScoreCardCreator(record.QuestionText, record.UserAnswer);
                        break;
                }

                // Client code — bekerja dengan creator melalui base interface
                resultView.AddScoreCardPanel(creator.CreateCard());
            }

            resultView.SetResult(correctCount, _answerRecords.Count);
            quizView.Hide();
            resultView.Show();
            quizView.Close();
            //Application.Exit();
        }

        public void SetupGuiSessionResultEvent(QuizSessionResult resultView)
        {
            resultView.GetBtReview().Click += (Sender, e) => resultView.ToglePanelScoreCard();
            resultView.GetBtClose().Click += (Sender, e) => resultView.ToglePanelScoreCard();
        }
    }
}