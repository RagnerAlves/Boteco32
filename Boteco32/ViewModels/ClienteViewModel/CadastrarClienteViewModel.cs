using System.ComponentModel.DataAnnotations;

namespace Boteco32.ViewModels.ClienteViewModel
{
    public class CadastrarClienteViewModel
    {

        public string Nome { get; set; }
        [Required(ErrorMessage = "O endereço do produto é obrigatório")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O telefone do produto é obrigatório")]
        public string Telefone { get; set; }
    }
}
