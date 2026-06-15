using System;
using System.Collections.Generic;
using System.Text;
using tkpl.View.User_Page;

namespace tkpl.Model.User
{
    internal class UserMenuFacade
    {
        UserModel model;
        UserPage userPage;

        public UserMenuFacade(UserModel model, UserPage userPage)
        {
            this.model = model;
            this.userPage = userPage;
        }

        public void ViewUserInfo() {
            userPage.GeneratLabel("Nama: " + model.GetUserName(), new System.Drawing.Point(24, 9), 12);
            userPage.GeneratLabel("Password: " + model.GetPassword(), new System.Drawing.Point(24, 54), 12);
            userPage.GeneratLabel("ID: " + model.GetUserId(), new System.Drawing.Point(24, 105), 12);
        }
        public void ViewUserLevelProgres() {
            
        }
    
    }
}
   
