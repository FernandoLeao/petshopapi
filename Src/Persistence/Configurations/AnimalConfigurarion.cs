using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestSchedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetSchedule.Persistence.Configurations
{
    public class AnimalConfigurarion : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animal");

            builder.Property(a => a.Name)
                 .HasMaxLength(100)
                 .IsRequired();          
                
        }
    }
}
