using Microsoft.EntityFrameworkCore;
using Todolist.Models;

namespace Todolist.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(

                new Todo { Id = 1, Task = "Assignmnet", Deadline = "09-12-2024" },
                new Todo { Id = 2, Task = "Contruction", Deadline = "09-03-2025" },
                new Todo { Id = 3, Task = "Java learning", Deadline = "09-02-2026" }
                );
        }

    }
}
