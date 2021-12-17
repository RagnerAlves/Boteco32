using Boteco32.Models;
using Boteco32.ViewModels.ClienteViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Boteco32.Factory
{
    public static class ClienteFactory
    {

        public static CadastrarClienteViewModel ConverterClienteParaCadastrarClienteViewModel(Cliente cliente)
        {
            return new CadastrarClienteViewModel()
            {
                Nome = cliente.Nome,
                Email = cliente.Email,
                Endereco = cliente.Endereco,
                Telefone = cliente.Telefone,
            };
        }
        public static ListaClienteViewModel ConverterClienteEmListaViewModelCliente(Cliente cliente)
        {
            var listaClienteViewModel = new ListaClienteViewModel(cliente.Id,cliente.Nome, cliente.Email, cliente.Endereco, cliente.Telefone);   
            return listaClienteViewModel;   
        }
        public static List<ListaClienteViewModel> ConverterClientesEmListViewModelClientes(List<Cliente> clientes)
        {
            var listaClienteViewModel = clientes.Select(c => ConverterClienteEmListaViewModelCliente(c)).ToList();
            return listaClienteViewModel;
        }
      
    }
}
