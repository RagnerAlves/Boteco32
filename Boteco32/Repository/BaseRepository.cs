﻿using System;
using Boteco32.Models;
using Microsoft.EntityFrameworkCore;

namespace Boteco32.Repository
{
    public class BaseRepository<TEntity> : IDisposable where TEntity : class
    {

        private readonly Boteco32Context _boteco32Context;
        private DbSet<TEntity> dbSet;

        public BaseRepository(Boteco32Context boteco32Context)
        {
            _boteco32Context = boteco32Context;         
        }

        public void Adicionar(TEntity entity)
        {
            _boteco32Context.Add(entity);
            _boteco32Context.SaveChanges();
        }

        public TEntity Atualizar(TEntity entity)
        {
            _boteco32Context.Update(entity);
            _boteco32Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _boteco32Context.Remove(entity);
            _boteco32Context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
