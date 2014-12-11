using Core.Interfaces;
using Core.Models;
using System.Collections.Generic;

namespace Infrastruture.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IRepository<Achievement> _achievementRepository;

        public AchievementService(IRepository<Achievement> achievementRepository)
        {
            _achievementRepository = achievementRepository;
        }

        public void SaveAchievement(Achievement achievement)
        {
            achievement.CreatedDate = System.DateTime.Now;
            _achievementRepository.Save(achievement);
        }

        public IEnumerable<Achievement> GetAchievements()
        {
            return _achievementRepository.GetAll();
        }

        public Achievement GetAchievement(int id)
        {
            return _achievementRepository.GetById(id);
        }

        public void DeleteAchievement(int id)
        {
            var race = _achievementRepository.GetById(id);
            _achievementRepository.Delete(race);
        }
    }
}