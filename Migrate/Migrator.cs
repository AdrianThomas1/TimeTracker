using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TimeTracker.DbContext;
using TimeTracker.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Migrate
{
    public class MigratorOptions 
    {
        public string SourceDb { get; set; }
    }


    public static class MigratorExtensions
    {
        public static IServiceCollection AddMigratorService(this IServiceCollection collection,
            Action<MigratorOptions> setupAction)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));

            collection.Configure(setupAction);
            return collection.AddTransient<IMigrator, Migrator>();
        }
    }

    public interface IMigrator
    {
        void Migrate();
    }
    public class Migrator : IMigrator
    {
        private string sourceConnectionString;
        private TimeTrackerDbContext context;
        public Migrator(IOptions<MigratorOptions> Options, TimeTrackerDbContext context) 
        {
            this.sourceConnectionString = Options.Value.SourceDb;
            this.context = context;
        }


        public async void Migrate()
        {
            context.Database.Migrate();
            await context.Clients.IgnoreQueryFilters().LoadAsync();
            await context.Projects.IgnoreQueryFilters().LoadAsync();
            await context.TimeEntries.IgnoreQueryFilters().LoadAsync();

            /*
            using (SqliteConnection cnn = new SqliteConnection(sourceConnectionString))
            {
                cnn.Open();
                using (SqliteCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Projects ORDER BY Client,ProjectName";
                    DataTable projects = new DataTable();
                    projects.Load(cmd.ExecuteReader());

                    foreach (DataRow r in projects.Rows)
                    {
                        // Does the client exist
                        var client = context.Clients.Where(c => c.Name == (string)r["Client"]).FirstOrDefault();
                        if (client == null)
                            client = context.ChangeTracker.Entries()
                           .Where(x => x.State == EntityState.Added && x.Entity is Client t && t.Name == (string)r["Client"])
                           .Select(x => x.Entity as Client).FirstOrDefault();

                        if (client == null)
                        {
                            client = new Client()
                            {
                                Name = (string)r["Client"]
                            };
                            context.Clients.Add(client);
                        }

                        var project = context.Projects.Where(p => p.Client.Id == client.Id && p.Name == (string)r["ProjectName"]).FirstOrDefault();
                        if (project == null)
                            project = context.ChangeTracker.Entries()
                               .Where(x => x.State == EntityState.Added && x.Entity is Project t && t.Name == (string)r["ProjectName"] && t.Client.Name == client.Name)
                               .Select(x => x.Entity as Project).FirstOrDefault();
                        if (project == null)
                        {
                            project = new Project()
                            {
                                Name = (string)r["ProjectName"],
                                Client = client,
                                IsBillable = (long)r["Billable"] == 0 ? false : true,
                                IsEnabled = (long)r["Active"] == 0 ? false : true,
                                Reference = r["Description"] is DBNull ? null : (string)r["Description"]
                            };
                            context.Projects.Add(project);

                        }
                        else
                        {

                        }

                    }
                    var rc = context.SaveChanges();
                }
                cnn.Close();
            }
            */
            
            using (SqliteConnection cnn = new SqliteConnection(sourceConnectionString))
            {
                cnn.Open();
                using (SqliteCommand cmd = cnn.CreateCommand())
                { 
                    cmd.CommandText = @"select p.Client, p.ProjectName, t.Date, t.StartTime, t.EndTime, t.Description from TimeEntries t JOIN Projects p on p.ProjectID = t.ProjectID";
                    DataTable entries = new DataTable();
                    entries.Load(cmd.ExecuteReader());
                    foreach (DataRow r in entries.Rows)
                    {
                        var client = context.Clients.Where(c => c.Name == (string)r["Client"]).FirstOrDefault();
                        Project project = context.Projects.Where(p => p.Client.Id == client.Id && p.Name == (string)r["ProjectName"]).First();
                        TimeTracker.Models.TimeEntry t = new TimeTracker.Models.TimeEntry();
                        t.Project = project;
                        DateTime date = DateTime.ParseExact((string)r["Date"], "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime startTime = DateTime.ParseExact((string)r["StartTime"], "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime endTime = DateTime.ParseExact((string)r["EndTime"], "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        t.StartTime = date.Date.Add(startTime.TimeOfDay);
                        t.EndTime = date.Date.Add(endTime.TimeOfDay);
                        t.Comment = r["Comment"] is DBNull ? null : (string)r["Comment"];
                        context.TimeEntries.Add(t);
                    }
                    var rc = context.SaveChanges();

                    
                }
                cnn.Close();
                
            }
        }
    }
}
