using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Seed;

namespace Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Profile> Profiles { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
    public DbSet<PurchaseOrderStatusLog> PurchaseOrderStatusLogs { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Tracking> Trackings { get; set; }
    public DbSet<TrackingStatusLog> TrackingStatusLogs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProfileSeed());
        modelBuilder.ApplyConfiguration(new UserSeed());
        modelBuilder.ApplyConfiguration(new PurchaseOrderStatusLogSeed());
    }
}