using System;
using tkpl.Model;

namespace tkpl.View.Factory.QuizControl
{
    public static class QuizControlCreatorFactory
    {
        public static QuizControlCreator Create(IQuestion question, Action<bool, string> handleAnswer)
        {
            if (question is IObjectiveQuiz objectiveQuiz)
            {
                return new ObjectiveQuizControlCreator(objectiveQuiz, handleAnswer);
            }
            if (question is IEssayQuiz essayQuiz)
            {
                return new EssayQuizControlCreator(essayQuiz, handleAnswer);
            }
            
            return null;
        }
    }
}
