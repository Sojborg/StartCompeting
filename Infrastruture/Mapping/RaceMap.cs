using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Models;

namespace Infrastruture.Mapping
{
    public class RaceMap : EntityTypeConfiguration<Race>
    {
        public RaceMap()
        {
            ToTable("Race");
            HasKey(u => u.Id).Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}