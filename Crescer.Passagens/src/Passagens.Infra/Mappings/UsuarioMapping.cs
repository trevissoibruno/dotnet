using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Passagens.Dominio.Entidades;

namespace Passagens.Infra.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Login).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Senha).IsRequired().HasMaxLength(128);
            builder.Property(p =>p.CPF).IsRequired().HasMaxLength(20);
            builder.Property(p => p.DataDeNascimento).IsRequired();
            builder.Property(p => p.Email).IsRequired().HasMaxLength(20);
            builder.Property(p => p.UltimoNome).IsRequired().HasMaxLength(20);
            builder.Property(p => p.IsAdmin).IsRequired();
        }
    }
}