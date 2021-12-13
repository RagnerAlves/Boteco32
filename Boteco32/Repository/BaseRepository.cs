using System;
using System.Threading.Tasks;
using Boteco32.Models;
using Microsoft.EntityFrameworkCore;

namespace Boteco32.Repository
{
    public class BaseRepository<TEntity> : IDisposable where TEntity : class
    {

        private readonly Boteco32Context _boteco32Context;
        //private DbSet<TEntity> dbSet;

        public BaseRepository(Boteco32Context boteco32Context)
        {
            _boteco32Context = boteco32Context;
        }

        public async Task<TEntity> Adicionar(TEntity entity)
        {
            await _boteco32Context.AddAsync(entity);
            _boteco32Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> Atualizar(TEntity entity)
        {
            _boteco32Context.Update(entity);
            _boteco32Context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            _boteco32Context.Remove(entity);
           await _boteco32Context.SaveChangesAsync();
            return entity;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
