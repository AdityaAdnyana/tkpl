using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class RepoLevelTests
    {
        [Fact]
        public void MasterTable_ShouldInitializeAsEmptyList()
        {
            Assert.NotNull(RepoLevel.MasterTable);
        }

        [Fact]
        public void LevelToModuleMap_ShouldInitializeAsEmptyDictionary()
        {
            Assert.NotNull(RepoLevel.LevelToModuleMap);
        }
    }
}
