using System;
using System.Data.Entity;
using Core.Models;

namespace Infrastruture
{
    public interface IStartCompetingContext : IDisposable
    {
        void SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet<User> StartCompetingUsers { get; set; }
        DbSet<Race> Race { get; set; }
        DbSet<RaceType> RaceType { get; set; }
        DbSet<Workout> Workout { get; set; }
        DbSet<Achievement> Achievement { get; set; }
        DbSet<AchievementRequirement> AchievementRequirement { get; set; }
        DbSet<League> League { get; set; }
        DbSet<LeagueType> LeagueType { get; set; }
    }
}