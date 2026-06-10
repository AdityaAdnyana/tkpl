using System;
using System.Collections.Generic;
using System.Text;
using tkpl.View;
using tkpl.View.User_Page;

namespace tkpl.Model.User
{
    internal class UserMenuFacade
    {
        UserModel model;
        ReportQuiz  reportQuiz;
        public string username;
        public string password;
        public int userid;
        //UserMenuView userMenuView;
        public void UserInformation()
        {
            username = model.GetUserName();
            password = model.GetPassword();
            userid = model.GetUserId();
            UserMenuView.GenerateLabel(username);
            UserMenuView.GenerateLabel(password);
            UserMenuView.GenerateLabel(Convert.ToString(userid));


        }

        public void ViewReport()
        {

        }

        //add.ReportQuiz(lesson,isCorrect,curenQuestionIndex)
    }
}
