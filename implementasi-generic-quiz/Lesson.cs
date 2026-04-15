using System;
using System.Collections.Generic;
using System.Text;

namespace ImplemantasiGenericQuiz
{
    internal class Lesson
    {

        public List<IQuestion> questions { get; set; } = new List<IQuestion>();
       
        public void StartSession()
        {
            //SessionManager sessionManager = SessionManager.Instance;

            //sessionManager.InitializeNewSession(this);

            //sessionManager.ChangeState(SessionState.PresentingQuestion);

            Console.WriteLine("START SESSION");
            foreach (var question in questions)
            {
                Console.WriteLine(question.QuestionText);
                var userAnswer = Console.ReadLine();
                bool isCorrect = question.ValidateAnswer(userAnswer);

                Console.WriteLine(question.getAnswer);

                if (isCorrect) Console.WriteLine("JAWABAN BENAR!");
                else Console.WriteLine("JAWABAN SALAH");
            }
        }
    }

    
}
