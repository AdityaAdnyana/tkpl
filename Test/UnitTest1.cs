using Xunit;
using System.Collections.Generic;
using tkpl.Model;

namespace tkpl.Tests
{
    public class EssayQuizTests
    {
        [Fact]
        public void ValidateAnswer_Correct_ReturnsTrue()
        {
            // Arrange
            var essayQuiz = new EssayQuiz<string>
            {
                QuestionText = "Siapakah penemu bola lampu?",
                ExpectedAnswer = "Thomas Alva Edison"
            };
            string inputJawaban = "Thomas Alva Edison";

            // Act
            bool isCorrect = essayQuiz.ValidateAnswer(inputJawaban);

            // Assert
            Assert.True(isCorrect);
        }

        [Fact]
        public void ValidateAnswer_Incorrect_ReturnsFalse()
        {
            // Arrange
            var essayQuiz = new EssayQuiz<string> { ExpectedAnswer = "Thomas Alva Edison" };
            string inputJawaban = "Nikola Tesla";

            // Act
            bool isCorrect = essayQuiz.ValidateAnswer(inputJawaban);

            // Assert
            Assert.False(isCorrect);
        }
    }

    public class ObjectiveQuizTests
    {
        [Fact]
        public void GetStringOptions_IntList_ReturnsStrings()
        {
            // Arrange
            var mathQuiz = new ObjectiveQuiz<int>
            {
                QuestionText = "Berapakah hasil 2 + 2?",
                ExpectedAnswer = 4,
                Options = new List<int> { 2, 3, 4, 5 }
            };

            // Act
            var stringOptions = mathQuiz.GetStringOptions();

            // Assert
            Assert.Equal(4, stringOptions.Count);
            Assert.Contains("4", stringOptions);
        }
    }

    public class QuestionTypeConversionTests
    {
        [Fact]
        public void ValidateAnswer_ValidStringToInt_ReturnsTrue()
        {
            // Arrange
            var question = new ObjectiveQuiz<int> { ExpectedAnswer = 4 };
            object inputDariUI = "4";

            // Act
            bool isCorrect = question.ValidateAnswer(inputDariUI);

            // Assert
            Assert.True(isCorrect);
        }

        //Revisi: test sekarang bukan lagi cek apakah hasilnya false,
        //tapi apakah terjadi FormatException saat mencoba mengkonversi string yang tidak valid ke int.
        [Fact]
        public void ValidateAnswer_InvalidCast_ThrowsFormatException()
        {
            // Arrange
            var question = new ObjectiveQuiz<int> { ExpectedAnswer = 4 };
            object inputSalahTipe = "Bukan Angka";
            Assert.Throws<FormatException>(() =>
            {
                question.ValidateAnswer(inputSalahTipe);
            });
        }
    }

    public class LessonTests
    {
        [Fact]
        public void AddQuestions_IncrementsCount()
        {
            // Arrange
            var lesson = new Lesson();
            var q1 = new EssayQuiz<string>();
            var q2 = new ObjectiveQuiz<int>();

            // Act
            lesson.Questions.Add(q1);
            lesson.Questions.Add(q2);

            // Assert
            Assert.Equal(2, lesson.Questions.Count);
        }
    }
}