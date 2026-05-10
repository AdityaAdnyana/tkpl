using tkpl.Model;

namespace TestProject1
{
    public class UnitTestStateMachine
    {
        [Fact]
        public void TestTransitionState()
        {
            StateMachine stateMachine = new StateMachine();
            stateMachine.TransitionState("homePage");

            Assert.Equal(stateMachine, stateMachine);
            Assert.Equal("home page", StateMachine.stringCurentState);
        }

        [Fact]
        public void TestChangeState()
        {
            StateMachine stateMachine = new StateMachine();
            stateMachine.ChangeState(StateMachine.SessionState.homePage);

            Assert.Equal(stateMachine, stateMachine);
        }
    }
}
