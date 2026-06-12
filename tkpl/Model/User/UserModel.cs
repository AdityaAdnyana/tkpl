using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model.User
{
    internal class UserModel : IUserModel
    {
        private User user;
        int idStart = RepoUser.idStart;
        public void SingUp(string username, string password)
        {
            user.userName = username;
            user.password = password;
            user.id = idStart ++; 
            RepoUser.UserTable.Add(user);
            
        }
        public void Login(string username, string password)
        {
            foreach (var user in RepoUser.UserTable) {
                if (user.userName == username) {
                    if (user.password.Equals(password))
                    {
                        user.userName = username;
                        user.password = password;
                        user.id = user.id;
                    }
                }
            }
        }       

        public void Logout() 
        {
            user.userName = string.Empty;
            user.password = string.Empty;
            user.id = 0;
        }

        public int GetUserId() { return user.id; }
        public string GetUserName() { return user.userName; }
        public void SetUsername(string username) { user.userName = username; }
        public string GetPassword() { return user.password; }

        
        public void SetPassword(string password) { user.password = password; }
    }
}
