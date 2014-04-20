using System;

namespace Core.Models
{
    public class UserRace
    {
        public int UserRaceId { get; set; }

        public User User { get; set; }

        public Race Race { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}