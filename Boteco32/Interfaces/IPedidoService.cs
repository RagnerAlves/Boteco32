using Boteco32.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Interfaces
{
    public interface IPedidoService
    {
        Task Adicionar(Pedido pedido);
        Task<Pedido> Atualizar(Pedido pedido);
        void Delete(Pedido pedido);
        Task<List<Pedido>> BuscarPedidos();
        Task<Pedido> BuscarPedidoPorId(int id);
    }
}
