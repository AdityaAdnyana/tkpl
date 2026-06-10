using System;
using System.Collections.Generic;
using System.Text;
using tkpl.Model.User;

public static class RepoUser
{
    public static int idStart = 3;
    public static List<User> UserTable = new List<User>
    {
        new User { id = 1, userName = "admin", password = "admin123" },
        new User { id = 2, userName = "user1", password = "password1" },
        new User { id = 3, userName = "user2", password = "password2" }
    };
}
