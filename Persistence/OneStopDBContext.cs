using System;
using Domain.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence
{
    public class OneStopDbContext : DbContext
    {
        public OneStopDbContext()
        {
            
        }
        public OneStopDbContext(DbContextOptions<OneStopDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=OneStop-1;Trusted_Connection=True;");
          
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OneStopDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.Entries<BaseEntity>().ToList().ForEach(entry =>
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedOn = DateTime.Now;
                        break;

                }
            });

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
