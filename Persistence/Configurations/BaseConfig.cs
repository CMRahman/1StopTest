using Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public abstract class BaseConfig<T> where T: BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CreatedOn)
                .HasPrecision(3);

            builder.Property(e => e.UpdatedOn)
                .HasPrecision(3);
        }
    }
}
