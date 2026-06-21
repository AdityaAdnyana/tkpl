using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.View.User_Page.Factory
{
    public abstract class FactoryReportCard
    {
        protected string _lessontiitle;
        protected string _correctAnswerText;
        protected string _answerText;
        protected string _questionText;
        
        protected FactoryReportCard(string lessonTitle,string correctAnswer, string answer, string questionTeks)
        {
            _lessontiitle = lessonTitle;
            _correctAnswerText = correctAnswer;
            _answerText  = answer;
            _questionText = questionTeks;
            
        }

        public abstract IReportCard CreateReportCard();

        public Panel CreateCard()
        {
            IReportCard card = CreateReportCard();
            return card.GetPanel();
        }
    }
}
