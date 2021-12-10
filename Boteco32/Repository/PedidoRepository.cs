using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boteco32.Models;
using Microsoft.EntityFrameworkCore;

namespace Boteco32.Repository
{
    public class PedidoRepository : BaseRepository<Pedido>
    {
        private readonly Boteco32Context _context;

        public PedidoRepository(Boteco32Context boteco32Context) : base(boteco32Context)
        {
            _context = boteco32Context;
        }
        public async Task<List<Pedido>> BuscarPedidos()
        {
            return await _context.Pedidos.OrderBy(p => p.Data).ToListAsync();
        }
        public async Task<Pedido> BuscarPedidoPorId(int id)
        {
            return await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
