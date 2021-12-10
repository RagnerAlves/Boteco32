using System.ComponentModel.DataAnnotations;

namespace Boteco32.ViewModels.ProdutoViewModel
{
    public class CadastrarPedidoViewModel
    {
        [Required(ErrorMessage = "O numero do pedido é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "A data do pedido é obrigatório")]
        public string Data { get; set; }

        [Required(ErrorMessage = "O valor total é obrigatório")]
        public decimal ValorTotal { get; set; }

        [Required(ErrorMessage = "O id do cliente é obrigatório")]
        public int IdCliente { get; set; }
    }
}