using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PestSchedule.Domain.Entities;
using System;

namespace PetSchedule.Persistence.Configurations
{
    public class AttendanceConfigurarion : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("Attendance");
            builder.HasKey(a => a.Id);

            builder.HasAlternateKey(a => new { a.VeterinaryId, a.AnimalId, a.AttendanceDate });

            builder.Property(a => a.Diagnostic)
                .HasMaxLength(2000)
                .IsRequired();

            builder.HasOne(a => a.Aninmal)
                    .WithMany(a => a.Attendances)
                    .HasForeignKey(a => a.AnimalId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Veterinary)
                .WithMany(a => a.Attendances)
                .HasForeignKey(a => a.VeterinaryId)
                .OnDelete(DeleteBehavior.NoAction);
                      
        }
    }
}
