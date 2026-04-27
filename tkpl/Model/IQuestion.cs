using System;
using System.Collections.Generic;
using System.Text;

namespace ImplemantasiGenericQuiz
{
    internal interface IQuestion
    {
        public string QuestionText { get; set; }
        public bool ValidateAnswer(object answer);
        public string getAnswer();
    }
}
