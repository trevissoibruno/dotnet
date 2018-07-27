using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Contratos
{
    public interface IClasseDeVooRepository
    {
        ClasseDeVoo SalvarClasseDeVoo(ClasseDeVoo classeDeVoo);
        
        ClasseDeVoo AtualizarClasseDeVoo(int id, ClasseDeVoo classeDeVoo);
        
        ClasseDeVoo DeletarClasseDeVoo(int id);
        
        List<ClasseDeVoo> ListarClassesDeVoo();
        
        ClasseDeVoo Obter(int id); 
    }
}