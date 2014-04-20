using Core.Interfaces;

namespace Core.Models
{
    public class RaceType : IEntity
    {
        public int Id { get; private set; }

        public string Name { get; set; }
    }
}