using System;
using System.Data.Entity.Spatial;
using Core.Interfaces;

namespace Core.Models
{
    public class WorkoutGpsCoord : IEntity
    {
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Elevation { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
