using Core.Interfaces;
using Core.Models;
using StartCompeting.Frontend.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace StartCompeting.Frontend.Web.Api.Controllers
{
    public class WorkoutController : ApiController
    {
        private readonly IWorkoutService _workoutService;
        private readonly IRaceTypeService _raceTypeService;

        public WorkoutController(IWorkoutService workoutService, IRaceTypeService raceTypeService)
        {
            _workoutService = workoutService;
            _raceTypeService = raceTypeService;
        }

        public HttpResponseMessage Post(WorkoutViewModel workoutViewModel)
        {
            try 
	        {

                if (ModelState.IsValid)
                {
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
    }
}
