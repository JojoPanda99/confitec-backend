using ConfitecAPIBusiness.Models;
using ConfitecAPIData.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ConfitecAPIData.Context;

public class ConfitecApiContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ConfitecApiContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConfitecApiContext).Assembly);
    }
}