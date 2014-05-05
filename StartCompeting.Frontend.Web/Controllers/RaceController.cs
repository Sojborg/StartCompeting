using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Models;
using Infrastruture.Services;
using StartCompeting.Frontend.Web.Models;
using RaceType = Core.Models.RaceType;

namespace StartCompeting.Frontend.Web.Controllers
{
    public class RaceController : Controller
    {
        private readonly RaceService _raceService;

        public RaceController(RaceService raceService)
        {
            _raceService = raceService;
        }

        //
        // GET: /Race/

        public ActionResult Index()
        {
            return View();
        }
    }
}
