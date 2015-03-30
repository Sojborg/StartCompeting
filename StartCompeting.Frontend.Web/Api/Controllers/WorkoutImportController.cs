using Core.Interfaces;
using Core.Models;
using StartCompeting.Frontend.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.Dtos;

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

        public HttpResponseMessage Post(WorkoutDto workoutViewModel)
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

        private Workout MapToEntity(WorkoutDto workoutViewDto, Workout workoutEntity)
        {
            var user = _userService.GetUser(1);
            var raceType = _raceTypeService.GetRaceType(workoutViewDto.RaceTypeId);

            workoutEntity.Name = workoutViewDto.Name;
            workoutEntity.Length = workoutViewDto.Length;
            workoutEntity.AvgSpeed = workoutViewDto.AvgSpeed;
            workoutEntity.StartDateTime = workoutViewDto.StartDateTime;
            workoutEntity.EndDateTime = workoutViewDto.EndDateTime;
            workoutEntity.ElapsedHours = workoutViewDto.ElapsedHours;
            workoutEntity.ElapsedMinutes = workoutViewDto.ElapsedMinutes;
            workoutEntity.ElapsedSeconds = workoutViewDto.ElapsedSeconds;
            workoutEntity.User = user;
            workoutEntity.RaceType = raceType;

            foreach (var gpsCoord in workoutViewDto.GpsCoords)
            {
                var point = string.Format("POINT({0} {1})", gpsCoord.Latitude.ToString().Replace('.', ','), gpsCoord.Longtitude.ToString().Replace('.', ','));
                var dbgeography = DbGeography.FromText(point);
                workoutEntity.GpsCoords.Add(new WorkoutGpsCoord
                {
                    Location = dbgeography,
                    TimeStamp = gpsCoord.Timestamp
                });
            }

            return workoutEntity;
        }
    }
}
