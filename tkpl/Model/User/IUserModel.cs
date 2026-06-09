using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model.User
{
    interface IUserModel
    {

        void SingUp(string username, string password);
        void Login(string username, string password);

        void Logout();

        int GetUserId();

        string GetUserName();
        void SetUsername(string username);

        string GetPassword();

        void SetPassword(string password);
    }
}
