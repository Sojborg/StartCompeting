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
    public class WorkoutImportController : ApiController
    {
        private readonly IWorkoutService _workoutService;
        private readonly IUserService _userService;
        private readonly IRaceTypeService _raceTypeService;

        public WorkoutImportController(IWorkoutService workoutService, IUserService userService, IRaceTypeService raceTypeService)
        {
            _workoutService = workoutService;
            _userService = userService;
            _raceTypeService = raceTypeService;
        }

        public HttpResponseMessage Post(WorkoutViewModel workoutViewModel)
        {
            try
            {
                var workoutEntity = new Workout();
                workoutEntity = MapToEntity(workoutViewModel, workoutEntity);

                _workoutService.CreateWorkout(workoutEntity);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private Workout MapToEntity(WorkoutViewModel workoutViewModel, Workout workoutEntity)
        {
            var user = _userService.GetUser(1);
            var raceType = _raceTypeService.GetRaceType(workoutViewModel.RaceTypeId);

            workoutEntity.Name = workoutViewModel.Name;
            workoutEntity.Length = workoutViewModel.Length;
            workoutEntity.AvgSpeed = workoutViewModel.AvgSpeed;
            workoutEntity.StartDateTime = workoutViewModel.StartDateTime;
            workoutEntity.EndDateTime = workoutViewModel.EndDateTime;
            workoutEntity.ElapsedHours = workoutViewModel.ElapsedHours;
            workoutEntity.ElapsedMinutes = workoutViewModel.ElapsedMinutes;
            workoutEntity.ElapsedSeconds = workoutViewModel.ElapsedSeconds;
            workoutEntity.User = user;
            workoutEntity.RaceType = raceType;

            return workoutEntity;
        }
    }
}
