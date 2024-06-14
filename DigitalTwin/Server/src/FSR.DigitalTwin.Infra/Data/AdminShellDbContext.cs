using FSR.Aas.GRPC.Lib.V3;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace FSR.DigitalTwin.Infra.Data;

public class AdminShellDbContext : DbContext {
    public DbSet<EnvironmentDTO> Environments { get; init; }

    public AdminShellDbContext(DbContextOptions options)
        : base(options)
    {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<EnvironmentDTO>().ToCollection("environments");
    }

}