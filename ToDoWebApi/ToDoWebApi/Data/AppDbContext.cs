using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoWebApi.Models;

namespace ToDoWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ToDo> ToDos => Set<ToDo>();
    }
}
