using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Infrastruture
{
    public class StartCompetingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StartCompetingContext>
    {
        protected override void Seed(StartCompetingContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    Username = "Sojborg",
                    Password = "123"
                },
                new User
                {
                    Username = "Hans",
                    Password = "123"
                }
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var sojborgUser = context.Users.SingleOrDefault(u => u.Username == "Sojborg");

            var raceTypes = new List<RaceType>
            {
                new RaceType {Name = "Running"},
                new RaceType {Name = "Cycling"}
            };

            raceTypes.ForEach(rt => context.RaceType.Add(rt));
            context.SaveChanges();

            var runningRaceType = context.RaceType.SingleOrDefault(x => x.Name == "Running");
            var cyclingRaceType = context.RaceType.SingleOrDefault(x => x.Name == "Cycling");

            var races = new List<Race>
            {
                new Race
                {
                    CreatedDate = new DateTime(2014, 12, 30),
                    Name = "Best seller halvmarathon",
                    RaceLength = new decimal(21.4),
                    RaceType = runningRaceType,
                    StartDate = new DateTime(2015, 09, 05),
                },
                new Race
                {
                    CreatedDate = new DateTime(2014, 12, 30),
                    Name = "Danmarks højeste",
                    RaceLength = new decimal(21.4),
                    RaceType = cyclingRaceType,
                    StartDate = new DateTime(2015, 04, 11),
                }
            };

            races.ForEach(r => context.Race.Add(r));
            context.SaveChanges();


            var workouts = new List<Workout>
            {
                new Workout
                {
                    AvgSpeed = 27,
                    CreatedDateTime = new DateTime(2014, 12, 30),
                    ElapsedHours = 1,
                    ElapsedMinutes = 30,
                    ElapsedSeconds = 22,
                    EndDateTime = new DateTime(2014, 12, 30),
                    Length = 44,
                    Name = "Test",
                    RaceType = cyclingRaceType,
                    User = sojborgUser,
                    StartDateTime = new DateTime(2014, 12, 30, 9, 0, 0)
                }, 
                new Workout
                {
                    AvgSpeed = 11,
                    CreatedDateTime = new DateTime(2014, 12, 30),
                    ElapsedHours = 0,
                    ElapsedMinutes = 27,
                    ElapsedSeconds = 4,
                    EndDateTime = new DateTime(2014, 12, 30),
                    Length = 5,
                    Name = "Test",
                    RaceType = runningRaceType,
                    User = sojborgUser,
                    StartDateTime = new DateTime(2014, 12, 30, 9, 0, 0)
                }
            };

            workouts.ForEach(w => context.Workout.Add(w));
            context.SaveChanges();
        }
    }
}