using System;
using System.Collections.Generic;
using System.Text;

namespace ImplemantasiGenericQuiz
{
    internal class Question<T> : IQuestion
    {

        public string QuestionText { get; set; } = string.Empty;
        public T ExpectedAnswer { get; set; } = default!; // initialized to satisfy nullable-analysis (CS8618)

        public string getAnswer()
        {
            return "" + ExpectedAnswer;
        }

        public bool ValidateAnswer(T answer)
        {
            return EqualityComparer<T>.Default.Equals(answer, ExpectedAnswer);
        }

        public bool ValidateAnswer(object answer)
        {
            T convertedAnswer = (T)Convert.ChangeType(answer, typeof(T));

            if (convertedAnswer is T typedAnswer) return ValidateAnswer(typedAnswer);

            return false;
        }
    }
}
