using System.Collections.Generic;
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

        public void Adicionar(Cliente cliente)
        {
            _clienteRepository.Adicionar(cliente);
        }
        public void Atualizar(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);
        }

        public void Delete(Cliente cliente)
        {
            _clienteRepository.Delete(cliente);
        }
        public List<Cliente> BuscarClientes()
        {
            return _clienteRepository.BuscarClientes();
        }

       
    }
}
