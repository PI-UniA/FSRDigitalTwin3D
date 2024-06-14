using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace FSR.DigitalTwin.Infra.Data;

public class AdminShellDbContext : DbContext {
    public DbSet<AasCore.Aas3_0.Environment> Environments { get; init; }

    public AdminShellDbContext(DbContextOptions options)
        : base(options)
    {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AasCore.Aas3_0.Environment>().ToCollection("environments");
    }

}