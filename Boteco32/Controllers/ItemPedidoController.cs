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
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoService _pedidoService;

        public ItemPedidoController(IItemPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        // GET: api/ItemPedido
        [HttpGet]
        public async Task<IActionResult> GetItemPedidos()
        {
            try
            {
                var listaDeItemPedidos = await _pedidoService.BuscarItemPedidos();
                if (listaDeItemPedidos == null)
                {
                    return NotFound(new RetornoViewModel<ItemPedido>("Nenhum itempedido na base de dados"));
                }
                return Ok(new RetornoViewModel<List<ItemPedido>>(listaDeItemPedidos));
            }
            catch (Exception e)
            {
                return StatusCode(500, new RetornoViewModel<List<ItemPedido>>("Erro interno."));
            }
        }

        //GET: api/ItemPedido/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPedido>> GetItemPedido(int id)
        {
            var itempedido = await _pedidoService.BuscarItemPedidoPorId(id);

            if (itempedido == null)
            {
                return NotFound();
            }

            return itempedido;
        }


        // POST: api/ItemPedido
        [HttpPost]
        public async Task<ActionResult<ItemPedido>> PostItemPedido([FromBody] CadastrarItemPedidoViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RetornoViewModel<ItemPedido>(ModelState.RecuperarErros()));
            }
            try
            {
                ItemPedido itempedido = new ItemPedido()
                {
                    Id = 0,
                    IdPedido = pedidoViewModel.IdPedido,
                    IdProduto = pedidoViewModel.IdProduto
                };




        await _pedidoService.Adicionar(itempedido);

                return Created($"/{itempedido.Id}", new RetornoViewModel<ItemPedido>(itempedido));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoViewModel<List<ItemPedido>>("Erro interno"));
            }

        }

        // PUT: api/ItemPedido
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id,
                        [FromBody] CadastrarItemPedidoViewModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest(new RetornoViewModel<ItemPedido>(ModelState.RecuperarErros()));

            try
            {
                var itempedido = await _pedidoService.BuscarItemPedidoPorId(id);

                if (itempedido == null)
                    return NotFound(new RetornoViewModel<ItemPedido>("ItemPedido não encontrado."));

                itempedido.Quantidade = value.Quantidade;
                itempedido.IdPedido = value.IdPedido;
                itempedido.IdProduto = value.IdProduto;

                await _pedidoService.Atualizar(itempedido);

                return Ok(new RetornoViewModel<ItemPedido>(itempedido));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new RetornoViewModel<ItemPedido>("Falha ao atualizar o itempedido."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoViewModel<ItemPedido>("Erro interno."));
            }

        }

        // DELETE: api/ItemPedido/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPedido([FromRoute] int id)
        {
            try
            {
                var itempedido = await _pedidoService.BuscarItemPedidoPorId(id);

                if (itempedido == null)
                    return NotFound(new RetornoViewModel<ItemPedido>("ItemPedido não encontrado."));

                _pedidoService.Delete(itempedido);

                return Ok(new RetornoViewModel<ItemPedido>(itempedido));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new RetornoViewModel<ItemPedido>("Falha ao remover o itempedido."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoViewModel<ItemPedido>("Erro interno."));
            }
        }
    }
}
