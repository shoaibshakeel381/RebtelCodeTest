using System.Data.Entity.ModelConfiguration;
using Rebtel.Business.DataEntities;

namespace Rebtel.Business.DAL.EntityConfigurations
{
    class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            ToTable("User");
            HasKey(a => a.Id);
            Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            Property(a => a.LastName).HasMaxLength(100);
            Property(a => a.Email).IsRequired().HasMaxLength(250);
        }
    }
}
