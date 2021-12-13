using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.Repository;
using Boteco32.ViewModels;
using Boteco32.ViewModels.ProdutoViewModel;
using Boteco32.ViewModels.RetornoViewModel;
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
        private readonly IClienteService _clienteService;

        public PedidoService(PedidoRepository pedido,
            ItemPedidoRepository itemPedidoRepository, ProdutoRepository produtoRepository,
             IClienteService clienteService)
        {
            _pedidoRepository = pedido;
            _itemPedidoRepository = itemPedidoRepository;
            _produtoRepository = produtoRepository;
            _clienteService = clienteService;
        }

        public async Task<Pedido> Adicionar(int idCliente, CadastrarPedidoViewModel pedido)
        {

            var cliente = await _clienteService.BuscarPorId(idCliente);
            decimal total = 0;
            Pedido novoPedido = new Pedido();

            foreach (var item in pedido.ItensPedidos)
            {
                var produto = _produtoRepository.BuscarProdutoPorId(item.IdProduto);

                if (produto == null)
                {
                    throw new Exception("Produto invalido");
                }
                else
                {
                    if (_produtoRepository.AtualizaEstoque(produto.Id, item.Quantidade))
                    {
                        novoPedido.ItemPedidos.Add(new ItemPedido() { Quantidade = item.Quantidade, IdProduto = produto.Id, Valor = produto.Preco * item.Quantidade });
                        total += produto.Preco * item.Quantidade;
                    }
                    else
                    {
                        throw new Exception($"Saldo insuficiente - {produto.SaldoEstoque}");
                    }

                }
            }

            novoPedido.Data = DateTime.Now.ToString();
            novoPedido.ValorTotal = total;
            novoPedido.Numero = _pedidoRepository.GerarNumeroPedido() + 1;
            novoPedido.IdCliente = idCliente;

            return await _pedidoRepository.Adicionar(novoPedido);

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
