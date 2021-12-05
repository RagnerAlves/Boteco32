using System;
using System.Collections.Generic;

namespace Boteco32.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
