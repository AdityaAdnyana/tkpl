using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.View.User_Page.Factory
{
    public class FactoryIncorrectReportCard : FactoryReportCard
    {
        public FactoryIncorrectReportCard(string lessonTitle, string correctAnswer, string answer, string questionTeks)
            : base(lessonTitle, correctAnswer, answer, questionTeks)
        {
        }

        public override IReportCard CreateReportCard()
        {
            // Implement the creation of an incorrect report card
            return new IncorrectReportCard(_lessontiitle,_questionText, _answerText, _correctAnswerText);
        }
    }
}
