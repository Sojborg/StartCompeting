using System.Collections.Generic;
using Core.Models;

namespace Core.Interfaces
{
    public interface IAchievementService
    {
        void SaveAchievement(Achievement achievement);

        IEnumerable<Achievement> GetAchievements();

        Achievement GetAchievement(int id);

        void DeleteAchievement(int id);
    }
}