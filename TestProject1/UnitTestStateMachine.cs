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

    public class RuntimeConfigTests
    {
        [Fact]
        public void TestHostConfig()
        {
            // Mengambil data dari runtimeconfig.json
            string host = AppContext.GetData("DB_HOST")?.ToString() ?? "localhost";

            Assert.Equal(host, "localhost");

        }
        [Fact]
        public void TestPortConfig()
        {
            // Mengambil data dari runtimeconfig.json
            string port = AppContext.GetData("DB_PORT")?.ToString() ?? "3306";

            Assert.Equal(port, "3306");

        }
        [Fact]
        public void TestDatabaseConfig()
        {
            // Mengambil data dari runtimeconfig.json
            string db = AppContext.GetData("DB_NAME")?.ToString() ?? "db_tkpl";

            Assert.Equal(db, "db_tkpl");

        }
        [Fact]
        public void TestuserConfig()
        {
            // Mengambil data dari runtimeconfig.json
            string user = AppContext.GetData("DB_USER")?.ToString() ?? "root";
            Assert.Equal(user, "root");

        }
        [Fact]
        public void TestPasswordConfig()
        {
            // Mengambil data dari runtimeconfig.json
            string pass = AppContext.GetData("DB_PASS")?.ToString() ?? "Admin123";

            Assert.Equal(pass, "Admin123");

        }


       
      
    }
}
