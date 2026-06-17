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
            _resultView.ReviewClicked += (sender, e) => _resultView.TogglePanelScoreCard();
            _resultView.CloseClicked += (sender, e) => _resultView.TogglePanelScoreCard();
            _resultView.ContinueClicked += (sender, e) => OnSessionEnded?.Invoke();
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

            string scoreText = $"{totalScore:0.##}/{maxScore:0.##}";
            string answeredText = $"{answeredCount}";
            string skippedText = $"{skippedCount}";
            
            string sessionTimeText;
            if (_sessionTime.TotalMinutes >= 1)
                sessionTimeText = $"{(int)_sessionTime.TotalMinutes}m {_sessionTime.Seconds}s";
            else
                sessionTimeText = $"{_sessionTime.Seconds}s";

            int percentage = maxScore > 0 ? (int)((totalScore * 100) / maxScore) : 0;
            string progressPercentageText = $"{percentage}%";

            _resultView.SetResult(scoreText, answeredText, skippedText, sessionTimeText, percentage, progressPercentageText);
            _resultView.Show();
        }
    }
}
