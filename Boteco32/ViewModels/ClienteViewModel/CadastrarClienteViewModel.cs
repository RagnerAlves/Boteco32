using System.ComponentModel.DataAnnotations;

namespace Boteco32.ViewModels.ClienteViewModel
{
    public class CadastrarClienteViewModel
    {  
        public string Nome { get; set; }
        [Required(ErrorMessage = "O nome do cliente é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O email do cliente é obrigatório")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "A semha do cliente é obrigatório")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O endereço do cliente é obrigatório")]
        public string Telefone { get; set; }
    }
}
