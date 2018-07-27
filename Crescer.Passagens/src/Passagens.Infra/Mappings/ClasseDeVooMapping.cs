using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Passagens.Dominio.Entidades;

namespace Passagens.Infra.Mappings
{
    public class ClasseDeVooMapping : IEntityTypeConfiguration<ClasseDeVoo>
    {
        public void Configure(EntityTypeBuilder<ClasseDeVoo> builder)
        {
            builder.ToTable("ClasseDeVoo");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ValorFixo).IsRequired();
            builder.Property(p => p.ValorPorMilha).IsRequired();
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(100);
        }
    }
}