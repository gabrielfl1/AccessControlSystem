using AccessControl.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccessControl.Server.Data.Mappings {
    public class UserMap : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {
            
            //Criando a tabela 
            builder.ToTable("Users");

            // Chave Primaria
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            // propriedades
            builder.Property(u => u.Name).IsRequired().HasMaxLength(100);

            builder.Property(u => u.DateStartLimit).IsRequired(false);

            builder.Property(u => u.DateEndLimit).IsRequired(false);

            builder.Property(u => u.DataLastLog).IsRequired(false);

            builder.Property(u => u.Pin).IsRequired(false);

            builder.Property(u => u.Card).IsRequired(false);

        }
    }
}
