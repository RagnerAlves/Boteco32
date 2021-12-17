using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.ViewModels.ClienteViewModel;
using Boteco32.ViewModels.RetornoViewModel;

namespace Boteco32.Services
{
    public interface IClienteService : IGenerics<Cliente>
    {

        Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular);

        Task<bool> ExisteUsuario(string email, string senha);

        Task<int> RetornaIdUsuario(string email);
        Task<ListaClienteViewModel> BuscaClientePorId(int id);
        Task<List<ListaClienteViewModel>> ListarTodos();
    }
}
