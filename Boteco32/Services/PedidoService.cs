using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.Repository;
using Boteco32.ViewModels.ProdutoViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly PedidoRepository _pedidoRepository;
        private readonly ItemPedidoRepository _itemPedidoRepository;
        public PedidoService(PedidoRepository pedido)
        {
            _pedidoRepository = pedido;
        }

        public async Task<Pedido> Adicionar(int idCliente, CadastrarPedidoViewModel pedido)
        {
            float total = 0;
            foreach (ItemPedido item in pedido.ItensPedidos)
            {
                total += (item.ValorUnitario*item.Quantidade);
            }

            Pedido p = new Pedido()
            {
                Id = 0,
                Numero = 0,
                Data = DateTime.Now.ToString(),
                ValorTotal = (decimal)total,
                IdCliente = idCliente,
            };       

            var pedidoCadastrado = await _pedidoRepository.Adicionar(p);
            foreach (ItemPedido item in pedido.ItensPedidos)
            {
                await _itemPedidoRepository.Adicionar(item);
            }
            return pedidoCadastrado;
        }

        public Task<Pedido> Atualizar(Pedido pedido)
        {
            throw new System.NotImplementedException();
        }

        public Task<Pedido> BuscarPedidoPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Pedido>> BuscarPedidos()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Pedido pedido)
        {
            throw new System.NotImplementedException();
        }
    }
}
