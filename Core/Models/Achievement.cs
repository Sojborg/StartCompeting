using System;
using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Models
{
    public class Achievement : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Points { get; set; }

        public List<AchievementRequirement> Requirements { get; set; }
        
        public DateTime CreatedDate { get; set; }
    }
}