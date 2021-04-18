using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class AccountConfig :  BaseConfig<Account>, IEntityTypeConfiguration<Account>
    {

        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.ToTable("Account").HasKey("AccountId");

            builder.Property(e => e.Balance).HasColumnType("decimal(19,2)");


        }
    }
}
