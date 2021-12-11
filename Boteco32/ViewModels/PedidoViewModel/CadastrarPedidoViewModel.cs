using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Boteco32.Models;

namespace Boteco32.ViewModels.ProdutoViewModel
{
    public class CadastrarPedidoViewModel
    {
        [Required(ErrorMessage = "É obrigatório ter pelo menos um item no pedido")]
        public List<ItemPedido> ItensPedidos { get; set; }
    }
}