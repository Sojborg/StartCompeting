using Core.Models;

namespace Core.Interfaces
{
    public interface IRaceService
    {
        void CreateRace(Race race);

        RaceType GetRaceType(int id);
    }
}