using Core.Models;
using Infrastruture.Mapping;
using System.Data.Entity;

namespace Infrastruture
{
    public class StartCompetingContext : DbContext, IStartCompetingContext
    {
        public StartCompetingContext() : base("name=StartCompetingContext")
        {
            Database.SetInitializer(new StartCompetingInitializer());
        }

        public DbSet<User> StartCompetingUsers { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<RaceType> RaceType { get; set; }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<Achievement> Achievement { get; set; }
        public DbSet<AchievementRequirement> AchievementRequirement { get; set; }
        public DbSet<League> League { get; set; }
        public DbSet<LeagueType> LeagueType { get; set; }
        public DbSet<WorkoutGpsCoord> GpsCoords { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<WorkoutGpsCoord>().Property(x => x.Latitude).HasPrecision(3, 13);
            //modelBuilder.Entity<WorkoutGpsCoord>().Property(x => x.Longtitude).HasPrecision(3, 13);
        }
    }
}
