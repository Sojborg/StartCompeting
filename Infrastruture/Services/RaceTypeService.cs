using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Services
{
    public class RaceTypeService : IRaceTypeService
    {
        private readonly IRepository<RaceType> _raceTypeRepository;

        public RaceTypeService(IRepository<RaceType> raceTypeRepository)
        {
            _raceTypeRepository = raceTypeRepository;
        }

        public IList<RaceType> GetRaceTypes()
        {
            return _raceTypeRepository.GetAll().ToList();
        }
    }
}
