using System.ComponentModel.DataAnnotations;

namespace Boteco32.ViewModels
{
    public class ItemPedidoViewModel
    {
        [Required(ErrorMessage = "Quantidade é obrigatório")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Produto é obrigatório")]
        public int IdProduto { get; set; }

    }
}
