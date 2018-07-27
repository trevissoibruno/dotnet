using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Passagens.Dominio.Contratos;
using Passagens.Dominio.Entidades;

namespace Passagens.Infra.Repository
{
    public class LocalRepository : ILocalRepository
    {
        private PassagensContext contexto;

        public LocalRepository(PassagensContext contexto)
        {
            this.contexto = contexto;
        }
        public Local AtualizarLocal(int id, Local local)
        {
            var localCasdastrado = contexto.Locais.FirstOrDefault(p => p.Id == id);
            if(localCasdastrado != null)localCasdastrado.Atualizar(local);
            
            return localCasdastrado;

        }

        public Local DeletarLocal(int id)
        {
             var localCasdastrado = contexto.Locais.FirstOrDefault(p => p.Id == id);
            if(localCasdastrado != null) contexto.Locais.Remove(localCasdastrado);   
            
            return localCasdastrado;
        }

        public List<Local> ListarLocais()
        {
            return contexto.Locais.AsNoTracking().ToList();
        }

        public Local Obter(int id)
        {
            return contexto.Locais.FirstOrDefault(p => p.Id == id);
        }

        public Local SalvarLocal(Local local)
        {
            contexto.Locais.Add(local);

            return local;
        }
    }
}