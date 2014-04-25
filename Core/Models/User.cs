using System.Collections.Generic;
namespace Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Race> Races { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }

        public User()
        {
            Races = new HashSet<Race>();
        }
    }
}
