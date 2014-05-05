using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartCompeting.Frontend.WindowsPhone
{
    public class WorkoutViewModel
    {
        public string Name { get; set; }

        public decimal Length { get; set; }

        public int ElapsedHours { get; set; }

        public int ElapsedMinutes { get; set; }

        public int ElapsedSeconds { get; set; }

        public decimal AvgSpeed { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int RaceTypeId { get; set; }
    }
}
