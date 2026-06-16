using System;

namespace tkpl.View.Factory.ScoreCard
{
    public static class ScoreCardCreatorFactory
    {
        public static ScoreCardCreator Create(string status, string questionText, string userAnswer, string correctAnswer)
        {
            switch (status)
            {
                case "Correct":
                    return new CorrectScoreCardCreator(questionText, userAnswer, correctAnswer);
                case "Wrong":
                    return new IncorrectScoreCardCreator(questionText, userAnswer, correctAnswer);
                default:
                    return new SkippedScoreCardCreator(questionText, userAnswer, correctAnswer);
            }
        }
    }
}
