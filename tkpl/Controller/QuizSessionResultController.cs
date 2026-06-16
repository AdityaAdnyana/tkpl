using System;
using System.Collections.Generic;
using tkpl.View;
using tkpl.View.Factory.ScoreCard;

namespace tkpl.Controller
{
    public class QuizSessionResultController
    {
        private readonly QuizSessionResult _resultView;
        private readonly List<(string QuestionText, string UserAnswer, string Status)> _answerRecords;
        private readonly TimeSpan _sessionTime;

        public event Action OnSessionEnded;

        public QuizSessionResultController(QuizSessionResult resultView, List<(string QuestionText, string UserAnswer, string Status)> answerRecords, TimeSpan sessionTime)
        {
            _resultView = resultView;
            _answerRecords = answerRecords;
            _sessionTime = sessionTime;

            SetupEvents();
        }

        private void SetupEvents()
        {
            _resultView.GetBtReview().Click += (sender, e) => _resultView.ToglePanelScoreCard();
            _resultView.GetBtClose().Click += (sender, e) => _resultView.ToglePanelScoreCard();
            _resultView.GetBtContinue().Click += (sender, e) => OnSessionEnded?.Invoke();
        }

        public void ShowResult()
        {
            _resultView.ClearScoreCards();

            int correctCount = 0;
            int skippedCount = 0;

            foreach (var record in _answerRecords)
            {
                ScoreCardCreator creator = ScoreCardCreatorFactory.Create(record.Status, record.QuestionText, record.UserAnswer);
                
                if (record.Status == "Correct")
                {
                    correctCount++;
                }
                else if (record.Status == "Skipped")
                {
                    skippedCount++;
                }

                _resultView.AddScoreCardPanel(creator.CreateCard());
            }

            _resultView.SetResult(correctCount, _answerRecords.Count, skippedCount, _sessionTime);
            _resultView.Show();
        }
    }
}
