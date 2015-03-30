using System;
using System.Data.Entity.Spatial;
using Core.Interfaces;

namespace Core.Models
{
    public class WorkoutGpsCoord : IEntity
    {
        public int Id { get; set; }

        public DbGeography Location { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
