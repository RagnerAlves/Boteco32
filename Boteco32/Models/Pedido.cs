using System;
using System.Collections.Generic;

namespace Boteco32.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            ItemPedidos = new HashSet<ItemPedido>();
        }

        public int Id { get; set; }
        public int Numero { get; set; }
        public string Data { get; set; }
        public decimal ValorTotal { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<ItemPedido> ItemPedidos { get; set; }
    }
}
