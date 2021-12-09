using Boteco32.Models;

namespace Boteco32.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>
    {
        private readonly Boteco32Context _context;

        public ProdutoRepository(Boteco32Context boteco32Context) : base(boteco32Context)
        {
            _context = boteco32Context;
        }
    }
}
