using System.Collections.Generic;
using System.Threading.Tasks;
using Boteco32.Models;

namespace Boteco32.Services
{
    public interface IClienteService
    {
        Task Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Delete(Cliente cliente);
        Task<List<Cliente>> BuscarClientes();

    }
}
