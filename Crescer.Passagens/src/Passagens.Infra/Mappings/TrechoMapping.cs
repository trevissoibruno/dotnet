using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Passagens.Dominio.Entidades;

namespace Passagens.Infra.Mappings
{
    public class TrechoMapping : IEntityTypeConfiguration<Trecho>
    {
        public void Configure(EntityTypeBuilder<Trecho> builder)
        {
            builder.ToTable("Trecho");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Origem).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Destino).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}