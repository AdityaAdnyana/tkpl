using System;

namespace tkpl.View.Factory.ScoreCard
{
    public static class ScoreCardCreatorFactory
    {
        public static ScoreCardCreator Create(tkpl.Model.AnswerStatus status, string questionText, string userAnswer, string correctAnswer)
        {
            switch (status)
            {
                case tkpl.Model.AnswerStatus.Correct:
                    return new CorrectScoreCardCreator(questionText, userAnswer, correctAnswer);
                case tkpl.Model.AnswerStatus.Wrong:
                    return new IncorrectScoreCardCreator(questionText, userAnswer, correctAnswer);
                default:
                    return new SkippedScoreCardCreator(questionText, userAnswer, correctAnswer);
            }
        }
    }
}
