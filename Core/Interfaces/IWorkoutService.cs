using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interfaces
{
    public interface IWorkoutService
    {
        void CreateWorkout(Workout workout);

        IEnumerable<Workout> GetAllUserWorkouts(int userId);
    }
}
