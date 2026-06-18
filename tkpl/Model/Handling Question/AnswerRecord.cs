using System;

namespace tkpl.Model
{
    public enum AnswerStatus
    {
        Correct,
        Wrong,
        Skipped
    }

    public class AnswerRecord
    {
        public string QuestionText { get; set; }
        public string UserAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        public AnswerStatus Status { get; set; }
        public decimal ScoreWeight { get; set; }

        public AnswerRecord(string questionText, string userAnswer, string correctAnswer, AnswerStatus status, decimal scoreWeight)
        {
            QuestionText = questionText;
            UserAnswer = userAnswer;
            CorrectAnswer = correctAnswer;
            Status = status;
            ScoreWeight = scoreWeight;
        }
    }
}
