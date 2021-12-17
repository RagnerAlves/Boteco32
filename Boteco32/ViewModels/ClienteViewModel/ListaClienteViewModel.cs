namespace Boteco32.ViewModels.ClienteViewModel
{
    public class ListaClienteViewModel
    {
        public ListaClienteViewModel()
        {
        }
        public ListaClienteViewModel(int id, string nome, string email, string endereco, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Endereco = endereco;
            Telefone = telefone;
        }
        public int Id { get; set; }
        public string Nome { get; set; }      
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
