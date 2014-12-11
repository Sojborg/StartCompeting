using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Models;

namespace Infrastruture.Mapping
{
    public class AchievementMap : EntityTypeConfiguration<Achievement>
    {
        public AchievementMap()
        {
            ToTable("Achievement");
            HasKey(u => u.Id).Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}