using Kata.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kata.Persistence
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
