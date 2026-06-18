using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model.User
{
    public class UserModel : IUserModel
    {
        private User user;
        private bool isLoggedIn = false;
        private static int idStart = RepoUser.idStart;

        public static User? CurrentUser { get; set; }

        public UserModel()
        {
            user = CurrentUser ?? new User();
        }

        public async Task<bool> SignUp(string username, string password)
        {
            
            bool isRegistered = await RepoUser.RegisterUserAsync(username, password);
            if(isRegistered)
            {
                user = new User(username, password);
                user.id = ++idStart;
                RepoUser.UserTable.Add(user);
                CurrentUser = user;
                isLoggedIn = true;
            }
            return isRegistered;
        }

        public bool Login(string username, string password)
        {
            foreach (var u in RepoUser.UserTable) {
                if (u.userName == username) {
                    if (u.password.Equals(password))
                    {
                        user = u;
                        CurrentUser = u;
                        isLoggedIn = true;
                        return isLoggedIn;
                    }
                }
            }
            return false;
        }       

        public void Logout() 
        {
            user = new User();
            CurrentUser = null;
            isLoggedIn = false;
        }

        public int GetUserId() { return user?.id ?? 0; }
        public string GetUserName() { return user?.userName ?? string.Empty; }
        public void SetUsername(string username) { if (user != null) user.userName = username; }
        public string GetPassword() { return user?.password ?? string.Empty; }
        public void SetPassword(string password) { if (user != null) user.password = password; }
    }
}
