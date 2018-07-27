using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Servicos
{
    public class TrechoService
    {
        public List<string> Validar(Trecho trecho)
        {
            List<string> mensagens = new List<string>();

            if (trecho.Origem == null)
                mensagens.Add("É necessário informar a Origem");

            if (trecho.Destino == null)
                mensagens.Add("É necessário informar o Destino"); 
                
            return mensagens;
        }
    }
}