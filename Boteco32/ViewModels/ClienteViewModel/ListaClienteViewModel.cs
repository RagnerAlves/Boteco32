namespace Boteco32.ViewModels.ClienteViewModel
{
    public class ListaClienteViewModel
    {
        public ListaClienteViewModel()
        {
        }
        public ListaClienteViewModel(string nome, string email, string endereco, string telefone)
        {
            Nome = nome;
            Email = email;
            Endereco = endereco;
            Telefone = telefone;
        }

        public string Nome { get; set; }      
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
