using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureApp.Infrastructure.Configurations
{
    public class CustomerContactConfiguration
        : IEntityTypeConfiguration<Domain.Entities.CustomerContact>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.CustomerContact> builder)
        {
            builder.ToTable("CustomerContacts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(20);

            builder
                .HasIndex(x => x.PhoneNo)
                .IsUnique()
                .HasDatabaseName("UX_CustomerContacts_PhoneNo");
        }
    }
}
