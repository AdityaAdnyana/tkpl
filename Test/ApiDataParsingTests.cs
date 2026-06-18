using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class ApiDataParsingTests
    {
        [Fact]
        public void ModuleFromApi_ShouldHoldLessonsCorrectly()
        {
            var moduleDto = new ModuleFromApi
            {
                Module_ID = 1,
                Module_Name = "Mekanika",
                Lessons = new List<LessonFromApi> { new LessonFromApi { Lesson_ID = 10, Lesson_Name = "Vektor" } }
            };

            Assert.Equal(1, moduleDto.Module_ID);
            Assert.Single(moduleDto.Lessons);
            Assert.Equal("Vektor", moduleDto.Lessons[0].Lesson_Name);
        }
    }
}
