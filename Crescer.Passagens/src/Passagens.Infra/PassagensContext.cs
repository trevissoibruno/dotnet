using Microsoft.EntityFrameworkCore;
using Passagens.Dominio.Entidades;
using Passagens.Infra.Mappings;

namespace Passagens.Infra
{
    public class PassagensContext : DbContext
    {
        public PassagensContext(DbContextOptions options) : base(options) { }

        public DbSet<Reserva> Reservas {get;set;}

        public DbSet<Trecho> Trechos {get;set;}

        public DbSet<Usuario> Usuarios {get;set;}

        public DbSet<Opcional> Opcionais {get;set;}

        public DbSet<OpcionalReserva> OpcionalReserva {get;set;}

        public DbSet<Local> Locais {get;set;}

        public DbSet<ClasseDeVoo> ClassesDeVoos {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new TrechoMapping());
            modelBuilder.ApplyConfiguration(new ReservaMapping());
            modelBuilder.ApplyConfiguration(new LocalMapping());
            modelBuilder.ApplyConfiguration(new ClasseDeVooMapping());
            modelBuilder.ApplyConfiguration(new OpcionalMapping());
            modelBuilder.ApplyConfiguration(new OpcionalReservaMappings());
        }




    }
}