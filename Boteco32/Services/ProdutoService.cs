using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoRepository _produto;

        public ProdutoService(ProdutoRepository produto) 
        {
            _produto = produto;

        }

        public Task Adicionar(Produto produto)
        {
           return _produto.Adicionar(produto);
        }

        public void Atualizar(Produto produto)
        {
         
        }

        public List<Produto> BuscarProdutos()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Produto produto)
        {
            throw new System.NotImplementedException();
        }
    }
}
