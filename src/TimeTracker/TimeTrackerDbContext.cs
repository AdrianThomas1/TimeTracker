using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TimeTracker.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TimeTracker;

public class TimeTrackerDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Project> Projects { get; set; }

    public TimeTrackerDbContext(DbContextOptions<TimeTrackerDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
        //Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Client>();
        modelBuilder.Entity<Client>(e =>
        {
            e.ToTable("Clients");
            e.HasQueryFilter(e => e.IsDeleted == false);
            e.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<Project>(e =>
        {
            e.ToTable("Projects");
            e.HasQueryFilter(e => e.IsDeleted == false);
            e.Property(e => e.IsDeleted).HasDefaultValue(false);
        });

        modelBuilder.Entity<TimeEntry>(e =>
        {
            e.ToTable("Entries");
            e.HasQueryFilter(e => e.IsDeleted == false);
            e.Property(e => e.IsDeleted).HasDefaultValue(false);
        });
        
        //base.OnModelCreating(modelBuilder);
    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public override int SaveChanges()
    {
        UpdateSoftDeleteStatuses();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        UpdateSoftDeleteStatuses();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void UpdateSoftDeleteStatuses()
    {
        foreach (var entry in ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.CurrentValues["IsDeleted"] = false;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.CurrentValues["IsDeleted"] = true;
                    break;
            }
        }
    }

}

public class DTTimeTrackerDbContext : IDesignTimeDbContextFactory<TimeTrackerDbContext>
{
    public TimeTrackerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TimeTrackerDbContext>();
        optionsBuilder.UseSqlite("Data Source =:memory:");
        return new TimeTrackerDbContext(optionsBuilder.Options);
    }
}
