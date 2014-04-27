using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;

namespace Infrastruture.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IRepository<Workout> _workoutRepository; 

        public WorkoutService(IRepository<Workout> workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public void CreateWorkout(Core.Models.Workout workout)
        {
            workout.CreatedDateTime = DateTime.Now;
            workout.EndDateTime = GetEndDateTime(workout);

            _workoutRepository.Save(workout);
        }

        private DateTime GetEndDateTime(Workout workout)
        {
            var endDateTime = workout.StartDateTime
                .AddHours(workout.ElapsedHours)
                .AddMinutes(workout.ElapsedMinutes)
                .AddSeconds(workout.ElapsedSeconds);
            return endDateTime;
        }
    }
}
