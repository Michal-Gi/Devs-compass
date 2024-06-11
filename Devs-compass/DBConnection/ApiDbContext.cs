using Devs_compass.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Devs_compass.DBConnection
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }

        public DbSet<SponsoredGameJam> SponsoredGameJams { get; set; }

        public DbSet<GameJamParticipation> GameJamsParticipations { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Opinion> Opinions { get; set; }

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OwnGameJam> OwnGameJams { get; set; }

        public DbSet<Software> Softwares { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
