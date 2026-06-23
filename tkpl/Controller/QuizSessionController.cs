using tkpl.Model;
using tkpl.Model.Observer;
using tkpl.Model.User;
using tkpl.View;
using tkpl.View.Factory.ImageControl;
using tkpl.View.Factory.QuizControl;

namespace tkpl.Controller
{
    public class QuizSessionController
    {
        private readonly Lesson _lesson;
        private readonly QuizView _quizView;
        private readonly LogicLevel _gameLogic;
        private readonly UserModel _userModel;
        private readonly int _levelId;
        private readonly int _userId;
        private readonly List<AnswerRecord> _answerRecords = new();

        
        private int _currentQuestionIndex = 0;
        private DateTime _sessionStartTime;


        /// <summary>
        /// Inisialisasi QuizSessionController.
        /// Menggunakan Dependency Injection untuk UserModel guna mengurangi tight coupling.
        /// </summary>
        public QuizSessionController(int levelId, Lesson lesson, QuizView quizView, LogicLevel logic, UserModel userModel)
        {
            _levelId = levelId;
            _lesson = lesson;
            _quizView = quizView;
            _gameLogic = logic;
            _userModel = userModel;
            _userId = _userModel.GetUserId();

            SetupGuiQuizViewEvent();
        }

        private void SetupGuiQuizViewEvent()
        {
            _quizView.SkipClicked += HandleSkipQuestion;
            _quizView.CloseClicked += HandleCloseSession;
        }

        private void HandleCloseSession(object sender, EventArgs e)
        {
            _quizView.Close();
        }

        private void HandleSkipQuestion(object sender, EventArgs e)
        {
            try
            {
                if (_currentQuestionIndex >= _lesson.Questions.Count) return;


                string questionText = _lesson.Questions[_currentQuestionIndex].QuestionText;
                decimal scoreWeight = _lesson.Questions[_currentQuestionIndex].ScoreWeight;
                string correctAnswer = _lesson.Questions[_currentQuestionIndex].GetExpectedAnswerAsString();
                
                _answerRecords.Add(new AnswerRecord(questionText, "-", correctAnswer, AnswerStatus.Skipped, scoreWeight));

                _currentQuestionIndex++;
                ShowQuestion(_currentQuestionIndex);
            }
            catch (Exception ex)
            {
                _quizView.ShowErrorMessage($"Terjadi kesalahan saat melewati soal: {ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Memulai sesi kuis baru, me-reset state, dan menampilkan soal pertama.
        /// </summary>
        public void StartSession()
        {
            try
            {
                // Mendaftarkan Observer (QuizView) ke Publisher menggunakan abstraksi antarmuka
                ILivesSubject livesSubject = _gameLogic;
                livesSubject.Subscribe(_quizView);

                // Reset nyawa berdasarkan jumlah soal pada sesi ini (integer div 3)
                _gameLogic.ResetLives(_lesson.Questions.Count);

                // Inisialisasi GUI nyawa awal
                _quizView.UpdateHealthVal(_gameLogic.CurrentLives);

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
                    _quizView.ShowWarningMessage("Tidak ada soal dalam lesson ini.", "Informasi");
                }
            }
            catch (Exception ex)
            {
                _quizView.ShowErrorMessage($"Gagal memulai sesi kuis: {ex.Message}", "Error");
            }
        }

        private void ShowQuestion(int index)
        {
            try
            {
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

                if (!string.IsNullOrEmpty(currentQuestion.ImagePath))
                {
                    var imageCreator = new QuestionImageCreator();
                    Control imgControl = imageCreator.CreateImageControl(currentQuestion.ImagePath);
                    _quizView.AddControl(imgControl);
                }

                QuizControlCreator creator = QuizControlCreatorFactory.Create(currentQuestion, HandleAnswer);

                if (creator != null)
                {
                    creator.RenderControls(_quizView);
                }
            }
            catch (Exception ex)
            {
                _quizView.ShowErrorMessage($"Gagal memuat soal: {ex.Message}", "Error");
            }
        }

        private void HandleAnswer(bool isCorrect, string userAnswer)
        {
            try
            {
                int questionIndex = _currentQuestionIndex;
                string questionText = _lesson.Questions[questionIndex].QuestionText;
                decimal scoreWeight = _lesson.Questions[questionIndex].ScoreWeight;
                string correctAnswer = _lesson.Questions[questionIndex].GetExpectedAnswerAsString();

                AnswerStatus status = isCorrect ? AnswerStatus.Correct : AnswerStatus.Wrong;
                _answerRecords.Add(new AnswerRecord(questionText, userAnswer, correctAnswer, status, scoreWeight));

                if (isCorrect)
                {
                    _quizView.ShowInfoMessage("Jawaban Anda Benar!", "Hasil");
                }
                else
                {
                    _gameLogic.DecreaseLives();
                    _quizView.ShowWarningMessage($"Jawaban Anda Salah.\nSisa Nyawa: {_gameLogic.CurrentLives}", "Hasil");

                    if (_gameLogic.CurrentLives <= 0)
                    {
                        _quizView.ShowErrorMessage("NYAWA HABIS!", "Game Over");
                        ShowSessionResult();
                        return;
                    }
                }


                ReportQuiz.QuizItems.Add(new ReportQuizItem(
                    no: _answerRecords.Count,
                    questionText: questionText,
                    correctAnswer: correctAnswer,
                    userAnswer: userAnswer,
                    isCorrect: isCorrect,
                    userId: _userId,
                    quizId: 0,           // Quiz_ID tidak tersedia di sini; kolom nullable di DB
                    levelId: _levelId
                ));


                _currentQuestionIndex++;
                ShowQuestion(_currentQuestionIndex);
            }
            catch (Exception ex)
            {
                _quizView.ShowErrorMessage($"Terjadi kesalahan saat memproses jawaban: {ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Menampilkan GUI QuizSessionResult menggunakan QuizSessionResultController.
        /// Controller baru ini menangani logika pengaturan Result dan Factory Method untuk score card.
        /// </summary>
        private void ShowSessionResult()
        {
            try
            {
                _userModel.UnlockLevel(_levelId + 1);

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
            catch (Exception ex)
            {
                _quizView.ShowErrorMessage($"Gagal menampilkan hasil sesi: {ex.Message}", "Error");
            }
        }
    }
}