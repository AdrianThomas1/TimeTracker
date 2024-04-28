using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace TimeTracker.DbContext
{
    public class TimeTrackerDbContextFactory : IDesignTimeDbContextFactory<TimeTrackerDbContext>
    {
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        public TimeTrackerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TimeTrackerDbContext>();
            optionsBuilder.UseSqlite($"Data Source = {Configuration.GetSection("database").Value}");
            return new TimeTrackerDbContext(optionsBuilder.Options);
        }
    }
    public class TimeTrackerDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        #region Contructor
        public TimeTrackerDbContext(DbContextOptions<TimeTrackerDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        #endregion

        #region Public properties
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Models.TimeEntry> TimeEntries { get; set; }

        #endregion
        #region Overridden method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Client>();
            modelBuilder.Entity<Client>().Property<bool>("IsDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Client>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Project>().Property<bool>("IsDeleted").HasDefaultValue(false);
            modelBuilder.Entity<Project>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<TimeEntry>().Property<bool>("IsDeleted").HasDefaultValue(false);
            modelBuilder.Entity<TimeEntry>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            base.OnModelCreating(modelBuilder);
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
        #endregion

        #region Private method
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

        
        #endregion
    }
}
