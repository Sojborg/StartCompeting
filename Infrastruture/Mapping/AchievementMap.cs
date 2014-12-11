using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Models;

namespace Infrastruture.Mapping
{
    public class AchievementRequirementMap : EntityTypeConfiguration<AchievementRequirement>
    {
        public AchievementRequirementMap()
        {
            ToTable("AchievementRequirement");
            HasKey(u => u.Id).Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}