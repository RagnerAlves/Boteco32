using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boteco32.Models;
using Microsoft.EntityFrameworkCore;

namespace Boteco32.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>
    {

        private readonly Boteco32Context _context;

        public ClienteRepository(Boteco32Context boteco32Context) : base(boteco32Context)
        {
            _context = boteco32Context;
        }

        public async Task<List<Cliente>> BuscarClientes()
        {
           return  await _context.Clientes.OrderBy(c => c.Nome).ToListAsync();       
        }
    }


}
