using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.Repository;
using Boteco32.ViewModels;
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
        private readonly ProdutoRepository _produtoRepository;

        public PedidoService(PedidoRepository pedido, ItemPedidoRepository itemPedidoRepository, ProdutoRepository produtoRepository)
        {
            _pedidoRepository = pedido;
            _itemPedidoRepository = itemPedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<Pedido> Adicionar(int idCliente, CadastrarPedidoViewModel pedido)
        {
            decimal total = 0;
            foreach (var item in pedido.ItensPedidos)
            {
                var produto = await _produtoRepository.BuscarProdutoPorId(item.IdProduto);
                total += (produto.Preco*item.Quantidade);
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
            if (pedidoCadastrado != null) { 
                foreach (var item in pedido.ItensPedidos)
                {
                    var produto = await _produtoRepository.BuscarProdutoPorId(item.IdProduto);
                    ItemPedido itemP = new ItemPedido()
                    {
                        Id = 0,
                        ValorUnitario = (float)produto.Preco,
                        IdProduto = produto.Id,
                        IdPedido = pedidoCadastrado.Id
                    };
                    await _itemPedidoRepository.Adicionar(itemP);
                }
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
