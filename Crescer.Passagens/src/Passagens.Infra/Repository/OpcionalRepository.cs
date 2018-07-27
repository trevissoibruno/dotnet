using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Passagens.Dominio.Contratos;
using Passagens.Dominio.Entidades;

namespace Passagens.Infra.Repository
{
    public class OpcionalRepository : IOpcionalRepository
    {
        private PassagensContext contexto;
        public OpcionalRepository(PassagensContext contexto)
        {
            this.contexto = contexto;
        }

        public Opcional AtualizarOpcional(int id, Opcional opcional)
        {
            var opcionalCadastrado = contexto.Opcionais.FirstOrDefault(p => p.Id == id);
            if (opcionalCadastrado != null) opcionalCadastrado.Atualizar(opcionalCadastrado);
            return opcionalCadastrado;
        }

        public Opcional DeletarOpcional(int id)
        {
            var opcionalCadastrado = contexto.Opcionais.FirstOrDefault(p => p.Id == id);
            if (opcionalCadastrado != null) contexto.Opcionais.Remove(opcionalCadastrado);
            return opcionalCadastrado;
        }

        public List<Opcional> ListarOpcionais()
        {
            return contexto.Opcionais.AsNoTracking().ToList();
        }

        public Opcional Obter(int id)
        {
            return contexto.Opcionais.FirstOrDefault(p => p.Id == id);
        }

        public Opcional SalvarOpcional(Opcional opcional)
        {
            contexto.Opcionais.Add(opcional);
            return opcional;
        }
    }
}