using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.ViewModels.ProdutoViewModel;
using Boteco32.ViewModels.RetornoViewModel;
using Microsoft.EntityFrameworkCore;

namespace Boteco32.Repository
{
    public class PedidoRepository : BaseRepository<Pedido>, IDisposable
    {
        private readonly DbContextOptions<Boteco32Context> _context;

        public PedidoRepository()
        {
            _context = new DbContextOptions<Boteco32Context>();
        }
        public async Task<Pedido> AdicionarPedido(Pedido pedido)
        {
            using (var data = new Boteco32Context(_context))
            {
               await data.Set<Pedido>().AddAsync(pedido);
               await data.SaveChangesAsync();
                return pedido;
            }
        }
        public async Task<List<Pedido>> BuscarPedidos()
        {
            using (var data = new Boteco32Context(_context))
            {
                return await data.Set<Pedido>().AsNoTracking().ToListAsync();
            }

        }
        public async Task<Pedido> BuscarPedidoPorId(int id)
        {
            using (var data = new Boteco32Context(_context))
            {
                return await data.Set<Pedido>().FindAsync(id);
            }       
        }
        public int GerarNumeroPedido()
        {
            using (var data = new Boteco32Context(_context))
            {
              int quant =  data.Set<Pedido>().Count();
              return quant;
            }                   
        }

        public async Task DeletePedido(Pedido pedido)
        {
            using (var data = new Boteco32Context(_context))
            {
               data.Set<ItemPedido>().Remove(pedido.ItemPedidos.FirstOrDefault( p => p != null));
               await data.SaveChangesAsync();
               await data.SaveChangesAsync();
            }

        }
    }
}
