using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class UserConfig : BaseConfig<User>, IEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("User").HasKey("UserId");

            builder.Property(e => e.UserName).HasMaxLength(10);

            builder.Property(e => e.FirstName).HasMaxLength(50);

            builder.Property(e => e.LastName).HasMaxLength(50);

        }
    }
}
