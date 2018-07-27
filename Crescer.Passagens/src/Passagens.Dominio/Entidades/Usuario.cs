using System;
using System.Collections.Generic;

namespace Passagens.Dominio.Entidades
{
    public class Usuario
    {
        private Usuario() {}

        public Usuario(string nome,string ultimoNome,string email,
                        string login,string senha,string cpf, DateTime dataDeNascimento)
        {

            this.Nome = nome;
            this.UltimoNome = ultimoNome;
            this.Email = email;
            this.Login = login;
            this.Senha = senha;
            this.CPF = cpf;
            this.DataDeNascimento = dataDeNascimento;
            this.IsAdmin = false;
        }

        public int Id {get; private set;}
        public string Nome {get; private set;}
        
        public string UltimoNome {get; private set;}

        public string Email {get; private set;}
        public string Login {get; private set;}
        public string Senha {get; private set;}

        public DateTime DataDeNascimento {get; private set;}

        public string CPF {get; private set;}

        public Boolean IsAdmin {get; private set;}

       


        public void Atualizar(Usuario usuario)
        {
            Nome = usuario.Nome;
            UltimoNome = usuario.UltimoNome;
            DataDeNascimento = usuario.DataDeNascimento;
            CPF = usuario.CPF;
            Email = usuario.Email;
        }

        public void AlterarSenha(string senha)
        {
            Senha = senha;
        }
    }
}