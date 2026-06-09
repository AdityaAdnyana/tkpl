using System;
using System.Collections.Generic;
using System.Text;

namespace tkpl.Model
{
    internal interface IStateMachine
    {
        public void ChangeState(StateMachine.SessionState newState);
        public StateMachine.SessionState GetCurrentState();

    }
}
