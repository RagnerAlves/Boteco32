using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Boteco32.Factory;
using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.Repository;
using Boteco32.ViewModels.ClienteViewModel;


namespace Boteco32.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task Adicionar(Cliente cliente)
        {
            await _clienteRepository.Adicionar(cliente);
        }
        public async Task Atualizar(Cliente cliente)
        {
            await _clienteRepository.Atualizar(cliente);
        }
        public async Task Excluir(Cliente cliente)
        {
            await _clienteRepository.Delete(cliente);
        }
        public async Task<ListaClienteViewModel> BuscaClientePorId(int id)
        {
           var resultado = await _clienteRepository.BuscarPorId(id);
            var listaClienteViewModel = ClienteFactory.ConverterClienteEmListaViewModelCliente(resultado);
            return listaClienteViewModel;
        }
        public async Task<List<ListaClienteViewModel>> ListarTodos()
        {
            var resultado = await _clienteRepository.BuscarTodos();
            var listaClienteViewModel = ClienteFactory.ConverterClientesEmListViewModelClientes(resultado);  
            return listaClienteViewModel;
        }
        public Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Task<int> RetornaIdUsuario(string email)
        {
            throw new NotImplementedException();
        }

        Task<List<Cliente>> IGenerics<Cliente>.BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente>BuscarPorId(int id)
        {
            return await _clienteRepository.BuscarPorId(id);
        }
    }
}
