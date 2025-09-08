using AccessControl.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.Server.Data.Mappings {
    public class LogMap : IEntityTypeConfiguration<Log> {
        public void Configure(EntityTypeBuilder<Log> builder) {
            
            builder.ToTable("Logs");

            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();

            builder.Property(l => l.IdUser).IsRequired();
            builder.Property(l => l.IdDevice).IsRequired();
            builder.Property(l => l.Time).IsRequired();
            builder.Property(l => l.Status).IsRequired().HasMaxLength(50);
        }
    }
}
