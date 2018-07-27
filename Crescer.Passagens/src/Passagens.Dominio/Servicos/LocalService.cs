using System.Collections.Generic;
using Passagens.Dominio.Entidades;

namespace Passagens.Dominio.Servicos
{
    public class LocalService
    {
        public List<string> Validar(Local local)
        {
            List<string> mensagens = new List<string>();

            if (string.IsNullOrEmpty(local.Nome?.Trim()))
                mensagens.Add("É necessário informar o nome do Local");
            if (local.Latitude >= -90 || local.Latitude <= 90)
                mensagens.Add("Latitude incorreta");
            if (local.Longitude >= -180 || local.Longitude <= 180)
                mensagens.Add("Longitude Incorreta");
            return mensagens;
        }
    }
}