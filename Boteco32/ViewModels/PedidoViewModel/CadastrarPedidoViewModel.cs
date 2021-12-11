using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Boteco32.ViewModels.ProdutoViewModel
{
    public class CadastrarPedidoViewModel
    {
        [Required(ErrorMessage = "É obrigatório ter pelo menos um item no pedido")]
        public List<ItemPedidoViewModel> ItensPedidos { get; set; }
    }
}