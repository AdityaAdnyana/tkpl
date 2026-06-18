using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Rdho_Ananta_Wibowo
{
    public class RepoLevelTests
    {
        [Fact]
        public void MasterTable_ShouldInitializeAsEmptyList()
        {
            // Act & Assert
            Assert.NotNull(RepoLevel.MasterTable);
        }

        [Fact]
        public void LevelToModuleMap_ShouldInitializeAsEmptyDictionary()
        {
            // Act & Assert
            Assert.NotNull(RepoLevel.LevelToModuleMap);
        }
    }
}
