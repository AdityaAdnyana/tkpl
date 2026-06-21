using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.View.User_Page.Factory.ReportCart
{
    public class FactorySkipReportCard : FactoryReportCard
    {
        public FactorySkipReportCard(string lessonTitle, string correctAnswer, string answer, string questionTeks)
            : base(lessonTitle, correctAnswer, answer, questionTeks)
        {
        }

        public override IReportCard CreateReportCard()
        {
            // Implement the creation of a skip report card
            return new SkipReportCard(_lessontiitle,_questionText, _answerText, _correctAnswerText);
        }
    }
}
