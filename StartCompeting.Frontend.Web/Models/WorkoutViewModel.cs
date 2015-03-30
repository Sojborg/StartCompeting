using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace StartCompeting.Frontend.Web.Models
{
    //[DataContract]
    public class WorkoutViewModel
    {
        public WorkoutViewModel()
        {
            GpsCoords = new List<GpsCoordViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        //[DataMember(IsRequired = true)}
        public decimal Length { get; set; }

        public int ElapsedHours { get; set; }

        public int ElapsedMinutes { get; set; }

        public int ElapsedSeconds { get; set; }

        //[Required]
        public decimal AvgSpeed { get; set; }

        //[Required]
        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int RaceTypeId { get; set; }

        public List<GpsCoordViewModel> GpsCoords { get; set; }
    }

    public class GpsCoordViewModel
    {
        public DateTime Timestamp { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public double? Elevation { get; set; }
    }
}
