using API.Controllers;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class LevelControllerTests
    {
        // Fungsi pembantu untuk membuat AppDbContext versi RAM (InMemory) yang bersih setiap kali test dijalankan
        private AppDbContext GetInMemoryDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task GetAllModules_ShouldReturnOkWithAllData()
        {
            // Arrange
            using var context = GetInMemoryDbContext("GetAllModules_Db");

            // Masukkan data tiruan ke dalam RAM database
            context.Moduls.Add(new ModuleModels { Module_ID = 1, module_name = "Fisika Vektor" });
            context.Moduls.Add(new ModuleModels { Module_ID = 2, module_name = "Termodinamika" });
            await context.SaveChangesAsync();

            var controller = new LevelController(context);

            // Act
            var result = await controller.GetAllModules();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedModules = Assert.IsAssignableFrom<List<ModuleModels>>(okResult.Value);
            Assert.Equal(2, returnedModules.Count);
        }

        [Fact]
        public async Task GetModuleById_ShouldReturnOk_WhenModuleExists()
        {
            // Arrange
            using var context = GetInMemoryDbContext("GetModuleById_Exist_Db");
            var targetModule = new ModuleModels { Module_ID = 99, module_name = "Optika Geometri" };
            context.Moduls.Add(targetModule);
            await context.SaveChangesAsync();

            var controller = new LevelController(context);

            // Act
            var result = await controller.GetModuleById(99);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var module = Assert.IsType<ModuleModels>(okResult.Value);
            Assert.Equal("Optika Geometri", module.module_name);
        }

        [Fact]
        public async Task GetModuleById_ShouldReturnNotFound_WhenModuleDoesNotExist()
        {
            // Arrange
            using var context = GetInMemoryDbContext("GetModuleById_NotExist_Db");
            var controller = new LevelController(context);

            // Act
            // Memanggil ID 404 yang sengaja tidak dimasukkan ke database RAM
            var result = await controller.GetModuleById(404);

            // Assert
            // Memastikan jalur proteksi 'if (module == null)' tereksekusi sempurna!
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Modul dengan ID 404 tidak ditemukan.", notFoundResult.Value);
        }
    }
}
