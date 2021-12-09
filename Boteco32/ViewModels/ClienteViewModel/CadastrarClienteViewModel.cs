using System.ComponentModel.DataAnnotations;

namespace Boteco32.ViewModels.ClienteViewModel
{
    public class CadastrarClienteViewModel
    {
        [Required(ErrorMessage = "O código do produto é obrigatório")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O endereço do produto é obrigatório")]
        public string Endereco { get; set; }
    }
}
