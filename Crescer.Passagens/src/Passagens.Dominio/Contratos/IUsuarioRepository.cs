using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Contratos
{
    public interface IUsuarioRepository
    {
        Usuario SalvarUsuario(Usuario usuario);
        Usuario AtualizarUsuario(int id, Usuario usuario);
        Usuario DeletarUsuario(int id);
        List<Usuario> ListarUsuario();
        Usuario Obter(int id);
        Usuario ObterUsuarioPorLoginESenha(string login, string senha);
    }
}