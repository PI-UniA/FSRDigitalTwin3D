using FSR.Aas.GRPC.Lib.V3;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace FSR.DigitalTwin.Infra.Data;

public class AdminShellDbContext : DbContext {
    // TODO Either use custom models NOT the DTOs from gRPC.
    public DbSet<AssetAdministrationShellDTO> AdminShells { get; init; }
    // public DbSet<SubmodelDTO> Submodels { get; init; }
    public DbSet<ConceptDescriptionDTO> ConceptDescriptions { get; init; }

    public AdminShellDbContext(DbContextOptions options)
        : base(options)
    {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AssetAdministrationShellDTO>().ToCollection("adminShells");
        // modelBuilder.Entity<SubmodelDTO>().ToCollection("submodels");
        modelBuilder.Entity<ConceptDescriptionDTO>().ToCollection("conceptDescriptions");
    }

}