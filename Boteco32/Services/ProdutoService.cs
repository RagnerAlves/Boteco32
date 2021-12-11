using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoService(ProdutoRepository produto)
        {
            _produtoRepository = produto;
        }

        public Task Adicionar(Produto produto)
        {
            return _produtoRepository.Adicionar(produto);
        }

        public Task<Produto> Atualizar(Produto produto)
        {
            return _produtoRepository.Atualizar(produto);
        }

        public async Task<List<Produto>> BuscarProdutos()
        {
            return await _produtoRepository.BuscarProdutos();
        }
        public Produto BuscarProdutoPorId(int id)
        {
            return _produtoRepository.BuscarProdutoPorId(id);
        }

        public void Delete(Produto produto)
        {
            _produtoRepository.Delete(produto);
        }
    }
}
