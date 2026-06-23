using Xunit;
using tkpl.Controller;
using tkpl.Model;
using tkpl.Model.User;
using tkpl.View;

namespace tkpl.Tests
{
    public class QuizSessionControllerTests
    {
        [Fact]
        public void Constructor_InitializesWithoutException()
        {
            // Arrange
            int levelId = 1;
            var lesson = new Lesson("Unit Test Lesson", "Test Content");
            
            var quizView = new QuizView();
            var logic = LogicLevel.Instance();
            var userModel = new UserModel();

            // Act
            var exception = Record.Exception(() => 
            {
                var controller = new QuizSessionController(levelId, lesson, quizView, logic, userModel);
            });

            // Assert
            Assert.Null(exception); // Pastikan tidak ada exception saat diinisialisasi
        }
    }
}
