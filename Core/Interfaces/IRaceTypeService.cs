using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRaceTypeService
    {
        IList<RaceType> GetRaceTypes();

        RaceType GetRaceType(int raceTypeId);
    }
}
