using System;
using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Servicos
{
    public class UsuarioService
    {
        public List<string> Validar(Usuario usuario)
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrEmpty(usuario.Nome?.Trim()))
                mensagens.Add("É necessário informar o nome do usuário.");
            if (string.IsNullOrEmpty(usuario.UltimoNome?.Trim()))
                mensagens.Add("É necessário informar Ultimo Nome.");    
            if (string.IsNullOrEmpty(usuario.Login?.Trim()))
                mensagens.Add("É necessário informar o Login.");
            if (string.IsNullOrEmpty(usuario.Senha?.Trim()))
                mensagens.Add("É necessário informar a Senha.");
            if (DateTime.Compare(DateTime.Today, usuario.DataDeNascimento) > 0)
                mensagens.Add("Data de nascimento Informada é invalida");
            if (string.IsNullOrEmpty(usuario.CPF?.Trim()))
                mensagens.Add("É necessário informar O CPF.");
            if (string.IsNullOrEmpty(usuario.Email?.Trim()))
                mensagens.Add("É necessário informar o Email.");
            return mensagens;
        }
    }
}