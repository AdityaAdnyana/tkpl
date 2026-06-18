using System;
using System.Collections.Generic;
using System.Text;
using tkpl.Controller;
using tkpl.Model.Observer;

namespace Test.Rdho_Ananta_Wibowo
{
    public class MockLivesObserver : ILivesObserver
    {
        public int UpdatedLives { get; private set; }
        public bool UpdateCalled { get; private set; } = false;

        public void Update(int lives)
        {
            UpdatedLives = lives;
            UpdateCalled = true;
        }
    }

    public class SingletonPatternTests
    {
        [Fact]
        public void LogicLevel_Instance_ShouldAlwaysReturnSameInstance()
        {
            // Arrange & Act
            // Mengambil instance pertama dan kedua dari Singleton
            var firstCall = LogicLevel.Instance();
            var secondCall = LogicLevel.Instance();

            // Assert
            // 1. Memastikan objek tidak bernilai null setelah dipanggil
            Assert.NotNull(firstCall);

            Assert.Same(firstCall, secondCall);
        }

        [Fact]
        public void LogicLevel_State_ShouldBeSharedAcrossInstances()
        {
            // Arrange
            var instance1 = LogicLevel.Instance();
            var instance2 = LogicLevel.Instance();

            // Atur nyawa awal lewat instance pertama
            instance1.ResetLives(9); // 9 kuis / 3 = 3 nyawa

            // Act
            // Kurangi nyawa menggunakan objek instance pertama
            instance1.DecreaseLives();

            // Assert
            // Memastikan perubahan state di instance1 otomatis berdampak pada instance2 karena mereka satu objek
            Assert.Equal(instance1.CurrentLives, instance2.CurrentLives);
            Assert.Equal(2, instance2.CurrentLives);
        }
    }

    public class ObserverPatternTests
    {
        [Fact]
        public void LogicLevel_Is_True_Singleton()
        {
            // Act
            var instance1 = LogicLevel.Instance();
            var instance2 = LogicLevel.Instance();

            // Assert
            Assert.Same(instance1, instance2);
        }

        [Fact]
        public void DecreaseLives_ShouldNotifyRegisteredObservers()
        {
            var logicLevel = LogicLevel.Instance();

            // SOLUSI KUNCI: Paksa reset nyawa secara eksplisit ke 3 menggunakan parameter totalQuestions = 9 (9 / 3 = 3)
            logicLevel.ResetLives(9);

            var mockObserver = new MockLivesObserver();
            logicLevel.Subscribe(mockObserver);

            // Act
            logicLevel.DecreaseLives();

            // Assert
            Assert.True(mockObserver.UpdateCalled);
            // Sekarang nilai awal dijamin pasti 3, dan setelah dikurangi pasti menjadi 2!
            Assert.Equal(2, mockObserver.UpdatedLives);

            // Clean up observer agar tidak membocorkan event ke pengujian selanjutnya
            logicLevel.Unsubscribe(mockObserver);
        }
    }
}
