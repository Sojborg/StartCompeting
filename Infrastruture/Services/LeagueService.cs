using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;

namespace Infrastruture.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly IRepository<League> _leagueRepository;
        private readonly IRepository<LeagueType> _leagueTypeRepository;

        public LeagueService(IRepository<League> leagueRepository, IRepository<LeagueType> leagueTypeRepository)
        {
            _leagueRepository = leagueRepository;
            _leagueTypeRepository = leagueTypeRepository;
        }

        public void SaveLeague(League league)
        {
            league.CreatedDate = System.DateTime.Now;
            _leagueRepository.Save(league);
        }

        public IEnumerable<League> GetLeagues()
        {
            return _leagueRepository.GetAll();
        }

        public LeagueType GetLeagueType(int id)
        {
            return _leagueTypeRepository.GetById(id);
        }

        public League GetLeague(int id)
        {
            return _leagueRepository.GetById(id);
        }

        public void DeleteLeague(int id)
        {
            var league = _leagueRepository.GetById(id);
            _leagueRepository.Delete(league);
        }
    }
}