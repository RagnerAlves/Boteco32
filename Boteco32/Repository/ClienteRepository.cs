using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Boteco32.Models;
using Boteco32.Services;
using Boteco32.ViewModels.RetornoViewModel;
using Microsoft.EntityFrameworkCore;

namespace Boteco32.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteService
    {
        private readonly DbContextOptions<Boteco32Context> _context;
        public ClienteRepository(Boteco32Context boteco32Context) 
        {
            _context = new DbContextOptions<Boteco32Context>();
        }
       
        public async Task<List<Cliente>> ListarTodos(Expression<Func<Cliente, bool>> expression)
        {
            using (var banco = new Boteco32Context(_context))
            {
                return await banco.Clientes.Where(expression).AsNoTracking().ToListAsync();
            }
        }
        public Task Excluir(Cliente obj)
        {
            throw new NotImplementedException();
        }

      
    }


}
