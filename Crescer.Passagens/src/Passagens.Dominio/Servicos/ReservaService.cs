using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Servicos
{
    public class ReservaService
    {
        public List<string> Validar(Reserva reserva)
        {
            List<string> mensagens = new List<string>();

            if (reserva.Trecho == null)
                mensagens.Add("É necessário informar o Trecho");

            if (reserva.ClasseDeVoo == null)
                mensagens.Add("É necessário informar a Classe de Voo");

            if (reserva.Opcionais == null)
                mensagens.Add("É necessário informar os Opcionais");       
            return mensagens;
        }
    }
}