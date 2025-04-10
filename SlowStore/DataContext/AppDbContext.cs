using SlowStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SlowStore.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }
}
