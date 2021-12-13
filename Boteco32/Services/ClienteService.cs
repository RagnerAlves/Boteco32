using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            return await _clienteRepository.Atualizar(cliente);
        }

        public async Task Delete(Cliente cliente)
        {
           await _clienteRepository.Delete(cliente);
        }
        public async Task<List<Cliente>> BuscarClientes()
        {
            return await _clienteRepository.BuscarClientes();
        }
        public async Task<Cliente> BuscarPorId(int id)
        {
            return await _clienteRepository.BuscarPorId(id);
        }


    }
}
