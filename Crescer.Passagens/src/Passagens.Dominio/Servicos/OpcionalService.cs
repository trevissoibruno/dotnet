using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Servicos
{
    public class OpcionalService
    {
        public List<string> Validar(Opcional opcional)
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrEmpty(opcional.Nome?.Trim()))
                mensagens.Add("É necessário informar o Nome da Classe de Voo");

            if (string.IsNullOrEmpty(opcional.Descricao?.Trim()))
                mensagens.Add("É necessário informar a Descrição da Classe de Voo");

            if (opcional.Porcentagem <= default(double))
                mensagens.Add("É necessário informar a Latitude");

            return mensagens;
        }
    }
}