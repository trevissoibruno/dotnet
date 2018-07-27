using System;
using Passagens.Dominio.Entidades;

namespace Passagens.Api.Models.Response
{
    public class UsuarioResponseDto
    {
        public int Id {get;  set;}
        public string Nome {get;  set;}
        
        public string UltimoNome {get; set;}
        public string Login {get;  set;}
        
        public string Email {get; set;}
        public DateTime DataDeNascimento {get; set;}

        public string CPF {get;  set;}

        public UsuarioResponseDto(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            UltimoNome = usuario.Nome;
            Login = usuario.Login;
            Email = usuario.Email;
            DataDeNascimento = usuario.DataDeNascimento;

        }
    }
}