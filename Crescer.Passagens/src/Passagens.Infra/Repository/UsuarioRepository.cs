using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Passagens.Dominio.Contratos;
using Passagens.Dominio.Entidades;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Passagens.Infra.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private PassagensContext contexto;

        public UsuarioRepository(PassagensContext contexto)
        {
            this.contexto = contexto;
        }
        public Usuario AtualizarUsuario(int id, Usuario usuario)
        {
            var usuarioCadastrado = contexto.Usuarios.FirstOrDefault(p => p.Id == id);
            if(usuarioCadastrado != null)usuarioCadastrado.Atualizar(usuario);
            return usuarioCadastrado;
        }

        public Usuario DeletarUsuario(int id)
        {
            var UsuarioCadastrado = contexto.Usuarios.FirstOrDefault(p => p.Id == id);
            if(UsuarioCadastrado != null) contexto.Usuarios.Remove(UsuarioCadastrado);
             
            return UsuarioCadastrado; 
        }

        public List<Usuario> ListarUsuario()
        {
            return contexto.Usuarios.AsNoTracking().ToList();
        }

        public Usuario Obter(int id)
        {
            return contexto.Usuarios.FirstOrDefault(p => p.Id == id);

        }

        public Usuario ObterUsuarioPorLoginESenha(string login, string senha)
        {
            var senhaCriptografada = CriptografarSenha(senha);

            return contexto.Usuarios.AsNoTracking()
                .FirstOrDefault(u => u.Login == login && u.Senha == senhaCriptografada);
        }

        public Usuario SalvarUsuario(Usuario usuario)
        {
            usuario.AlterarSenha(CriptografarSenha(usuario.Senha));
            contexto.Usuarios.Add(usuario);
            return usuario;
        }


         private string CriptografarSenha(string senha)
        {
            var inputBytes = Encoding.UTF8.GetBytes(senha);

            var hashedBytes = new SHA256CryptoServiceProvider().ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}