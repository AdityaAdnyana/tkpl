using System;

namespace tkpl.Model
{
    public class AnswerRecord
    {
        public string QuestionText { get; set; }
        public string UserAnswer { get; set; }
        public string Status { get; set; }
        public decimal ScoreWeight { get; set; }

        public AnswerRecord(string questionText, string userAnswer, string status, decimal scoreWeight)
        {
            QuestionText = questionText;
            UserAnswer = userAnswer;
            Status = status;
            ScoreWeight = scoreWeight;
        }
    }
}
