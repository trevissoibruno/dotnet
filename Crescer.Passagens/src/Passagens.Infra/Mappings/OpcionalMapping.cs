using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Passagens.Dominio.Entidades;

namespace Passagens.Infra.Mappings
{
    public class OpcionalMapping : IEntityTypeConfiguration<Opcional>
    {
        public void Configure(EntityTypeBuilder<Opcional> builder)
        {
            builder.ToTable("Opcional"); 
            builder.HasKey( p => p.Id);
            builder.Property( p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property( p => p.Descricao).IsRequired();
            builder.Property( p => p.Porcentagem).IsRequired();
        }
    }
}