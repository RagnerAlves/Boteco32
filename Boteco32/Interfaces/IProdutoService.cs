using Boteco32.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Interfaces
{
    public interface IProdutoService
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Delete(Produto produto);
        Task<List<Produto>> BuscarProdutos();
        Produto BuscarProdutoPorId(int id);
    }
}
