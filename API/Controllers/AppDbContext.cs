using API.Model;
using Microsoft.EntityFrameworkCore;
using static API.Model.QuizModel;
using static API.Model.ReadingMaterial;

namespace API.Controllers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ModuleModels> Moduls { get; set; }
        public DbSet<LessonModels> Lessons { get; set; }
        public DbSet<QuizModels> Quizzes { get; set; }
        public DbSet<EssayQuizModels> EssayQuizzes { get; set; }
        public DbSet<ObjectiveQuizModels> ObjectiveQuizzes { get; set; }
        public DbSet<ObjectiveQuizOptionsModels> ObjectiveQuizOptions { get; set; }
        public DbSet<ReadingMaterialModels> ReadingMaterials { get; set; }
        public DbSet<ReadingMaterialImageModels> ReadingMaterialImages { get; set; }
        public DbSet<QuizImageModels> QuizImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  Lesson -> Module
            modelBuilder.Entity<LessonModels>()
                .HasOne(l => l.Module)
                .WithMany(m => m.Lessons)
                .HasForeignKey(l => l.Module_ID);

            //  Quiz -> Lesson
            modelBuilder.Entity<QuizModels>()
                .HasOne(q => q.Lesson)
                .WithMany(l => l.Quizzes)
                .HasForeignKey(q => q.Lesson_ID);

            // EssayQuiz -> Quiz
            modelBuilder.Entity<EssayQuizModels>()
                .HasOne(e => e.Quiz)
                .WithMany(q => q.EssayQuizzes)
                .HasForeignKey(e => e.Quiz_ID);

            // ObjectiveQuiz -> Quiz
            modelBuilder.Entity<ObjectiveQuizModels>()
                .HasOne(o => o.Quiz)
                .WithMany(q => q.ObjectiveQuizzes)
                .HasForeignKey(o => o.Quiz_ID);

            // ObjectiveQuizOptions -> ObjectiveQuiz
            modelBuilder.Entity<ObjectiveQuizOptionsModels>()
                .HasOne(op => op.ObjectiveQuiz)
                .WithMany(o => o.Options)
                .HasForeignKey(op => op.Objective_Quiz_ID);

            // ReadingMaterial -> Module
            modelBuilder.Entity<ReadingMaterialModels>()
                .HasOne(r => r.Module)
                .WithMany(m => m.ReadingMaterials)
                .HasForeignKey(r => r.Module_ID);

            // ReadingMaterialImage -> ReadingMaterial
            modelBuilder.Entity<ReadingMaterialImageModels>()
                .HasOne(ri => ri.ReadingMaterial)
                .WithMany(r => r.Images)
                .HasForeignKey(ri => ri.Reading_Material_ID)
                .OnDelete(DeleteBehavior.Cascade);

            // QuizImage -> Quiz
            modelBuilder.Entity<QuizImageModels>()
                .HasOne(qi => qi.Quiz)
                .WithMany(q => q.QuizImages)
                .HasForeignKey(qi => qi.Quiz_ID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}