namespace Core.Models
{
    public class AchievementRequirement
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal WorkoutLength { get; set; }

        public RaceType RaceType { get; set; }
    }
}