using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DAL.ModelConfigurations
{
    class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            ToTable("User");
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            Property(a => a.LastName).HasMaxLength(100);
            Property(a => a.Email).IsRequired().HasMaxLength(250);
        }
    }
}
