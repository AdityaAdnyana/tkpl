using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class DataLevelTests
    {
        // Test 
        [Fact]
        public void Lesson_Initialization_ShouldSetCorrectProperties()
        {
            var lesson = new Lesson("Kinematika Rotasi", "Materi tentang Torsi dan Momen Inersia");

            Assert.Equal("Kinematika Rotasi", lesson.GetTitle());
            Assert.Empty(lesson.Questions);
        }

        [Fact]
        public void Module_AddComponent_ShouldStoreLessonCorrectly()
        {
            var module = new Module(4, "Fisika Dasar");
            var lesson = new Lesson("Gelombang", "Materi Gelombang Longitudinal");

            module.AddComponent(lesson);

            Assert.Single(module.ReadOnlyComponents);
            Assert.Same(lesson, module.ReadOnlyComponents.First());
        }
    }
}

