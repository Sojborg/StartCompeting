using Core.Interfaces;

namespace Core.Models
{
    public class LeagueType : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}