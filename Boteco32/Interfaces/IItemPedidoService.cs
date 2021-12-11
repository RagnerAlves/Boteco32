using Boteco32.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Interfaces
{
    public interface IItemPedidoService
    {
        Task Adicionar(ItemPedido itempedido);
        Task<ItemPedido> Atualizar(ItemPedido itempedido);
        void Delete(ItemPedido itempedido);
        Task<List<ItemPedido>> BuscarItemPedidos();
        Task<ItemPedido> BuscarItemPedidoPorId(int id);
    }
}
