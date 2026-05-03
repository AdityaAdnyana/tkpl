using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model
{
    internal class StateMachine : IStateMachine
    {
        public enum SessionState
        {
            loginPage, homePage, quizPage, materiPage, userPage
        }

        public static SessionState currentState { get; private set; }
        public static string stringCurentState = "";
        public void stateToHomePgae()
        {
            currentState = SessionState.homePage;
        }
        
        public void ChangeState(SessionState newState)
        {
            currentState = newState;
        }

        public void TransitionState(string newState)
        {
            while (currentState != SessionState.loginPage)
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
                        break;

                }
            }
        }

        

        public SessionState GetCurrentState()
        {
            throw new NotImplementedException();
        }
    }
}
