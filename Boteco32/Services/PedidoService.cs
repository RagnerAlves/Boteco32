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
        private readonly ProdutoRepository _produtoRepository;
        private readonly IClienteService _clienteService;

        public PedidoService(PedidoRepository pedido,
            ItemPedidoRepository itemPedidoRepository, ProdutoRepository produtoRepository,
             IClienteService clienteService)
        {
            _pedidoRepository = pedido;
            _produtoRepository = produtoRepository;
            _clienteService = clienteService;
        }

        public async Task<RetornoViewModel<Pedido>> Adicionar(int idCliente, CadastrarPedidoViewModel pedido)
        {
            decimal total = 0;
             
            Pedido novoPedido = new Pedido();
            foreach (var item in pedido.ItensPedidos)
            {
                var produto = _produtoRepository.BuscarProdutoPorId(item.IdProduto);

                if (produto == null)
                {
                    return new RetornoViewModel<Pedido>($"Produto não encontrado a partir do {item.IdProduto}");
                }
                else
                {
                    if (await _produtoRepository.AtualizaEstoque(produto.Id, item.Quantidade))
                    {
                        novoPedido.ItemPedidos.Add(new ItemPedido() { Quantidade = item.Quantidade, IdProduto = produto.Id, Valor = produto.Preco * item.Quantidade });
                        total += produto.Preco * item.Quantidade;
                    }
                    else
                    {
                        return new RetornoViewModel<Pedido>($"Quantidade em estoque insuficiente! Quantidade disponível : {produto.SaldoEstoque}");
                    }
                }
            }         

            novoPedido.Data = DateTime.Now.ToString();
            novoPedido.ValorTotal = total;
            novoPedido.Numero = _pedidoRepository.GerarNumeroPedido() + 1;
            novoPedido.IdCliente = idCliente;

            Pedido resultado = await _pedidoRepository.AdicionarPedido(novoPedido);
            return new RetornoViewModel<Pedido>(resultado);
        }

        

        public Task<Pedido> Atualizar(Pedido pedido)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Pedido> BuscarPedidoPorId(int id)
        {
            return await _pedidoRepository.BuscarPorId(id);
        }
        public async Task<List<Pedido>> BuscarPedidos()
        {
            return await _pedidoRepository.BuscarPedidos();
        }

        public async Task Delete(Pedido pedido)
        {
            await _pedidoRepository.Delete(pedido);
        }

    }
}
