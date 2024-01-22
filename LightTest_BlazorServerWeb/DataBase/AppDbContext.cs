using LightTest_BlazorServerWeb.DataBase.Models.MainPart;
using LightTest_BlazorServerWeb.DataBase.Models.Test;
using LightTest_BlazorServerWeb.DataBase.Models.UserPart;
using Microsoft.EntityFrameworkCore;

namespace LightTest_BlazorServerWeb.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(new List<UserEntity>() { new() { Id = 1, Name = "Admin", Login = "Admin", Password = "Admin", isAdmin = true } });

            modelBuilder.Entity<TestEntity>().HasData(new List<TestEntity>() { new() { Id = 1, Name = "Тест на основы безопасности", Description = "Jgbcfybt tgnf gdsgdfdfgsdgdgdf"} });

            modelBuilder.Entity<QuestionEntity>().HasData(new List<QuestionEntity>() { new() { Id = 1, Name = "Что такое техника безопасности", Text = "Da", testId = 1} });
            modelBuilder.Entity<AnswerEntity>().HasData(new List<AnswerEntity>() {
                new() { Id = 1, Text = "Это один", questionId = 1 },
                new() {Id = 2, Text = "Это Тб", questionId = 1, isCorrect = true},
                new() {Id = 3, Text = "Test of lenght question", questionId = 1},
                });

            modelBuilder.Entity<QuestionEntity>().HasData(new List<QuestionEntity>() { new() { Id = 2, Name = "Типы техники безопасности", Text = "Da", testId = 1} });
            modelBuilder.Entity<AnswerEntity>().HasData(new List<AnswerEntity>() {
                new() { Id = 4, Text = "Ну это это", questionId = 2, isCorrect = true },
                new() {Id = 5, Text = "Это Тб но вот такое", questionId = 2, isCorrect = true},
                new() {Id = 6, Text = "Я незнаю", questionId = 2},
                });
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<SectionEntity> Sections { get; set; }
        public DbSet<ArticleEntity> Articles { get; set; }
        public DbSet<TopicEntity> Topics { get; set; }


        public DbSet<TestEntity> Tests { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<AnswerEntity> Answers { get; set; }
        public DbSet<TestResultEntity> TestResults { get; set; }
        public DbSet<AnswerResultEntity> AnswerResults { get; set; }
    }
}
