using Geolocation;
namespace Passagens.Dominio.Entidades
{
    public class Local
    {
        private Local(){ }
        public int Id {get; private set;}
        public string Nome {get; private set;}
        public double Latitude {get; private set;}
        public double Longitude {get; private set;}
        
        public Local(string nome,double latitude, double longitude)
        {
            Nome = nome;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void Atualizar(Local local)
        {
            Latitude = local.Latitude;
            Longitude = local.Longitude;
            Nome = local.Nome;
        }
        
        
    }
}