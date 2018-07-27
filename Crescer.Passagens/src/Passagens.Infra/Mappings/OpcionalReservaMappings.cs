using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Passagens.Dominio.Entidades;

namespace Passagens.Infra.Mappings
{
    // Mapeamento de tabela N-N
    public class OpcionalReservaMappings : IEntityTypeConfiguration<OpcionalReserva>
    {

        public void Configure(EntityTypeBuilder<OpcionalReserva> builder)
        {
            builder.ToTable("OpcionalReserva");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Reserva).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Opcional).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);

        }
    }
}