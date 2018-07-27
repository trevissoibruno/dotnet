using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Contratos
{
    public interface IReservaRepository
    {
        Reserva SalvarReserva(Reserva reserva);
        
        Reserva AtualizarReserva(int id, Reserva reserva);
        
        Reserva DeletarReserva(int id);
        
        
        List<Reserva> ListarReservas();
        
        Reserva Obter(int id);
    }
}