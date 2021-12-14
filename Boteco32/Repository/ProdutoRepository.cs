using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boteco32.Models;
using Microsoft.EntityFrameworkCore;

namespace Boteco32.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>
    {
        private readonly Boteco32Context _context;

        public ProdutoRepository(Boteco32Context boteco32Context)
        {
            _context = boteco32Context;
        }
        public async Task<List<Produto>> BuscarProdutos()
        {
            return await _context.Produtos.OrderBy(p => p.Nome).ToListAsync();
        }
        public Produto BuscarProdutoPorId(int id)
        {
            var resultado = _context.Produtos.FirstOrDefault(p => p.Id == id);
            return resultado;
        }

        public async Task<bool> AtualizaEstoque(int id, int quantidade)
        {
            Produto produto = BuscarProdutoPorId(id);
            if(produto.SaldoEstoque >= quantidade)
            {
                produto.SaldoEstoque -= quantidade;
                await Atualizar(produto);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
