using Core.Models;
using Infrastruture.Mapping;
using System.Data.Entity;

namespace Infrastruture
{
    public class StartCompetingContext : DbContext
    {
        public StartCompetingContext() : base("name=StartCompetingContext")
        {
            Database.SetInitializer(new StartCompetingInitializer());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new UserMap());
        //    modelBuilder.Configurations.Add(new RaceMap());
        //    //modelBuilder.Configurations.Add(new UserRaceMap());

        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<RaceType> RaceType { get; set; }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<Achievement> Achievement { get; set; }
        public DbSet<AchievementRequirement> AchievementRequirement { get; set; }
        public DbSet<League> League { get; set; }
        public DbSet<LeagueType> LeagueType { get; set; }
    }
}
