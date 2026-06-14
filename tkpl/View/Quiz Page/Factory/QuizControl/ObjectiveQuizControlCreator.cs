using System;
using tkpl.Model;

namespace tkpl.View.Factory.QuizControl
{
    /// <summary>
    /// Concrete Creator: membuat ObjectiveQuizControl untuk soal pilihan ganda.
    /// Override factory method untuk mengembalikan tipe product yang sesuai.
    /// </summary>
    public class ObjectiveQuizControlCreator : QuizControlCreator
    {
        private readonly IObjectiveQuiz _quiz;
        private readonly Action<bool, string> _onAnswer;

        public ObjectiveQuizControlCreator(IObjectiveQuiz quiz, Action<bool, string> onAnswer)
        {
            _quiz = quiz;
            _onAnswer = onAnswer;
        }

        /// <summary>
        /// Signature method tetap menggunakan abstract product type (IQuizControl),
        /// meskipun concrete product yang dikembalikan adalah ObjectiveQuizControl.
        /// Dengan demikian Creator tetap independen dari concrete product class.
        /// </summary>
        public override IQuizControl FactoryMethod()
        {
            return new ObjectiveQuizControl(
                _quiz.GetStringOptions(),
                option => _onAnswer(_quiz.ValidateAnswer(option), option)
            );
        }
    }
}
