using System;
using System.Collections.Generic;

namespace Boteco32.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ItemPedidos = new HashSet<ItemPedido>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int SaldoEstoque { get; set; }

        public virtual ICollection<ItemPedido> ItemPedidos { get; set; }
    }
}
