using ImplemantasiGenericQuiz;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model
{
    internal class UserModel : IUserModel
    {

        private DateOnly lastLogin;
        private DateOnly thisDate = DateOnly.FromDateTime(DateTime.Now);
        int day; 
        public ArrayList streakCount = new ArrayList();
        
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AvrageScore(Lesson lesson)
        {
            throw new NotImplementedException();
        }

        public void DecreaseStreak()
        {
            throw new NotImplementedException();
        }

        public void IncreaseStreak(DateOnly thisDate)
        {
            streakCount.Add(thisDate);
        }

        public void Streak()
        {
            
            int selisih = thisDate.DayNumber - lastLogin.DayNumber;
            if (selisih >=1)
            {
                Console.WriteLine("Streak lose");
                day = 0;
            }
            else
            {
                day ++;
                IncreaseStreak(thisDate);

                Console.WriteLine("streak!!" + day);
            }
            lastLogin = thisDate;
        }

        public string ViewProfile()
        {
            throw new NotImplementedException();
        }

       
    }
}
