using AccessControl.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.Server.Data.Mappings {
    public class ScheduleMap : IEntityTypeConfiguration<Schedule> {
        public void Configure(EntityTypeBuilder<Schedule> builder) {
            
            builder.ToTable("Schedules");  

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.MondayStart).IsRequired();
            builder.Property(s => s.MondayEnd).IsRequired();
            builder.Property(s => s.TuesdayStart).IsRequired();
            builder.Property(s => s.TuesdayEnd).IsRequired();
            builder.Property(s => s.WednesdayStart).IsRequired();
            builder.Property(s => s.WednesdayEnd).IsRequired();
            builder.Property(s => s.ThursdayStart).IsRequired();
            builder.Property(s => s.ThursdayEnd).IsRequired();
            builder.Property(s => s.FridayStart).IsRequired();
            builder.Property(s => s.FridayEnd).IsRequired();
            builder.Property(s => s.SaturdayStart).IsRequired();
            builder.Property(s => s.SaturdayEnd).IsRequired();
            builder.Property(s => s.SundayStart).IsRequired();
            builder.Property(s => s.SundayEnd).IsRequired();

        }
    }
}
