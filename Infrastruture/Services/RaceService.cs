using Core.Interfaces;
using Core.Models;

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

        public RaceType GetRaceType(int id)
        {
            return _raceTypeRepository.GetById(id);
        }
    }
}