using Boteco32.Extensions;
using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.ViewModels.ProdutoViewModel;
using Boteco32.ViewModels.RetornoViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boteco32.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            try
            {
                var listaDePedidos = await _pedidoService.BuscarPedidos();
                if (listaDePedidos == null)
                {
                    return NotFound(new RetornoViewModel<Pedido>("Nenhum cliente na base de dados"));
                }
                return Ok(new RetornoViewModel<List<Pedido>>(listaDePedidos));
            }
            catch (Exception e)
            {
                return StatusCode(500, new RetornoViewModel<List<Pedido>>("Erro interno."));
            }
        }

        //GET: api/Pedido/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var cliente = await _pedidoService.BuscarPedidoPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }


        // POST: api/Pedido
        [HttpPost]
        public async Task<IActionResult> PostPedido([FromBody] CadastrarPedidoViewModel pedidoViewModel,
            int idCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RetornoViewModel<Pedido>(ModelState.RecuperarErros()));
            }
            try
            {
                var retornoViewModel = await _pedidoService.Adicionar(idCliente, pedidoViewModel);
                return Created($"/{retornoViewModel.Erros}", retornoViewModel);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new RetornoViewModel<List<Pedido>>("Falha ao salvar o registro"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoViewModel<List<Pedido>>("Erro interno"));
            }

        }


        //// DELETE: api/Pedido/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePedido([FromRoute] int id)
        //{
        //    try
        //    {
        //        var pedido = await _pedidoService.BuscarPedidoPorId(id);

        //        if (pedido == null)
        //            return NotFound(new RetornoViewModel<Pedido>("Pedido não encontrado."));

        //        await _pedidoService.Delete(pedido);

        //        return Ok(new RetornoViewModel<Pedido>(pedido));
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        return StatusCode(500, new RetornoViewModel<Pedido>("Falha ao remover o pedido."));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new RetornoViewModel<Pedido>("Erro interno."));
        //    }
        //}

    }
}
