namespace DatabaseApp.Data;

using Microsoft.EntityFrameworkCore;
using DatabaseApp.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseInMemoryDatabase(databaseName: "CppDb");
        optionsBuilder.UseSqlite($"Data Source=app.db");
    }

    public DbSet<LifeCyclePhase> LifeCyclePhases { get; set; }
    public DbSet<ResponsibleParty> ResponsibleParties { get; set; }
    public DbSet<RefAssetCategory> RefAssetCategories { get; set; }
    public DbSet<RefSize> RefSizes { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<RefStatus> RefStatuses { get; set; }
    public DbSet<RefAssetSupertype> RefAssetSupertypes { get; set; }
    public DbSet<RefAssetType> RefAssetTypes { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<AssetLifeCycleEvent> AssetLifeCycleEvents { get; set; }
}
