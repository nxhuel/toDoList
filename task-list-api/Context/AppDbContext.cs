using Microsoft.EntityFrameworkCore;
using task_list_api.Models;

namespace task_list_api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<LoginModel> LoginModels { get; set; }
        public DbSet<TaskModel> TaskModels { get; set; }

    }
}
