using System;
using System.Collections.Generic;

namespace Boteco32.Models
{
    public partial class ItemPedido
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public decimal Valor { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
    }
}
