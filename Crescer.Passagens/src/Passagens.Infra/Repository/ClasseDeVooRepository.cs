using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Passagens.Dominio.Contratos;
using Passagens.Dominio.Entidades;

namespace Passagens.Infra.Repository
{
    public class ClasseDeVooRepository : IClasseDeVooRepository
    {
        private PassagensContext contexto;

        public ClasseDeVooRepository(PassagensContext contexto)
        {
            this.contexto = contexto;
        }

        public ClasseDeVoo AtualizarClasseDeVoo(int id, ClasseDeVoo classeDeVoo)
        {
            var classseDeVooCadastrado = contexto.ClassesDeVoos.FirstOrDefault(p => p.Id == id);
            if(classseDeVooCadastrado != null)classseDeVooCadastrado.Atualizar(classseDeVooCadastrado);
            return classseDeVooCadastrado;
        }

        public ClasseDeVoo DeletarClasseDeVoo(int id)
        {
             var classseDeVooCadastrado = contexto.ClassesDeVoos.FirstOrDefault(p => p.Id == id);
             if(classseDeVooCadastrado != null)contexto.ClassesDeVoos.Remove(classseDeVooCadastrado);
             return classseDeVooCadastrado;
        }

        public List<ClasseDeVoo> ListarClassesDeVoo()
        {
            return contexto.ClassesDeVoos.AsNoTracking().ToList();
        }

        public ClasseDeVoo Obter(int id)
        {
            return contexto.ClassesDeVoos.FirstOrDefault(p => p.Id == id);
        }

        public ClasseDeVoo SalvarClasseDeVoo(ClasseDeVoo classeDeVoo)
        {
            contexto.ClassesDeVoos.Add(classeDeVoo);
            return classeDeVoo;
        }
    }
}