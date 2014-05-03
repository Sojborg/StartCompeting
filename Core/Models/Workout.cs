using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Workout : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Length { get; set; }

        public decimal AvgSpeed { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int ElapsedHours { get; set; }

        public int ElapsedMinutes { get; set; }

        public int ElapsedSeconds { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public virtual RaceType RaceType { get; set; }

        public virtual User User { get; set; }

        public virtual Race Race { get; set; }
    }
}
