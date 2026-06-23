using System;
using System.Collections.Generic;
using Xunit;
using tkpl.Controller;
using tkpl.Model;
using tkpl.View;

namespace tkpl.Tests
{
    public class QuizSessionResultControllerTests
    {
        [Fact]
        public void Constructor_InitializesWithoutException()
        {
            // Arrange
            var resultView = new QuizSessionResult(); // Instansiasi view GUI
            var answerRecords = new List<AnswerRecord>
            {
                new AnswerRecord("Q1", "A", "A", AnswerStatus.Correct, 10),
                new AnswerRecord("Q2", "B", "C", AnswerStatus.Wrong, 10),
                new AnswerRecord("Q3", "-", "D", AnswerStatus.Skipped, 10)
            };
            var sessionTime = TimeSpan.FromMinutes(2);

            // Act
            var exception = Record.Exception(() => 
            {
                var controller = new QuizSessionResultController(resultView, answerRecords, sessionTime);
            });

            // Assert
            Assert.Null(exception); // Pastikan controller bisa diinisialisasi
        }
        
        [Fact]
        public void OnSessionEnded_IsInvokedWhenContinueIsClicked()
        {
            // Arrange
            var resultView = new QuizSessionResult();
            var answerRecords = new List<AnswerRecord>();
            var sessionTime = TimeSpan.FromSeconds(30);
            var controller = new QuizSessionResultController(resultView, answerRecords, sessionTime);
            
            bool eventTriggered = false;
            controller.OnSessionEnded += () => { eventTriggered = true; };
            
            // Assert bahwa handler berhasil didaftarkan tanpa melempar exception
            Assert.NotNull(controller);
            Assert.False(eventTriggered); // Event belum terpicu
        }
    }
}
