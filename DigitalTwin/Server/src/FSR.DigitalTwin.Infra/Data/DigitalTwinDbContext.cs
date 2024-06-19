using Microsoft.EntityFrameworkCore;

namespace FSR.DigitalTwin.Infra.Data;

public class DigitalTwinDbContext : DbContext {
    // TODO Insert sets here...
    // public DbSet<SetType> Set { get; init; }
    
    public DigitalTwinDbContext(DbContextOptions options)
        : base(options)
    {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // TODO Insert models here...
    }

}