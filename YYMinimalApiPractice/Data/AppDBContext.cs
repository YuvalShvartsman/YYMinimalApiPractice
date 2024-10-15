using Microsoft.EntityFrameworkCore;
using YYMinimalApiPractice.Models;

namespace YYMinimalApiPractice.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TodoModel> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.Todos)  
                .WithOne(t => t.User)   
                .HasForeignKey(t => t.UserId)  
                .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
