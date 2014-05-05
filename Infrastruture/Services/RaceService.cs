using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;

namespace Infrastruture.Services
{
    public class RaceService : IRaceService
    {
        private readonly IRepository<Race> _raceRepository;
        private readonly IRepository<RaceType> _raceTypeRepository;

        public RaceService(IRepository<Race> raceRepository, IRepository<RaceType> raceTypeRepository)
        {
            _raceRepository = raceRepository;
            _raceTypeRepository = raceTypeRepository;
        }

        public void CreateRace(Race race)
        {
            race.CreatedDate = System.DateTime.Now;
            _raceRepository.Save(race);
        }

        public IEnumerable<Race> GetRaces()
        {
            return _raceRepository.GetAll();
        }

        public RaceType GetRaceType(int id)
        {
            return _raceTypeRepository.GetById(id);
        }

        public Race GetRace(int id)
        {
            return _raceRepository.GetById(id);
        }
    }
}