using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infrastruture.Mapping
{
    public class UserMap : EntityTypeConfiguration<User> 
    {
        public UserMap ()
	    {
            ToTable("User");
            HasKey(u => u.Id).Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Username).IsRequired().HasMaxLength(10);
	    }
    }
}
