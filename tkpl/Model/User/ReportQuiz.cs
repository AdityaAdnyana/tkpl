using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model
{
    public  class ReportQuiz
    {
        public Lesson lesson { get; set; }
        public bool isCorrect { get; set; } = false;

        public int userID { get; set; }





    }

    public static class ReportList
    {
        public static List<ReportQuiz> reportTable = new List<ReportQuiz>
        {
            new ReportQuiz{userID =1 ,isCorrect = true,lesson = null}
        };


    }
}
