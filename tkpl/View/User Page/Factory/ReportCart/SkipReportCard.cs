using System;
using System.Collections.Generic;
using System.Text;
using tkpl.Controller;

namespace tkpl.View.User_Page.Factory.ReportCart
{
    public class SkipReportCard : IReportCard
    {
        protected string _lessonTitle;
        private string _questionText;
        private string _answerText;
        private string _correctAnswerText;
        

        public SkipReportCard(string lessonTitle, string questionText, string answerText, string correctAnswerText)
        {
            _lessonTitle = lessonTitle;
            _questionText = questionText;
            _answerText = answerText;
            _correctAnswerText = correctAnswerText;
        }

        public Panel GetPanel()
        {

            Panel panel = new Panel();
            var ui = AppConfig.UI;
            panel.Size = new Size(ui.ReportCardWidth, ui.ReportCardHeight);
            panel.BackColor = Color.Gray;

          

            Label LbQuestion = new Label();
            LbQuestion.Text = _questionText;
            LbQuestion.Location = new Point(24, 64);
            LbQuestion.Size = new Size(ui.ReportCardContentWidth, ui.ReportCardContentHeight);
            LbQuestion.Font = new Font(ui.ReportCardContentFontFamily, ui.ReportCardContentFontSize, FontStyle.Bold);
            panel.Controls.Add(LbQuestion);

            Label LbStatus = new Label();
            LbStatus.Text = "Correct";
            LbStatus.Location = new Point(24, 96);
            LbStatus.Size = new Size(ui.ReportCardContentWidth, ui.ReportCardContentHeight);
            LbStatus.Font = new Font(ui.ReportCardContentFontFamily, ui.ReportCardContentFontSize, FontStyle.Bold);
            panel.Controls.Add(LbStatus);

            Label LbCorrectAnswer = new Label();
            LbCorrectAnswer.Text = _correctAnswerText;
            LbCorrectAnswer.Location = new Point(24, 128);
            LbCorrectAnswer.Size = new Size(ui.ReportCardContentWidth, ui.ReportCardContentHeight);
            LbCorrectAnswer.Font = new Font(ui.ReportCardContentFontFamily, ui.ReportCardContentFontSize, FontStyle.Bold);
            panel.Controls.Add(LbCorrectAnswer);

            Label LbAnswer = new Label();
            LbAnswer.Text = _answerText;
            LbAnswer.Location = new Point(24, 160);
            LbAnswer.Size = new Size(ui.ReportCardContentWidth, ui.ReportCardContentHeight);
            LbAnswer.Font = new Font(ui.ReportCardContentFontFamily, ui.ReportCardContentFontSize, FontStyle.Bold);
            panel.Controls.Add(LbAnswer);

            return panel;
        }
    }
}
