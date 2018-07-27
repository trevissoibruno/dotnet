namespace Passagens.Dominio.Entidades
{
    public class OpcionalReserva
    {
        public OpcionalReserva(){ }

        public OpcionalReserva(Opcional opcional,Reserva Reserva)
        {
            this.Opcional = opcional;
            this.Reserva = Reserva;
            
        }
        public int Id {get; private set;}

        public Opcional Opcional {get; private set;}

        public Reserva Reserva {get; private set;}
    }
}