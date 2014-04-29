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
        private readonly IUserService _userService;

        public WorkoutController(IWorkoutService workoutService, IUserService userService)
        {
            _workoutService = workoutService;
            _userService = userService;
        }

        public IEnumerable<WorkoutViewModel> Get()
        {
            var workouts = _userService.GetUser(1).Workouts.Select(x => Map(x));
            return workouts;
        }

        public HttpResponseMessage Post(WorkoutViewModel workoutViewModel)
        {
            try 
	        {

                if (ModelState.IsValid)
                {
                    var user = _userService.GetUser(1);

                    var workoutEntity = new Workout();
                    workoutEntity.Name = workoutViewModel.Name;
                    workoutEntity.Length = workoutViewModel.Length;
                    workoutEntity.AvgSpeed = workoutViewModel.AvgSpeed;
                    workoutEntity.StartDateTime = workoutViewModel.StartDateTime;
                    workoutEntity.EndDateTime = workoutViewModel.EndDateTime;
                    workoutEntity.ElapsedHours = workoutViewModel.ElapsedHours;
                    workoutEntity.ElapsedMinutes = workoutViewModel.ElapsedMinutes;
                    workoutEntity.ElapsedSeconds = workoutViewModel.ElapsedSeconds;
                    workoutEntity.User = user;

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

        private WorkoutViewModel Map(Workout entity)
        {
            var viewModel = new WorkoutViewModel();
            viewModel.Name = entity.Name;
            viewModel.Length = entity.Length;
            viewModel.AvgSpeed = entity.AvgSpeed;
            viewModel.StartDateTime = entity.StartDateTime;
            viewModel.ElapsedHours = entity.ElapsedHours;
            viewModel.ElapsedMinutes = entity.ElapsedMinutes;
            viewModel.ElapsedSeconds = entity.ElapsedSeconds;
            return viewModel;
        }
    }
}
