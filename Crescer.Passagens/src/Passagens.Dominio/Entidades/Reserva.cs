using System.Collections.Generic;
using System.Linq;

namespace Passagens.Dominio.Entidades
{
    public class Reserva
    {
        private Reserva() {}

        public Reserva(Trecho trecho,ClasseDeVoo classeDeVoo, List<Opcional> opcionais, Usuario usuario)
        {
            this.Trecho = trecho;
            this.ClasseDeVoo = classeDeVoo;
            this.Opcionais = opcionais;
            this.Usuario = usuario;
        }

        public int Id {get; private set;}

        public double ValorTotalDoVoo {get; set;}

        public Trecho Trecho {get; private set;}

        public ClasseDeVoo ClasseDeVoo {get; private set;}

        public List<Opcional> Opcionais {get; private set;}

        public Usuario Usuario {get; private set;}

        public double ValorBase()
        {
           return ClasseDeVoo.ValorFixo + (Trecho.DistanciaTotal *  ClasseDeVoo.ValorPorMilha);    
        }

        public double ValorDosOpcionais()
        {
            double total = 0;
            foreach (Opcional item in Opcionais)
            {
                total += item.Porcentagem;
            }
            
            return total * ValorBase();
        }
        public double ValorTotal()
        {
           return ValorBase() + ValorDosOpcionais();
        }

        public void Atualizar(Reserva reserva)
        {
            Trecho = reserva.Trecho;
            ClasseDeVoo = reserva.ClasseDeVoo;
            Opcionais = reserva.Opcionais;
        }

        public void AtualizarOpcionais(List<Opcional> opcionais)
        {
            Opcionais = opcionais;
        }






        
    }
}