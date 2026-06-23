using Xunit;
using System.Collections.Generic;
using tkpl.Model;
using tkpl.View.Factory.QuizControl;
using tkpl.View.Factory.ScoreCard;

namespace tkpl.Tests
{
    public class FactoryMethodTests
    {
        [Fact]
        public void QuizControlCreatorFactory_Create_WithObjectiveQuiz_ReturnsObjectiveQuizControlCreator()
        {
            // Arrange
            var objectiveQuiz = new ObjectiveQuiz<int> { Options = new List<int> { 1, 2 } };

            // Act
            var creator = QuizControlCreatorFactory.Create(objectiveQuiz, (isCorrect, answer) => { });

            // Assert
            Assert.NotNull(creator);
            Assert.IsType<ObjectiveQuizControlCreator>(creator);
        }

        [Fact]
        public void QuizControlCreatorFactory_Create_WithEssayQuiz_ReturnsEssayQuizControlCreator()
        {
            // Arrange
            var essayQuiz = new EssayQuiz<string>();

            // Act
            var creator = QuizControlCreatorFactory.Create(essayQuiz, (isCorrect, answer) => { });

            // Assert
            Assert.NotNull(creator);
            Assert.IsType<EssayQuizControlCreator>(creator);
        }

        [Fact]
        public void QuizControlCreatorFactory_Create_WithUnknownQuiz_ReturnsNull()
        {
            // Arrange
            var unknownQuiz = new UnknownQuizMock();

            // Act
            var creator = QuizControlCreatorFactory.Create(unknownQuiz, (isCorrect, answer) => { });

            // Assert
            Assert.Null(creator);
        }

        [Fact]
        public void ScoreCardCreatorFactory_Create_WithCorrectStatus_ReturnsCorrectScoreCardCreator()
        {
            // Act
            var creator = ScoreCardCreatorFactory.Create(AnswerStatus.Correct, "Q", "A", "C");

            // Assert
            Assert.NotNull(creator);
            Assert.IsType<CorrectScoreCardCreator>(creator);
        }

        [Fact]
        public void ScoreCardCreatorFactory_Create_WithWrongStatus_ReturnsIncorrectScoreCardCreator()
        {
            // Act
            var creator = ScoreCardCreatorFactory.Create(AnswerStatus.Wrong, "Q", "A", "C");

            // Assert
            Assert.NotNull(creator);
            Assert.IsType<IncorrectScoreCardCreator>(creator);
        }

        [Fact]
        public void ScoreCardCreatorFactory_Create_WithSkippedStatus_ReturnsSkippedScoreCardCreator()
        {
            // Act
            var creator = ScoreCardCreatorFactory.Create(AnswerStatus.Skipped, "Q", "A", "C");

            // Assert
            Assert.NotNull(creator);
            Assert.IsType<SkippedScoreCardCreator>(creator);
        }

        // Mock class for testing unknown IQuestion
        private class UnknownQuizMock : IQuestion
        {
            public int Difficulty { get; set; }
            public decimal ScoreWeight { get; set; }
            public string QuestionText { get; set; } = "";
            public string ImagePath { get; set; } = "";
            public bool ValidateAnswer(object answer) => false;
            public string GetExpectedAnswerAsString() => "";
        }
    }
}
