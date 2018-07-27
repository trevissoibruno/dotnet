using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Passagens.Dominio.Contratos;
using Passagens.Dominio.Entidades;

namespace Passagens.Infra.Repository
{
    public class TrechoRepository : ITrechoRepository
    {
        private PassagensContext contexto;

        public TrechoRepository(PassagensContext contexto)
        {
            this.contexto = contexto;
        }
        public Trecho AtualizarTrecho(int id, Trecho trecho)
        {
            var trechoCadastrado = contexto.Trechos.FirstOrDefault(p => p.Id == id);
            if(trechoCadastrado != null) trechoCadastrado.Atualizar(trechoCadastrado);
            return trechoCadastrado;
        }

        public Trecho DeletarTrecho(int id)
        {
            var trechoCadastrado = contexto.Trechos.FirstOrDefault(p => p.Id == id);
            if(trechoCadastrado != null)contexto.Trechos.Remove(trechoCadastrado);
            
            return trechoCadastrado;
        }

        public List<Trecho> ListarTrechos()
        {
            return contexto.Trechos.Include(x => x.Origem)
                                   .Include(x => x.Destino).AsNoTracking().ToList();
        }

        public Trecho Obter(int id)
        {
            return contexto.Trechos.Include(x => x.Origem)
                                   .Include(x => x.Destino)
                                   .FirstOrDefault(x => x.Id == id);
        }

        public Trecho SalvarTrecho(Trecho trecho)
        {
            contexto.Trechos.Add(trecho);
            return trecho;
        }
    }
}