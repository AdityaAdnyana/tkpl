using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model
{
    public class StateMachine : IStateMachine
    {
        public enum SessionState // membbuat state mengunakan enum
        {
            loginPage, homePage, quizPage, materiPage, userPage //nesar kecil
        }

        public static SessionState currentState { get; private set; }
        public static string stringCurentState = ""; // untuk menampilkan state dalam bentuk string

        // untuk mengubah state ke home page
        // harap dipanghgil ketika pertamakali apk dijalankan
        public void stateToHomePgae() 
        {
            currentState = SessionState.homePage;
        }

        // mengubah state sesuai dengan state yang diinginkan
        public void ChangeState(SessionState newState)
        {
            currentState = newState;
        }

        //mengecek apakah sate awal(A) dapat pindah ke satete yang dipilih(B)

        public void TransitionState(string newState)
        {
            
                switch (currentState)
                {
                    case SessionState.loginPage:
                        break;
                    case SessionState.homePage:
                        if (newState == "quiz")
                        {
                            Console.WriteLine("qquiz page");
                            stringCurentState = "quiz page";
                            ChangeState(SessionState    .quizPage);
                        }
                        else if (newState == "materi")
                        {
                            Console.WriteLine("materi page");
                            stringCurentState = "materi page";
                            ChangeState(SessionState.materiPage);
                        }
                        else if (newState == "user")
                        {
                            Console.WriteLine("user page");
                            stringCurentState = "user page";
                            ChangeState(SessionState.userPage);
                        }
                        else
                        {
                            Console.WriteLine("home page");
                            stringCurentState = "home page";
                            ChangeState(SessionState.homePage);
                        }
                        break;
                    case SessionState.quizPage:
                        if (newState == "materi")
                        {
                            Console.WriteLine("materi page");
                            stringCurentState = "materi page";
                            ChangeState(SessionState.materiPage);
                        }
                        else if (newState == "home")
                        {
                            Console.WriteLine("home page");
                            stringCurentState = "home page";
                            ChangeState(SessionState.homePage);
                        }
                        else
                        {
                            Console.WriteLine("quiz page");
                            stringCurentState = "quiz page";
                            ChangeState(SessionState.quizPage);
                        }
                        break;
                    case SessionState.materiPage:
                        if (newState == "quiz")
                        {
                            Console.WriteLine("quiz page");

                            ChangeState(SessionState.quizPage);
                        }
                        else if (newState == "home")
                        {
                            Console.WriteLine("home page");
                            ChangeState(SessionState.homePage);
                        }
                        else
                        {
                            Console.WriteLine("materi page");
                            ChangeState(SessionState.materiPage);
                        }
                        break;
                    case SessionState.userPage:
                        if (newState == "login")
                        {
                            Console.WriteLine("login page");
                            ChangeState(SessionState.loginPage);
                        }
                        else if (newState == "home")
                        {
                            Console.WriteLine("home page");
                            ChangeState(SessionState.homePage);
                        }
                        else 
                        { 
                            Console.WriteLine("user page");
                            ChangeState(SessionState.userPage);
                        }
                        break;

                }
        }

        
        // untuk mengambilk state saat ini 
        public SessionState GetCurrentState()
        {
            return currentState;
        }
    }
}
