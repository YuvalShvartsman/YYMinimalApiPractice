
using Microsoft.EntityFrameworkCore;
using YYMinimalApiPractice.Models;

namespace YYMinimalApiPractice.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<TodoModel> Todo { get; set; }

    }
}
