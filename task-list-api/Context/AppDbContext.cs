using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using task_list_api.Models;

namespace task_list_api.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TaskModel> TaskModels { get; set; }
        public DbSet<ApplicationUser> UserModels { get; set; }

    }
}
