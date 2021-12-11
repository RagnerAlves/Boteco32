using Boteco32.Models;
using Boteco32.ViewModels.ProdutoViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido> Adicionar(int idCliente, CadastrarPedidoViewModel pedido);
        Task<Pedido> Atualizar(Pedido pedido);
        void Delete(Pedido pedido);
        Task<List<Pedido>> BuscarPedidos();
        Task<Pedido> BuscarPedidoPorId(int id);
    }
}
