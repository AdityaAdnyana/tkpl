using System;
using System.Collections.Generic;
using System.Text;

namespace ImplemantasiGenericQuiz
{
    internal class TempLessonInit
    {
        public TempLessonInit() { 
            Lesson currentLesson = new();

            Question<int> question1 = new Question<int> 
            { 
                QuestionText = "1 + 1 = ?", 
                ExpectedAnswer = 2
            };

            Question<String> question2 = new Question<String>
            {
                QuestionText = "Orang pertama yang mencapai bulan \n" +
                                "a. Neil Armstrong \n b. Leonardo Davinci \n c. Einstein \n d. Cipto \n",
                ExpectedAnswer = "a"
            };

            currentLesson.questions.Add(question1);
            currentLesson.questions.Add(question2);

            currentLesson.StartSession();
            
        }
    }
}