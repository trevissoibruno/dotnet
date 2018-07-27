using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Passagens.Dominio.Contratos;
using Passagens.Dominio.Entidades;

namespace Passagens.Infra.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        

        private PassagensContext contexto;

        public ReservaRepository(PassagensContext contexto)
        {
            this.contexto = contexto;
        }
        public Reserva AtualizarReserva(int id, Reserva reserva)
        {
            var reservaCadastrada = contexto.Reservas.FirstOrDefault(p => p.Id == id);
            if(reservaCadastrada != null)reservaCadastrada.Atualizar(reserva);
            return reservaCadastrada;
        }

        public Reserva DeletarReserva(int id)
        {
             var reservaCadastrada = contexto.Reservas.FirstOrDefault(p => p.Id == id);
             if(reservaCadastrada != null)contexto.Reservas.Remove(reservaCadastrada);

             return reservaCadastrada;
        }

        public List<Reserva> ListarReservas()
        {
            return contexto.Reservas.AsNoTracking().ToList();
        }

        public Reserva Obter(int id)
        {
            var reserva = contexto.Reservas.Include(x => x.Trecho.Origem)
                                   .Include(x => x.Trecho.Destino)
                                   .Include(x => x.ClasseDeVoo)
                                   .Include(x => x.Usuario)
                                   .FirstOrDefault(x => x.Id == id);

            var opcionais = contexto.OpcionalReserva.Where(p => p.Reserva.Id == id).Select(p => p.Opcional).ToList();
            reserva.AtualizarOpcionais(opcionais);
            return reserva;
        }

        public Reserva SalvarReserva(Reserva reserva)
        {
            contexto.Reservas.Add(reserva);
            foreach (Opcional item in reserva.Opcionais)
            {
                contexto.OpcionalReserva.Add(new OpcionalReserva(item,reserva));
            }
            return reserva;
        }
    }
}