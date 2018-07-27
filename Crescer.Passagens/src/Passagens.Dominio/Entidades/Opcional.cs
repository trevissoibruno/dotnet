namespace Passagens.Dominio.Entidades
{
    public class Opcional
    {
        private Opcional() {}

        public Opcional(string nome,string descricao, double porcentagem)
        {
            Nome = nome;
            Descricao = descricao;
            Porcentagem = porcentagem;
        }
        public int Id {get; private set;}

        public string Nome {get; private set;}
        public string Descricao {get; private set;}
        public double Porcentagem {get; private set;}

        public void Atualizar(Opcional opcional)
        {
            Nome = opcional.Nome;
            Descricao = opcional.Descricao;
            Porcentagem = opcional.Porcentagem;

        }

    }
}