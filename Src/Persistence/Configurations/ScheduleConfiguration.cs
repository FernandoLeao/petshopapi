using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestSchedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetSchedule.Persistence.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");
            builder.HasKey(a => a.Id);

            builder.HasAlternateKey(a => new { a.VeterinaryId, a.AnimalId, a.ScheduleDate });

            builder.Property(s => s.ScheduleDate)
                    .IsRequired();

            builder.HasOne(a => a.Aninmal)
                    .WithMany(a => a.Schedules)
                    .HasForeignKey(a => a.AnimalId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Veterinary)
                .WithMany(a => a.Schedules)
                .HasForeignKey(a => a.VeterinaryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
