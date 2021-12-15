using System.ComponentModel.DataAnnotations;

namespace Boteco32.ViewModels.ClienteViewModel
{
    public class LoginClienteViewModel
    {
        [Required(ErrorMessage = "O email do cliente é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O senha do cliente é obrigatório")]
        public string Senha { get; set; }
    }
}
