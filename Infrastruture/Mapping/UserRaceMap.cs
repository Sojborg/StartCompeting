using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Models;

namespace Infrastruture.Mapping
{
    public class UserRaceMap : EntityTypeConfiguration<UserRace>
    {
        public UserRaceMap()
        {
            ToTable("UserRace");
            HasKey(u => u.UserRaceId).Property(u => u.UserRaceId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(x => x.User);
            HasRequired(x => x.Race);
        }
    }
}