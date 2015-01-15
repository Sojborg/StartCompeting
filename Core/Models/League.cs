using System;
using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Models
{
    public class League : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public LeagueType LeagueType { get; set; }

        public IEnumerable<Race> Races { get; set; }

        public IEnumerable<User> Users { get; set; }
        
        public IEnumerable<Achievement> Achievements { get; set; } 

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public User CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}