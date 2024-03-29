using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDo.WebAPI.Models;

namespace ToDo.WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDos => Set<ToDoItem>();
    }
}
