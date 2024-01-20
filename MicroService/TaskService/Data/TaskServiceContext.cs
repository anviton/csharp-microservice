using Microsoft.EntityFrameworkCore;
using TaskService.Entities;

namespace TaskService.Data
{
    public class TaskServiceContext : DbContext
    {
        public TaskServiceContext(DbContextOptions<TaskServiceContext> options) : base(options) 
        { }

        public DbSet<Entities.Task> Task { get; set; } = default!;
    }
}
