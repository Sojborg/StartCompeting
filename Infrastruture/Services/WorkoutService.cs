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

        public void UpdateWorkout(Workout workout)
        {
            workout.EndDateTime = GetEndDateTime(workout);

            _workoutRepository.Save(workout);
        }

        public Workout GetWorkout(int workoutId)
        {
            return _workoutRepository.GetById(workoutId);
        }

        public IEnumerable<Workout> GetAllUserWorkouts(int userId)
        {
            var all = _workoutRepository.GetAll().ToList();
            return all.Where(x => x.User.Id == userId);
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
