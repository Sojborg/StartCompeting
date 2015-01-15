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
    public class LeagueController : ApiController
    {
        private readonly ILeagueService _leagueService;
        private readonly ILeagueTypeService _leagueTypeService;

        public LeagueController(ILeagueService leagueService, ILeagueTypeService leagueTypeService)
        {
            _leagueService = leagueService;
            _leagueTypeService = leagueTypeService;
        }

        // GET api/<controller>
        public IEnumerable<LeagueViewModel> Get()
        {
            var leagues = _leagueService.GetLeagues().Select(x => Map(x));
            return leagues;
        }

        // GET api/<controller>/5
        public LeagueViewModel Get(int id)
        {
            var league = Map(_leagueService.GetLeague(id));
            return league;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(LeagueViewModel viewModel)
        {
            try {
                if (ModelState.IsValid)
                {
                    var leagueType = _leagueTypeService.GetLeagueType(viewModel.LeagueTypeId);

                    var league = new League();
                    league.Name = viewModel.Name;
                    league.LeagueType = leagueType;
                    _leagueService.SaveLeague(league);            

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
        public HttpResponseMessage Put(LeagueViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var league = _leagueService.GetLeague(viewModel.Id);
                    var leagueType = _leagueTypeService.GetLeagueType(viewModel.LeagueTypeId);

                    league.Name = viewModel.Name;
                    league.LeagueType = leagueType;
                    _leagueService.SaveLeague(league);

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

        private LeagueViewModel Map(League league)
        {
            var viewModel = new LeagueViewModel();
            viewModel.Id = league.Id;
            viewModel.Name = league.Name;
            viewModel.StartDate = league.StartDate;
            viewModel.EndDate = league.EndDate;
            viewModel.Users = league.Users.Select(MapUsers);
            viewModel.LeagueTypeId = league.LeagueType.Id;
            return viewModel;
        }

        private UserViewModel MapUsers(User user)
        {
            var viewModel = new UserViewModel();
            viewModel.Username = user.Username;
            return viewModel;
        }
    }
}