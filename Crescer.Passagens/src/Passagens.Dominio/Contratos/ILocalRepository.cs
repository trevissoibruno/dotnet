using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Contratos
{
    public interface ILocalRepository
    {
        Local SalvarLocal(Local local);
        
        Local AtualizarLocal(int id, Local local);
        
        Local DeletarLocal(int id);
        
        List<Local> ListarLocais();
        
        Local Obter(int id);
    }
}