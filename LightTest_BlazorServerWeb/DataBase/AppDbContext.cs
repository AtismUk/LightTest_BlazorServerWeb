using LightTest_BlazorServerWeb.DataBase.Models.UserPart;
using Microsoft.EntityFrameworkCore;

namespace LightTest_BlazorServerWeb.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new List<User>() { new() { Id = 1, Name = "Admin", Login = "Admin", Password = "Admin", isAdmin = true } });
        }
    }
}
