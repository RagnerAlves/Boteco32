using System.Collections.Generic;
using Boteco32.Models;

namespace Boteco32.Services
{
    public interface IClienteService
    {
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Delete(Cliente cliente);
        List<Cliente> BuscarClientes();

    }
}
