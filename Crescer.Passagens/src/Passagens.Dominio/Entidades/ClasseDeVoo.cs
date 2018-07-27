namespace Passagens.Dominio.Entidades
{
    public class ClasseDeVoo
    {
        private ClasseDeVoo() { } 


        public int Id {get; private set;}
        public string Descricao {get; private set;}

        public double ValorFixo  {get; private set;}

        public double ValorPorMilha {get; private set;}

        public ClasseDeVoo(string descricao,double valorFixo,double valorPorMilha)
        {
            Descricao = descricao;
            ValorFixo = valorFixo;
            ValorPorMilha = valorPorMilha;
        }

        public void Atualizar(ClasseDeVoo classeDeVoo)
        {
            Descricao = classeDeVoo.Descricao;
            ValorFixo = classeDeVoo.ValorFixo;
            ValorPorMilha = classeDeVoo.ValorPorMilha;
        }
    }
}