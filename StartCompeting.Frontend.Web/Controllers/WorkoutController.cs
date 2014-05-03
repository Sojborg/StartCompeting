using Core.Interfaces;
using Core.Models;
using StartCompeting.Frontend.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartCompeting.Frontend.Web.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IWorkoutService _workoutService;
        private readonly IRaceTypeService _raceTypeService;

        public WorkoutController(IWorkoutService workoutService, IRaceTypeService raceTypeService)
        {
            _workoutService = workoutService;
            _raceTypeService = raceTypeService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateWorkout(WorkoutViewModel workoutViewModel)
        {
            if (!ModelState.IsValid)
                return Json(false);

            var workoutEntity = new Workout();
            workoutEntity.Name = workoutViewModel.Name;
            workoutEntity.Length = workoutViewModel.Length;
            workoutEntity.AvgSpeed = workoutViewModel.AvgSpeed;
            workoutEntity.StartDateTime = workoutViewModel.StartDateTime;
            workoutEntity.EndDateTime = workoutViewModel.EndDateTime;
            workoutEntity.ElapsedHours = workoutViewModel.ElapsedHours;
            workoutEntity.ElapsedMinutes = workoutViewModel.ElapsedMinutes;
            workoutEntity.ElapsedSeconds = workoutViewModel.ElapsedSeconds;

            _workoutService.CreateWorkout(workoutEntity);

            return Json(true);
        }

        [HttpGet]
        public JsonResult GetRaceTypes()
        {
            var raceTypes = _raceTypeService.GetRaceTypes().Select(x => MapRaceType(x));
            return Json(raceTypes, JsonRequestBehavior.AllowGet);
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
