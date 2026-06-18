using System;
using System.Collections.Generic;
using System.Text;
using tkpl.Controller;
using tkpl.Model.Observer;
using Xunit;

namespace Test
{
    public class MockLivesObserver : ILivesObserver
    {
        public int UpdatedLives = 0;
        public bool UpdateCalled = false;

        public void Update(int lives)
        {
            UpdatedLives = lives;
            UpdateCalled = true;
        }
    }

    public class SingletonFixture { }

    [Collection("SingletonTests")]
    public class SingletonPatternTests : IClassFixture<SingletonFixture>
    {
        [Fact]
        public void LogicLevel_Instance_ShouldAlwaysReturnSameInstance()
        {
            var firstCall = LogicLevel.Instance();
            var secondCall = LogicLevel.Instance();

            Assert.NotNull(firstCall);
            Assert.Same(firstCall, secondCall);
        }

        [Fact]
        public void LogicLevel_State_ShouldBeSharedAcrossInstances()
        {
            var instance1 = LogicLevel.Instance();
            var instance2 = LogicLevel.Instance();

            instance1.ResetLives(9);

            Assert.Equal(3, instance1.CurrentLives);
            Assert.Equal(3, instance2.CurrentLives);

            instance1.DecreaseLives();

            Assert.Equal(instance1.CurrentLives, instance2.CurrentLives);
            Assert.Equal(2, instance2.CurrentLives);
        }
    }


    [Collection("SingletonTests")]
    public class ObserverPatternTests : IClassFixture<SingletonFixture>
    {
        [Fact]
        public void DecreaseLives_ShouldNotifyRegisteredObservers()
        {
            var logicLevel = LogicLevel.Instance();

            // Paksa reset ke kondisi awal
            logicLevel.ResetLives(9);

            var mockObserver = new MockLivesObserver();

            Assert.False(mockObserver.UpdateCalled);
            Assert.Equal(0, mockObserver.UpdatedLives);

            logicLevel.Subscribe(mockObserver);

            // Act
            logicLevel.DecreaseLives();

            // Assert
            Assert.True(mockObserver.UpdateCalled);
            Assert.Equal(2, mockObserver.UpdatedLives);

            // Clean up wajib dilakukan di akhir agar list kembali kosong
            logicLevel.Unsubscribe(mockObserver);
        }
    }
}
