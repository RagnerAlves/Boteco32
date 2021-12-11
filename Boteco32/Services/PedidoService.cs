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
        private readonly ClienteRepository _clienteRepository;


        public PedidoService(PedidoRepository pedido,
            ItemPedidoRepository itemPedidoRepository, ProdutoRepository produtoRepository,
             ClienteRepository clienteRepository)
        {
            _pedidoRepository = pedido;
            _itemPedidoRepository = itemPedidoRepository;
            _produtoRepository = produtoRepository;
            _clienteRepository = clienteRepository;
        }

        public async Task<Pedido> Adicionar(int idCliente, CadastrarPedidoViewModel pedido)
        {
            Cliente cliente = await _clienteRepository.BuscarPorId(idCliente);
            decimal total = 0;
            foreach (var item in pedido.ItensPedidos)
            {
                Produto produtoId = _produtoRepository.BuscarProdutoPorId(item.IdProduto);
                total += (produtoId.Preco * item.Quantidade);
            }
            Pedido novoPedido = new Pedido()
            {
                Numero = 0,
                Data = DateTime.Now.ToString(),
                ValorTotal = total,
                IdCliente = idCliente,
            };
            Pedido pedidoCadastrado = await _pedidoRepository.Adicionar(novoPedido);

            if (pedidoCadastrado != null)
            {
                foreach (var item in pedido.ItensPedidos)
                {
                    var produto = _produtoRepository.BuscarProdutoPorId(item.IdProduto);

                    ItemPedido itemP = new ItemPedido()
                    {
                        Valor = produto.Preco,
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
