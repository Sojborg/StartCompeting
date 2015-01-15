using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ILeagueService
    {
        void SaveLeague(League league);

        IEnumerable<League> GetLeagues();

        League GetLeague(int id);

        void DeleteLeague(int id);
    }
}