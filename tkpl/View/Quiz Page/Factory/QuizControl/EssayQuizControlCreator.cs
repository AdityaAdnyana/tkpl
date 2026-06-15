using System;
using tkpl.Model;

namespace tkpl.View.Factory.QuizControl
{
    /// <summary>
    /// Concrete Creator: membuat EssayQuizControl untuk soal essay.
    /// Override factory method untuk mengembalikan tipe product yang sesuai.
    /// </summary>
    public class EssayQuizControlCreator : QuizControlCreator
    {
        private readonly IEssayQuiz _quiz;
        private readonly Action<bool, string> _onAnswer;

        public EssayQuizControlCreator(IEssayQuiz quiz, Action<bool, string> onAnswer)
        {
            _quiz = quiz;
            _onAnswer = onAnswer;
        }

        public override IQuizControl FactoryMethod()
        {
            return new EssayQuizControl(
                answer => _onAnswer(_quiz.ValidateAnswer(answer), answer)
            );
        }
    }
}
