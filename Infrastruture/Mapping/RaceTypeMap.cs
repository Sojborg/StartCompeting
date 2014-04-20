using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Models;

namespace Infrastruture.Mapping
{
    public class RaceTypeMap : EntityTypeConfiguration<RaceType>
    {
        public RaceTypeMap()
        {
            ToTable("RaceType");
            HasKey(u => u.Id).Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}