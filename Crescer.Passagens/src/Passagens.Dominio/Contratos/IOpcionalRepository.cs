using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Contratos
{
    public interface IOpcionalRepository
    {
        Opcional SalvarOpcional(Opcional opcional);
        
        Opcional AtualizarOpcional(int id, Opcional opcional);
        
        Opcional DeletarOpcional(int id);
        
        List<Opcional> ListarOpcionais();
        
        Opcional Obter(int id);
    }
}