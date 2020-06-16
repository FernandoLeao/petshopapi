using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestSchedule.Domain.Entities;
using System;

namespace PetSchedule.Persistence.Configurations
{
    public class AnimalTypeConfigurarion : IEntityTypeConfiguration<AnimalType>
    {
        public void Configure(EntityTypeBuilder<AnimalType> builder)
        {
            builder.ToTable("AnimalType");
            builder.Property(at => at.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(at => at.AgeConsideredOld)
                   .IsRequired();

            builder.HasMany(at => at.Animals)
                   .WithOne(a => a.AnimalType);
                
        }
    }
}
