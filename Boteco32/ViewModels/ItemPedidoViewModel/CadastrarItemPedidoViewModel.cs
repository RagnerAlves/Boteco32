using System.ComponentModel.DataAnnotations;

namespace Boteco32.ViewModels.ProdutoViewModel
{
    public class CadastrarItemPedidoViewModel
    {
        [Required(ErrorMessage = "O numero da quantidade é obrigatório")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O id do pedido é obrigatório")]
        public int IdPedido { get; set; }

        [Required(ErrorMessage = "A id do produto pedido é obrigatório")]
        public int IdProduto { get; set; }
    }
}

