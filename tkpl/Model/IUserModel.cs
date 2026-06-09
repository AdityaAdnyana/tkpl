using ImplemantasiGenericQuiz;
using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model
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
