using Core.Interfaces;
using StartCompeting.Frontend.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StartCompeting.Frontend.Web.Api.Controllers
{
    public class RaceTypeController : ApiController
    {
        private readonly IRaceTypeService _raceTypeService;

        public RaceTypeController()
        {

        }

        public RaceTypeController(IRaceTypeService raceTypeService)
        {
            _raceTypeService = raceTypeService;
        }

        // GET api/<controller>
        public IEnumerable<RaceTypeViewModel> Get()
        {
            var raceTypes = _raceTypeService.GetRaceTypes().Select(x => MapRaceType(x));
            return raceTypes;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private RaceTypeViewModel MapRaceType(Core.Models.RaceType raceType)
        {
            var raceTypeViewModel = new RaceTypeViewModel();
            raceTypeViewModel.Id = raceType.Id;
            raceTypeViewModel.Name = raceType.Name;
            return raceTypeViewModel;
        }
    }
}