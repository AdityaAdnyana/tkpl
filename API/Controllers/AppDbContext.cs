using API.Model;
using Microsoft.EntityFrameworkCore;
using static API.Model.QuizModel;
using static API.Model.ReadingMaterial;

namespace API.Controllers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModels> Users { get; set; }
        public DbSet<LevelModels> Levels { get; set; }
        public DbSet<LevelModuleDetailModels> LevelModuleDetails { get; set; }
        public DbSet<ReportQuizModels> ReportQuizzes { get; set; }
        public DbSet<ModuleModels> Moduls { get; set; }
        public DbSet<LessonModels> Lessons { get; set; }
        public DbSet<QuizModels> Quizzes { get; set; }
        public DbSet<EssayQuizModels> EssayQuizzes { get; set; }
        public DbSet<ObjectiveQuizModels> ObjectiveQuizzes { get; set; }
        public DbSet<ObjectiveQuizOptionsModels> ObjectiveQuizOptions { get; set; }
        public DbSet<QuizImageModels> QuizImages { get; set; }
        public DbSet<ReadingMaterialModels> ReadingMaterials { get; set; }
        public DbSet<ReadingMaterialImageModels> ReadingMaterialImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Sesuai constraint: users_ibfk_1
            modelBuilder.Entity<UserModels>()
                .HasOne(u => u.CurrentLevel)
                .WithMany()
                .HasForeignKey(u => u.Current_Level_ID);

            // Sesuai constraint: level_module_detail_ibfk_1 & 2
            modelBuilder.Entity<LevelModuleDetailModels>()
                .HasOne(lmd => lmd.Module)
                .WithMany()
                .HasForeignKey(lmd => lmd.ModuleId);

            modelBuilder.Entity<LevelModuleDetailModels>()
                .HasOne(lmd => lmd.Level)
                .WithMany()
                .HasForeignKey(lmd => lmd.LevelId);

            // Sesuai constraint: report_quiz_ibfk_1, 2, & 3
            modelBuilder.Entity<ReportQuizModels>()
                .HasOne(rq => rq.User)
                .WithMany()
                .HasForeignKey(rq => rq.User_ID);

            modelBuilder.Entity<ReportQuizModels>()
                .HasOne(rq => rq.Quiz)
                .WithMany()
                .HasForeignKey(rq => rq.Quiz_ID);

            modelBuilder.Entity<ReportQuizModels>()
                .HasOne(rq => rq.Level)
                .WithMany()
                .HasForeignKey(rq => rq.Level_ID);

            // Relasi kuis dasar bawaan lama
            modelBuilder.Entity<LessonModels>()
                .HasOne(l => l.Module)
                .WithMany(m => m.Lessons)
                .HasForeignKey(l => l.Module_ID);

            modelBuilder.Entity<QuizModels>()
                .HasOne(q => q.Lesson)
                .WithMany(l => l.Quizzes)
                .HasForeignKey(q => q.Lesson_ID);

            modelBuilder.Entity<EssayQuizModels>()
                .HasOne(e => e.Quiz)
                .WithMany(q => q.EssayQuizzes)
                .HasForeignKey(e => e.Quiz_ID);

            modelBuilder.Entity<ObjectiveQuizModels>()
                .HasOne(o => o.Quiz)
                .WithMany(q => q.ObjectiveQuizzes)
                .HasForeignKey(o => o.Quiz_ID);

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