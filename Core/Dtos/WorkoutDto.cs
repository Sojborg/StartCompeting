using System;
using System.Collections.Generic;

namespace Core.Dtos
{
    public class WorkoutDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Length { get; set; }

        public int ElapsedHours { get; set; }

        public int ElapsedMinutes { get; set; }

        public int ElapsedSeconds { get; set; }

        public decimal AvgSpeed { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int RaceTypeId { get; set; }

        public List<GpsCoordDto> GpsCoords { get; set; }
    }

    public class GpsCoordDto
    {
        public DateTime Timestamp { get; set; }

        public double Longtitude { get; set; }

        public double Latitude { get; set; }

        public double Elevation { get; set; }
    }
}