using System;
using System.Collections.Generic;
using System.Text;
using tkpl.View.Factory;
using tkpl.View.Factory.ModuleReport;
using tkpl.View.Factory.ReportCard;
using tkpl.View.User_Page;
using tkpl.View.User_Page.Factory;
using tkpl.View.User_Page.Factory.ReportModule;

namespace tkpl.Model.User
{
    internal class UserMenuControler
    {
        
        UserModel model;
        UserPage userPage;
        

        public UserMenuControler(UserModel model, UserPage userPage)
        {
            this.model = model;
            this.userPage = userPage;
        }

        public void UpdateMoleReport()
        {
            foreach (var module in RepoLevel.MasterTable)
            {
            
                foreach (var component in module.ReadOnlyComponents)
                {
                    if (component is Lesson lesson)
                    {
                        CreateModuleReportCard(lesson.Title);
                    }
                }
            }
        }

        public void CreateModuleReportCard(string lessonTitle)
        {
            decimal maxScoreWeight = 0;
            decimal totalScore = 0;
            bool isPassed = false;
            foreach (var reportQuizItem in ReportQuiz.QuizItems)
            {
                if(reportQuizItem.LessonTitle == lessonTitle)
                {
                    if(reportQuizItem.IsCorrect == AnswerStatus.Correct)
                    {
                        totalScore += reportQuizItem.ScoreWeight;
                    }
                    maxScoreWeight += reportQuizItem.ScoreWeight;
                }
            }
            decimal percentageScore = (totalScore / maxScoreWeight) * 100;
            if (percentageScore >= 70) { isPassed = true; }
            FactoryReportModule reportModule = ModuleReportCreatorFactory.CreateModuleReportCreator(isPassed, lessonTitle, totalScore, maxScoreWeight);
            IReportModule module = reportModule.CreateReportModule();
            UpdateReportCard(lessonTitle, module);
            userPage.AddModuleReport(reportModule.CreateModule());

        }

        public void UpdateReportCard(string lessonTitle, IReportModule module)
        {

            foreach (var reportQuizItem in ReportQuiz.QuizItems)
            {
                if (reportQuizItem.LessonTitle == lessonTitle)
                {
                    FactoryReportCard card = ReportCardCreatorFactory.CreateReportCardCreator
                   (reportQuizItem.IsCorrect, reportQuizItem.LessonTitle, reportQuizItem.CorrectAnswer, reportQuizItem.UserAnswer, reportQuizItem.QuestionText);
                    module.AddReportCard(card.CreateCard());
                }
                   
            }
        }

        public void ViewUserInfo() {
            userPage.GeneratLabel("Nama: " + model.GetUserName(), new System.Drawing.Point(24, 9), 12);
            userPage.GeneratLabel("Password: " + model.GetPassword(), new System.Drawing.Point(24, 54), 12);
            userPage.GeneratLabel("ID: " + model.GetUserId(), new System.Drawing.Point(24, 105), 12);
        }
        
    
    }
}
   
