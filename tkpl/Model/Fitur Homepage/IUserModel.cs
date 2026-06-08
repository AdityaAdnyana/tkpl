using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model.HomePage
{
    interface IUserModel
    {
       
        public void AvrageScore(Lesson lesson);

        public void Streak();

        public String ViewProfile();

        public void IncreaseStreak(DateOnly thisDate);
        public void DecreaseStreak();
    }
}
