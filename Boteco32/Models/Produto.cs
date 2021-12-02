namespace Boteco32.Models
{
    public class Produto
    {
        public long ID { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int SaldoEstoque { get; set; }

    }
}
