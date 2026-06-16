using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using tkpl.Model;
using tkpl.Model.User;
using tkpl.View;
using tkpl.View.Factory.QuizControl;
using tkpl.View.Factory.ScoreCard;

namespace tkpl.Controller
{
    public class QuizSessionController
    {
        private Lesson _lesson;
        private QuizView _quizView;
        private LogicLevel _gameLogic;
        private UserModel _userModel;
        private int _userId;
        private int _currentQuestionIndex = 0;
        private DateTime _sessionStartTime;
        private readonly List<AnswerRecord> _answerRecords = new();

        public QuizSessionController(Lesson lesson, QuizView quizView, LogicLevel logic)
        {
            _lesson = lesson;
            _quizView = quizView;
            _gameLogic = logic;
            _userModel = new UserModel();
            _userId = _userModel.GetUserId();

            SetupGuiQuizViewEvent();
        }

        private void SetupGuiQuizViewEvent()
        {
            _quizView.GetBtSkip().Click += HandleSkipQuestion;
        }

        private void HandleSkipQuestion(object sender, EventArgs e)
        {
            if (_currentQuestionIndex >= _lesson.Questions.Count) return;

            string questionText = _lesson.Questions[_currentQuestionIndex].QuestionText;
            decimal scoreWeight = _lesson.Questions[_currentQuestionIndex].ScoreWeight;
            _answerRecords.Add(new AnswerRecord(questionText, "-", "Skipped", scoreWeight));

            _quizView.UpdateProgressBarValue(_currentQuestionIndex + 1);
            _currentQuestionIndex++;
            ShowQuestion(_currentQuestionIndex);
        }

        public void StartSession()
        {
            // Mendaftarkan Observer (QuizView) ke Publisher (LogicLevel)
            _gameLogic.Subscribe(_quizView);

            // Reset nyawa berdasarkan jumlah soal pada sesi ini (integer div 3)
            _gameLogic.ResetLives(_lesson.Questions.Count);

            // Inisialisasi GUI nyawa awal
            _quizView.UpdateHealthVal(_gameLogic._currentLives);

            _currentQuestionIndex = 0;
            _answerRecords.Clear();
            _sessionStartTime = DateTime.Now;

            if (_lesson.Questions.Count > 0)
            {
                _quizView.InitProgressBar(_lesson.Questions.Count, _currentQuestionIndex);
                ShowQuestion(_currentQuestionIndex);
                _quizView.Show();
            }
            else
            {
                _quizView.ShowMessage("Tidak ada soal dalam lesson ini.", "Informasi", MessageBoxIcon.Warning);
            }
        }

        // Metode ini menampilkan soal berdasarkan indeks saat ini
        private void ShowQuestion(int index)
        {
            // Pengecekan Batas Akhir Kuis
            if (index >= _lesson.Questions.Count)
            {
                _quizView.UpdateProgressBarValue(_lesson.Questions.Count);
                ShowSessionResult();
                return;
            }

            _quizView.UpdateProgressBarValue(index);
            IQuestion currentQuestion = _lesson.Questions[index];
            _quizView.SetQuestionText(currentQuestion.QuestionText);
            _quizView.ClearControls();

            // Menggunakan Factory untuk gambar jika soal memiliki gambar
            if (!string.IsNullOrEmpty(currentQuestion.ImagePath))
            {
                tkpl.View.Factory.ImageControl.ImageControlCreator imageCreator = new tkpl.View.Factory.ImageControl.QuestionImageCreator();
                Control imgControl = imageCreator.CreateImageControl(currentQuestion.ImagePath);
                _quizView.AddControl(imgControl);
            }

            // Menggunakan Factory Method Pattern untuk membuat kontrol UI quiz.
            QuizControlCreator creator = QuizControlCreatorFactory.Create(currentQuestion, HandleAnswer);

            if (creator != null)
            {
                // Client code — bekerja dengan creator melalui base interface
                creator.RenderControls(_quizView);
            }
        }

        private void HandleAnswer(bool isCorrect, string userAnswer)
        {
            int questionIndex = _currentQuestionIndex;
            string questionText = _lesson.Questions[questionIndex].QuestionText;
            decimal scoreWeight = _lesson.Questions[questionIndex].ScoreWeight;

            // Menerapkan prinsip DRY: Catat jawaban satu kali saja
            string status = isCorrect ? "Correct" : "Wrong";
            _answerRecords.Add(new AnswerRecord(questionText, userAnswer, status, scoreWeight));
            ReportQuiz.QuizItems.Add(new ReportQuizItem(_userId, _lesson, questionIndex, isCorrect));

            if (isCorrect)
            {
                _quizView.ShowMessage("Jawaban Anda Benar!", "Hasil", MessageBoxIcon.Information);
            }
            else
            {
                // Mengurangi nyawa via Publisher, Observer (QuizView) akan otomatis di-update
                _gameLogic.DecreaseLives();
                
                _quizView.ShowMessage($"Jawaban Anda Salah.\nSisa Nyawa: {_gameLogic._currentLives}", "Hasil", MessageBoxIcon.Warning);

                // Menerapkan Early Return jika game over
                if (_gameLogic._currentLives <= 0)
                {
                    _quizView.ShowMessage("NYAWA HABIS!", "Game Over", MessageBoxIcon.Error);
                    ShowSessionResult();
                    return;
                }
            }
            
            // Lanjut ke soal berikutnya untuk jawaban benar dan salah (yang nyawanya masih > 0)
            _quizView.UpdateProgressBarValue(_currentQuestionIndex + 1);
            _currentQuestionIndex++;
            ShowQuestion(_currentQuestionIndex);
        }

        /// <summary>
        /// Menampilkan GUI QuizSessionResult menggunakan QuizSessionResultController.
        /// Controller baru ini menangani logika pengaturan Result dan Factory Method untuk score card.
        /// </summary>
        private void ShowSessionResult()
        {
            TimeSpan sessionTime = DateTime.Now - _sessionStartTime;

            QuizSessionResult resultView = new QuizSessionResult();
            QuizSessionResultController resultController = new QuizSessionResultController(resultView, _answerRecords, sessionTime);
            
            resultController.OnSessionEnded += () => {
                _quizView.Close();
                resultView.Close();
            };

            _quizView.Hide();
            resultController.ShowResult();
        }
    }
}