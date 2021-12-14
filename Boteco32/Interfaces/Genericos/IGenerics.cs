using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Services
{
    public interface IGenerics<T> where T : class
    {
        Task Adicionar(T obj);
        Task Atualizar(T obj);
        Task Excluir(T obj);
        Task<T> BuscarPorId(int id);
        Task<List<T>> BuscarTodos();
    }
}