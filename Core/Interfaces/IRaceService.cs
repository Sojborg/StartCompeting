using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRaceService
    {
        void SaveRace(Race race);

        IEnumerable<Race> GetRaces();

        RaceType GetRaceType(int id);

        Race GetRace(int id);

        void DeleteRace(int id);
    }
}