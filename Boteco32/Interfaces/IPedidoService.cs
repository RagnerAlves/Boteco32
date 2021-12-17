using Boteco32.Models;
using Boteco32.Services;
using Boteco32.ViewModels.ProdutoViewModel;
using Boteco32.ViewModels.RetornoViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Interfaces
{
    public interface IPedidoService 
    {
        Task <RetornoViewModel<Pedido>> Adicionar(int idCliente, CadastrarPedidoViewModel pedido);
        Task<List<Pedido>> BuscarPedidos();
        Task<Pedido> BuscarPedidoPorId(int id);
        Task Delete(Pedido pedido);
    }
}
