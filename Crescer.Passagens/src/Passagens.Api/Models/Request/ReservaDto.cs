using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Api.Models.Request
{
    public class ReservaDto
    {
        public int IdTrecho {get;set;}

        public int IdClasseDeVoo {get;set;}

        public List<int> IdOpcionais {get;set;}

        public int IdUsuario {get;set;}

    }
}