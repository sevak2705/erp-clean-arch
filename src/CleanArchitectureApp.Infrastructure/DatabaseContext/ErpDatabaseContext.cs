using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureApp.Infrastructure.DatabaseContext
{
    public class ErpDatabaseContext : DbContext
    {
        public ErpDatabaseContext(DbContextOptions<ErpDatabaseContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErpDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Domain.Entities.CustomerContact> CustomerContacts { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (
                var entry in base
                    .ChangeTracker.Entries<CommonEntity>()
                    .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified)
            )
            {
                entry.Entity.UpdatedDate = DateTime.Now;
                entry.Entity.UpdatedDateUtc = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedDateUtc = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
