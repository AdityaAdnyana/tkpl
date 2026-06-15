using System;
using System.Collections.Generic;
using System.Text;
using tkpl;

namespace tkpl.Model.User
{
    public class User 
    {
        public string userName { get; set; }
        public string password { get; set; } = string.Empty;
        public int id { get; set; }

        public User() { }

        public User(string name,string pass)
        {
            userName = name;
            password = pass;
        }
    }
}
