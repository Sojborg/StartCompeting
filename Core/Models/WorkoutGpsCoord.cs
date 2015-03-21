using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class WorkoutGpsCoord
    {
        public decimal Longtitude { get; set; }

        public decimal Latitude { get; set; }

        public decimal Elevation { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
