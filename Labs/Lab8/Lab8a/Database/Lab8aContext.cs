namespace Lab8a.Database;

using Lab8a.Database.Entities;
using Microsoft.EntityFrameworkCore;

public class Lab8aContext : DbContext
{
    public Lab8aContext()
    {
    }

    public Lab8aContext(DbContextOptions<Lab8aContext> options)
        : base(options)
    {
    }

    public DbSet<Phone> Phones => this.Set<Phone>();
}
