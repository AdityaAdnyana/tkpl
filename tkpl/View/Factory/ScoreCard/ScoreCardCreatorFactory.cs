using System;

namespace tkpl.View.Factory.ScoreCard
{
    public static class ScoreCardCreatorFactory
    {
        public static ScoreCardCreator Create(string status, string questionText, string userAnswer)
        {
            switch (status)
            {
                case "Correct":
                    return new CorrectScoreCardCreator(questionText, userAnswer);
                case "Wrong":
                    return new IncorrectScoreCardCreator(questionText, userAnswer);
                default:
                    return new SkippedScoreCardCreator(questionText, userAnswer);
            }
        }
    }
}
