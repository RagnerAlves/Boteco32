using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.ViewModels.RetornoViewModel;

namespace Boteco32.Services
{
    public interface IClienteService : IGenerics<Cliente>
    {     
        Task<List<Cliente>>ListarTodos(Expression<Func<Cliente, bool>> expression);      
    }
}
