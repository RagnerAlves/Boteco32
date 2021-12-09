using System.ComponentModel.DataAnnotations;

namespace Boteco32.ViewModels.ProdutoViewModel
{
    public class CadastrarProdutoViewModel
    {
        [Required(ErrorMessage = "O código do produto é obrigatório")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O preço do produto é obrigatório")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "O saldo em estoque do produto é obrigatório")]
        public int SaldoEstoque { get; set; }
    }
}
