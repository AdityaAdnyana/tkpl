using System;
using System.Collections.Generic;
using System.Text;
using tkpl.Model;
using tkpl.View.User_Page.Factory;
using tkpl.View.User_Page.Factory.ReportCart;

namespace tkpl.View.Factory.ReportCard
{
    public static class ReportCardCreatorFactory
    {
        public static FactoryReportCard CreateReportCardCreator(AnswerStatus status,string lessonTitle, string correctAnswer, string answer, string questionText)
        {
            if (status == AnswerStatus.Correct)
            {
                return new FactoryCorrectReportCard(lessonTitle, correctAnswer, answer, questionText);
            }
            else if (status == AnswerStatus.Wrong)
            {
                return new FactoryIncorrectReportCard(lessonTitle, correctAnswer, answer, questionText);
            }
            else
            {
                return new FactorySkipReportCard(lessonTitle, correctAnswer, answer, questionText);
            }
        }
    }
}
