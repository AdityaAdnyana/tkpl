using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.View.User_Page.Factory
{
    public class FactoryCorrectReportCard : FactoryReportCard
    {
        public FactoryCorrectReportCard(string lessonTitle,string correctAnswer, string answer, string questionTeks)
            : base( lessonTitle,correctAnswer, answer, questionTeks)
        {
        }

        public override IReportCard CreateReportCard()
        {
            // Implement the creation of a correct report card
            return new CorrectReportCard(_lessontiitle, _questionText, _answerText, _correctAnswerText);
        }
    }
}
