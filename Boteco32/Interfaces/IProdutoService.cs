using Boteco32.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Interfaces
{
    public interface IProdutoService
    {
        Task Adicionar(Produto produto);
        Task<Produto> Atualizar(Produto produto);
        void Delete(Produto produto);
        Task<List<Produto>> BuscarProdutos();
        Task<Produto> BuscarProdutoPorId(int id);
    }
}
