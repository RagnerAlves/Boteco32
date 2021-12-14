using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Services
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly ItemPedidoRepository _itemitempedidoRepository;

        public ItemPedidoService(ItemPedidoRepository itemitempedido)
        {
            _itemitempedidoRepository = itemitempedido;
        }

        public Task Adicionar(ItemPedido itempedido)
        {
            throw new System.NotImplementedException();
        }

        public Task<ItemPedido> Atualizar(ItemPedido itempedido)
        {
            throw new System.NotImplementedException();
        }

        public Task<ItemPedido> AtualizarItemPedido(ItemPedido itempedido)
        {
            throw new System.NotImplementedException();
        }

        public Task<ItemPedido> BuscarItemPedidoPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ItemPedido>> BuscarItemPedidos()
        {
            throw new System.NotImplementedException();
        }

        public Task<ItemPedido> BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ItemPedido>> BuscarTodos()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(ItemPedido itempedido)
        {
            throw new System.NotImplementedException();
        }

        public Task Excluir(ItemPedido obj)
        {
            throw new System.NotImplementedException();
        }

        Task IGenerics<ItemPedido>.Atualizar(ItemPedido obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
