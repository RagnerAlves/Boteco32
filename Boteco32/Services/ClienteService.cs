using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.Repository;

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
        public Task<Cliente> BuscarPorId(int id)
        {
            return _clienteRepository.BuscarPorId(id);
        }
        public async Task<List<Cliente>> ListarTodos(Expression<Func<Cliente, bool>> expression)
        {
            return await _clienteRepository.BuscarTodos();
        }
        public async Task<List<Cliente>> BuscarTodos()
        {
            return await _clienteRepository.BuscarTodos();
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
    }
}
