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

        public ProdutoRepository(Boteco32Context boteco32Context) : base(boteco32Context)
        {
            _context = boteco32Context;
        }
        public async Task<List<Produto>> BuscarProdutos()
        {
            return await _context.Produtos.OrderBy(p => p.Nome).ToListAsync();
        }
        public async Task<Produto> BuscarProdutoPorId(int id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
