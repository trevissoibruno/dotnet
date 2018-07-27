using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Passagens.Dominio.Entidades;

namespace Passagens.Infra.Mappings
{
    public class ReservaMapping : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reserva");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Trecho).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne( p => p.ClasseDeVoo).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.Property(p => p.ValorTotalDoVoo).IsRequired();
            //builder.HasMany(p => p.Opcionais).WithOne(p => p.Reserva);
            builder.Ignore(p => p.Opcionais);
        }
    }
}