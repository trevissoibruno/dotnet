
using Geolocation;

namespace Passagens.Dominio.Entidades
{
    public class Trecho
    {
        private Trecho(){}

        public int Id {get; private set;}

        public double DistanciaTotal {get;private set;}

        public Local Origem{get;private set;}
        public Local Destino{get; private set;}

        public Trecho (Local origem, Local destino, double distanciaTotal)
        {
            this.Origem = origem;
            this.Destino = destino;
            this.DistanciaTotal = distanciaTotal;
           
        }

        public double CalcularDistancia()
        {
            int casasDecimais = 1;
            return GeoCalculator.GetDistance(Origem.Latitude, Origem.Longitude, 
            Destino.Latitude, Destino.Longitude, casasDecimais, DistanceUnit.Miles);
        }

        

        public void Atualizar(Trecho trecho)
        {
            Origem = trecho.Origem;
            Destino = trecho.Destino;
            DistanciaTotal = trecho.DistanciaTotal;
        }
    }
}