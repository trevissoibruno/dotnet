using System;

namespace Passagens.Api.Models.Request
{
    public class UsuarioDto
    {
        public string Nome { get; set; }

        public string UltimoNome {get; set;}

        public string Email {get;set;}

        public string CPF {get; set;}

        public DateTime DataDeNascimento {get; set;}

        public string Login { get; set; }

        public string Senha { get; set; }
    }
}