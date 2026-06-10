using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ModuleModels> Moduls { get; set; }
        public DbSet<LessonModels> lessons { get; set; }
    }
}
