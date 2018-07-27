using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Servicos
{
    public class ClasseDeVooService
    {
       public List<string> Validar(ClasseDeVoo classeDeVoo)
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrEmpty(classeDeVoo.Descricao?.Trim()))
                mensagens.Add("É necessário informar o nome do Local");

            if (classeDeVoo.ValorFixo < 0)
                mensagens.Add("É necessário informar O Valor Fixo do Voo");

            if (classeDeVoo.ValorPorMilha < 0 )
                mensagens.Add("É necessário informar O Valor por Milhas");

            return mensagens;
        }
    }
}