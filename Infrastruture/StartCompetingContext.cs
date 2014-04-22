using Core.Models;
using Infrastruture.Mapping;
using System.Data.Entity;

namespace Infrastruture
{
    public class StartCompetingContext : DbContext
    {
        public StartCompetingContext() : base("name=StartCompetingContext")
        {
            Database.SetInitializer<StartCompetingContext>(new DropCreateDatabaseIfModelChanges<StartCompetingContext>());
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
    }
}
