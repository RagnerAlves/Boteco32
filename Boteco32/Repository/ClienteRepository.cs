using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Boteco32.Models;
using Boteco32.Services;
using Boteco32.ViewModels.ClienteViewModel;
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

        public Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            try
            {
                using (var data = new Boteco32Context(_context))
                {
                    return await data.Clientes.
                          Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
                          .AsNoTracking()
                          .AnyAsync();

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int> RetornaIdUsuario(string email)
        {
            try
            {
                using (var data = new Boteco32Context(_context))
                {
                    var usuario = await data.Clientes.
                          Where(u => u.Email.Equals(email))
                          .AsNoTracking()
                          .FirstOrDefaultAsync();

                    return usuario.Id;

                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Task<List<ListaClienteViewModel>> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<ListaClienteViewModel> BuscaClientePorId(int id)
        {
            throw new NotImplementedException();
        }
    }


}
