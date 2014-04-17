using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceData.Entities;
using ConferenceData.Migrations;

namespace ConferenceData
{
    public class ConferenceDbContext : DbContext
    {
        static ConferenceDbContext()
        {
            // Enable database migrations to the latest version on startup
            Database.SetInitializer<ConferenceDbContext>(new MigrateDatabaseToLatestVersion<ConferenceDbContext, Configuration>());

            // EF6 hack to copy EntityFramework.SqlServer.dll to bin
            var hack = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public ConferenceDbContext()
        {
            // Disable lazy loading entities
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<ConferenceAttendee> ConferenceAttendees { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionAttendee> SessionAttendees { get; set; }
        public DbSet<SessionFormat> SessionFormats { get; set; }
        public DbSet<SessionSpeaker> SessionSpeakers { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
