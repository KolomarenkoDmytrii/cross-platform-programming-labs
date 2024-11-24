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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed initial data
        modelBuilder.Entity<RefSize>().HasData(
            new RefSize { SizeCode = "SMALL", SizeDescription = "Small" },
            new RefSize { SizeCode = "MEDIUM", SizeDescription = "Medium" },
            new RefSize { SizeCode = "LARGE", SizeDescription = "Large" }
        );

        modelBuilder.Entity<Location>().HasData(
            new Location { LocationID = 1, LocationDetails = "Rivercity" },
            new Location { LocationID = 2, LocationDetails = "London" },
            new Location { LocationID = 3, LocationDetails = "Rome" }
        );

        modelBuilder.Entity<RefStatus>().HasData(
            new RefStatus { StatusCode = "PAID", StatusDescription = "Paid" },
            new RefStatus { StatusCode = "DELIVERED", StatusDescription = "Delivered" },
            new RefStatus { StatusCode = "CANCELLED", StatusDescription = "Cancelled" }
        );

        modelBuilder.Entity<RefAssetCategory>().HasData(
            new RefAssetCategory { AssetCategoryCode = "DOMESTIC", AssetCategoryDescription = "Domestic" }
        );

        modelBuilder.Entity<RefAssetSupertype>().HasData(
            new RefAssetSupertype
            {
                AssetSupertypeCode = "CUTLERY",
                AssetCategoryCode = "DOMESTIC",
                AssetSupertypeDescription = "Cutlery"
            }
        );

        modelBuilder.Entity<RefAssetType>().HasData(
            new RefAssetType
            {
                AssetTypeCode = "SPOON",
                AssetSupertypeCode = "CUTLERY",
                AssetTypeDescription = "Spoon"
            }
        );

        modelBuilder.Entity<Asset>().HasData(
            new Asset
            {
                AssetID = 1,
                AssetTypeCode = "SPOON",
                SizeCode = "SMALL",
                AssetName = "UltraSpoon",
                OtherDetails = "Great ultra spoon"
            }
        );

        modelBuilder.Entity<LifeCyclePhase>().HasData(
            new LifeCyclePhase
            {
                LifeCycleCode = "START",
                LifeCycleName = "Start",
                LifeCycleDescription = "Start of a life cycle"
            }
        );

        modelBuilder.Entity<ResponsibleParty>().HasData(
            new ResponsibleParty { PartyID = 1, PartyDetails = "Johnsons Ltd." }
        );

        modelBuilder.Entity<AssetLifeCycleEvent>().HasData(
            new AssetLifeCycleEvent
            {
                AssetLifeCycleEventID = 1,
                AssetID = 1,
                LifeCycleCode = "START",
                LocationID = 1,
                PartyID = 1,
                StatusCode = "DELIVERED",
                DateFrom = new DateTime(2024, 11, 20),
                DateTo = new DateTime(2024, 11, 21)
            }
        );
    }
}
