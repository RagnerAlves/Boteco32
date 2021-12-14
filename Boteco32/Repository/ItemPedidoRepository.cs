using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boteco32.Models;
using Microsoft.EntityFrameworkCore;

namespace Boteco32.Repository
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>
    {
        private readonly Boteco32Context _context;

        public ItemPedidoRepository(Boteco32Context boteco32Context)
        {
            _context = boteco32Context;
        }
        public async Task<List<ItemPedido>> BuscarItemPedidos()
        {
            return await _context.ItemPedidos.OrderBy(p => p.IdPedido).ToListAsync();
        }
        public async Task<ItemPedido> BuscarPedidoPorId(int id)
        {
            return await _context.ItemPedidos.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
