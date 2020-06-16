using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestSchedule.Domain.Entities;
using System;

namespace PetSchedule.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Cpf)
                    .IsRequired()
                    .HasMaxLength(11);

            builder.HasIndex(c => c.Cpf)
                   .IsUnique();

            builder.HasMany(c => c.Animals)
                   .WithOne(a => a.Customer);

        }
    }
}
