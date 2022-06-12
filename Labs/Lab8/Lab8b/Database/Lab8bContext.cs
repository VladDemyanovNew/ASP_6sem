using Lab8b.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab8b.Database;

public class Lab8bContext : DbContext
{
    public Lab8bContext()
    {
    }

    public Lab8bContext(DbContextOptions<Lab8bContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users => this.Set<User>();
}
