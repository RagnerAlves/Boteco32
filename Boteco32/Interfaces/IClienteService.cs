using System.Collections.Generic;
using System.Threading.Tasks;
using Boteco32.Models;

namespace Boteco32.Services
{
    public interface IClienteService
    {
        Task Adicionar(Cliente cliente);
        Task<Cliente> Atualizar(Cliente cliente);
        Task Delete(Cliente cliente);
        Task<List<Cliente>> BuscarClientes();
        Task<Cliente> BuscarPorId(int id);
    }
}
