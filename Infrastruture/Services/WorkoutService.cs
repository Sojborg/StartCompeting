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
            _workoutRepository.Save(workout);
        }
    }
}
