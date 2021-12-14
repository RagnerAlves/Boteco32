using Boteco32.Models;
using Boteco32.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Interfaces
{
    public interface IItemPedidoService : IGenerics<ItemPedido>
    {       
        Task<ItemPedido> AtualizarItemPedido(ItemPedido itempedido);
        Task<List<ItemPedido>> BuscarItemPedidos();
        Task<ItemPedido> BuscarItemPedidoPorId(int id);
    }
}
