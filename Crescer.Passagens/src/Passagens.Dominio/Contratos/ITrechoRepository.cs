using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Contratos
{
    public interface ITrechoRepository
    {
        Trecho SalvarTrecho(Trecho trecho);
        
        Trecho AtualizarTrecho(int id, Trecho trecho);
        
        Trecho DeletarTrecho(int id);
        
        
        List<Trecho> ListarTrechos();
        
        Trecho Obter(int id);
    }
}