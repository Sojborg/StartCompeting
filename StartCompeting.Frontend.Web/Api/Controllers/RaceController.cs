using System.Web.UI.WebControls;
using Core.Interfaces;
using Core.Models;
using StartCompeting.Frontend.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StartCompeting.Frontend.Web.Api.Controllers
{
    public class RaceController : ApiController
    {
        private readonly IRaceService _raceService;
        private readonly IRaceTypeService _raceTypeService;

        public RaceController(IRaceService raceService, IRaceTypeService raceTypeService)
        {
            _raceService = raceService;
            _raceTypeService = raceTypeService;
        }

        // GET api/<controller>
        public IEnumerable<RaceViewModel> Get()
        {
            var races = _raceService.GetRaces().Select(Map);
            return races;
        }

        // GET api/<controller>/5
        public RaceViewModel Get(int id)
        {
            var race = Map(_raceService.GetRace(id));
            return race;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(RaceViewModel viewModel)
        {
            try {
                if (ModelState.IsValid)
                {
                    var raceType = _raceTypeService.GetRaceType(viewModel.RaceTypeId);

                    var race = new Race();
                    race.Name = viewModel.Name;
                    race.RaceLength = viewModel.RaceLength;
                    race.RaceType = raceType;
                    _raceService.SaveRace(race);            

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Invalid Model");
                }
	        }
	        catch (Exception ex)
	        {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
	        }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(RaceViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var race = _raceService.GetRace(viewModel.Id);
                    var raceType = _raceTypeService.GetRaceType(viewModel.RaceTypeId);

                    race.Name = viewModel.Name;
                    race.RaceLength = viewModel.RaceLength;
                    race.RaceType = raceType;
                    _raceService.SaveRace(race);

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Invalid Model");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }

        private RaceViewModel Map(Race race)
        {
            var viewModel = new RaceViewModel();
            viewModel.Id = race.Id;
            viewModel.Name = race.Name;
            viewModel.RaceLength = race.RaceLength;
            viewModel.RaceTypeId = race.RaceType.Id;
            return viewModel;
        }
    }
}