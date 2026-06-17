using System;
using System.Collections.Generic;
using tkpl.Model;
using tkpl.View;
using tkpl.View.Factory.ScoreCard;

namespace tkpl.Controller
{
    public class QuizSessionResultController
    {
        private readonly QuizSessionResult _resultView;
        private readonly List<AnswerRecord> _answerRecords;
        private readonly TimeSpan _sessionTime;

        public event Action OnSessionEnded;

        public QuizSessionResultController(QuizSessionResult resultView, List<AnswerRecord> answerRecords, TimeSpan sessionTime)
        {
            _resultView = resultView;
            _answerRecords = answerRecords;
            _sessionTime = sessionTime;

            SetupEvents();
        }

        private void SetupEvents()
        {
            _resultView.OnReviewClicked += (sender, e) => _resultView.TogglePanelScoreCard();
            _resultView.OnCloseClicked += (sender, e) => _resultView.TogglePanelScoreCard();
            _resultView.OnContinueClicked += (sender, e) => OnSessionEnded?.Invoke();
        }

        public void ShowResult()
        {
            _resultView.ClearScoreCards();

            decimal totalScore = 0;
            decimal maxScore = 0;
            int answeredCount = 0;
            int skippedCount = 0;

            foreach (var record in _answerRecords)
            {
                ScoreCardCreator creator = ScoreCardCreatorFactory.Create(record.Status, record.QuestionText, record.UserAnswer, record.CorrectAnswer);
                
                maxScore += record.ScoreWeight;

                if (record.Status == AnswerStatus.Correct)
                {
                    totalScore += record.ScoreWeight;
                }
                
                if (record.Status == AnswerStatus.Skipped)
                {
                    skippedCount++;
                }
                else
                {
                    answeredCount++;
                }

                _resultView.AddScoreCardPanel(creator.CreateCard());
            }

            _resultView.SetResult(totalScore, maxScore, answeredCount, skippedCount, _sessionTime);
            _resultView.Show();
        }
    }
}
