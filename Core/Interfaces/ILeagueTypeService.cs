using Core.Models;

namespace Core.Interfaces
{
    public interface ILeagueTypeService
    {
        LeagueType GetLeagueType(int leagueTypeId);
    }
}