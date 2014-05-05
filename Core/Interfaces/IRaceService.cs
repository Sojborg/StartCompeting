using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRaceService
    {
        void CreateRace(Race race);

        IEnumerable<Race> GetRaces();

        RaceType GetRaceType(int id);

        Race GetRace(int id);
    }
}