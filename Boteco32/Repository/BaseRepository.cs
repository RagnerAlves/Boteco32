using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Boteco32.Models;
using Microsoft.EntityFrameworkCore;

namespace Boteco32.Repository
{
    public class BaseRepository<TEntity> : IDisposable where TEntity : class
    {
        private readonly DbContextOptions<Boteco32Context> _boteco32Context;
        public BaseRepository()
        {
            _boteco32Context = new DbContextOptions<Boteco32Context>();
        }

        public async Task Adicionar(TEntity entity)
        {
            using (var data = new Boteco32Context(_boteco32Context))
            {
                await data.Set<TEntity>().AddAsync(entity);
                await data.SaveChangesAsync();
            }
        }
        public async Task Atualizar(TEntity entity)
        {
            using (var data = new Boteco32Context(_boteco32Context))
            {
                data.Set<TEntity>().Update(entity);
                await data.SaveChangesAsync();
            }
        }
        public async Task Delete(TEntity entity)
        {
            using (var data = new Boteco32Context(_boteco32Context))
            {
                data.Set<TEntity>().Remove(entity);
                await data.SaveChangesAsync();
            }
        }
        public async Task<TEntity> BuscarPorId(int id)
        {
            using (var data = new Boteco32Context(_boteco32Context))
            {
                return await data.Set<TEntity>().FindAsync(id);
            }
        }
        public async Task <List<TEntity>> BuscarTodos()
        {
            using (var data = new Boteco32Context(_boteco32Context))
            {
                return await data.Set<TEntity>().AsNoTracking().ToListAsync();
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
