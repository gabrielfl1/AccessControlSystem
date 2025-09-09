using AccessControl.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.Server.Data.Mappings {
    public class AccessRuleMap : IEntityTypeConfiguration<AccessRule> {
        public void Configure(EntityTypeBuilder<AccessRule> builder) {

            builder.ToTable("AccessRules");

            builder.HasKey(ar => ar.Id);
            builder.Property(ar => ar.Id).ValueGeneratedOnAdd();

            builder.Property(ar => ar.Name).IsRequired().HasMaxLength(100);

            // adicionando um valor padrão no banco
            builder.HasData(
                new AccessRule {
                    Id = 1,
                    Name = "Regra padrão"
                }
            );

            // associação
            builder
                .HasMany(x => x.Users)
                .WithMany(x => x.AccessRules)
                .UsingEntity<Dictionary<string, object>>(
                    "UserAccessRules",
                    ar => ar
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AccessRuleUser_UserId")
                        .OnDelete(DeleteBehavior.Cascade),
                    u => u
                        .HasOne<AccessRule>()
                        .WithMany()
                        .HasForeignKey("AccessRuleId")
                        .HasConstraintName("FK_AccessRuleUser_AccessRuleId")
                        .OnDelete(DeleteBehavior.Cascade));

            builder
                .HasMany(x => x.Devices)
                .WithMany(x => x.AccessRules)
                .UsingEntity<Dictionary<string, object>>(
                    "DeviceAccessRules",
                    ar => ar
                        .HasOne<Device>()
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .HasConstraintName("FK_AccessRuleDevice_DeviceId")
                        .OnDelete(DeleteBehavior.Cascade),
                    d => d
                        .HasOne<AccessRule>()
                        .WithMany()
                        .HasForeignKey("AccessRuleId")
                        .HasConstraintName("FK_AccessRuleDevice_AccessRuleId")
                        .OnDelete(DeleteBehavior.Cascade));

            builder
                .HasMany(x => x.Schedules)
                .WithMany(x => x.AccessRules)
                .UsingEntity<Dictionary<string, object>>(
                    "ScheduleAccessRules",
                    ar => ar
                        .HasOne<Schedule>()
                        .WithMany()
                        .HasForeignKey("ScheduleId")
                        .HasConstraintName("FK_AccessRuleSchedule_ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade),
                    s => s
                        .HasOne<AccessRule>()
                        .WithMany()
                        .HasForeignKey("AccessRuleId")
                        .HasConstraintName("FK_AccessRuleSchedule_AccessRuleId")
                        .OnDelete(DeleteBehavior.Cascade))
                .HasData(new { AccessRuleId = 1L, ScheduleId = 1L });

        }
    }
}
