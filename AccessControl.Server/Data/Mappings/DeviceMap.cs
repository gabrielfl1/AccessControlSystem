using AccessControl.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.Server.Data.Mappings {
    public class DeviceMap : IEntityTypeConfiguration<Device> {
        public void Configure(EntityTypeBuilder<Device> builder) {
            
            builder.ToTable("Devices");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).ValueGeneratedOnAdd();

            builder.Property(d => d.Ip).IsRequired().HasMaxLength(15);
            builder.Property(d => d.Login).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Password).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Serial).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Status).IsRequired();
        }
    }
}
