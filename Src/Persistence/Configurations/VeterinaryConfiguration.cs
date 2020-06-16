using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestSchedule.Domain.Entities;
using System;

namespace PetSchedule.Persistence.Configurations
{
    public class VeterinaryConfiguration : IEntityTypeConfiguration<Veterinary>
    {
        public void Configure(EntityTypeBuilder<Veterinary> builder)
        {
            builder.ToTable("Veterinary");
            builder.Property(v => v.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(v => v.IsGeriatric)
                .IsRequired();

            builder.Property(v => v.ContractDate)
               .IsRequired();

        }
    }
}
