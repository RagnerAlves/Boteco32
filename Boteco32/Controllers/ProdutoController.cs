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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            try
            {
                var listaDeProdutos = await _produtoService.BuscarProdutos();
                if (listaDeProdutos == null)
                {
                    return NotFound(new RetornoViewModel<Produto>("Nenhum cliente na base de dados"));
                }
                return Ok(new RetornoViewModel<List<Produto>>(listaDeProdutos));
            }
            catch (Exception e)
            {
                return StatusCode(500, new RetornoViewModel<List<Produto>>("Erro interno."));
            }
        }

        //GET: api/Produto/{id}
        [HttpGet("{id}")]
        public ActionResult<Produto> GetProduto(int id)
        {
            var cliente = _produtoService.BuscarProdutoPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }


        // POST: api/Produto
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto([FromBody] CadastrarProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RetornoViewModel<Produto>(ModelState.RecuperarErros()));
            }
            try
            {
                Produto produto = new Produto()
                {
                    Id = 0,
                    Codigo = produtoViewModel.Codigo,
                    Nome = produtoViewModel.Nome,
                    Preco = produtoViewModel.Preco,
                    SaldoEstoque = produtoViewModel.SaldoEstoque
                };

                await _produtoService.Adicionar(produto);

                return Created($"/{produto.Id}", new RetornoViewModel<Produto>(produto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoViewModel<List<Produto>>("Erro interno"));
            }

        }

        // PUT: api/Produto
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id,
                        [FromBody] CadastrarProdutoViewModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest(new RetornoViewModel<Produto>(ModelState.RecuperarErros()));

            try
            {
                var produto = _produtoService.BuscarProdutoPorId(id);

                if (produto == null)
                    return NotFound(new RetornoViewModel<Produto>("Produto não encontrado."));

                produto.Nome = value.Nome;
                produto.Codigo = value.Codigo;
                produto.Preco = value.Preco;
                produto.SaldoEstoque = value.SaldoEstoque;

                await _produtoService.Atualizar(produto);

                return Ok(new RetornoViewModel<Produto>(produto));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new RetornoViewModel<Produto>("Falha ao atualizar o produto."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoViewModel<Produto>("Erro interno."));
            }

        }

        // DELETE: api/Produto/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto([FromRoute] int id)
        {
            try
            {
                var produto = _produtoService.BuscarProdutoPorId(id);

                if (produto == null)
                    return NotFound(new RetornoViewModel<Produto>("Produto não encontrado."));

                await _produtoService.Delete(produto);

                return Ok(new RetornoViewModel<Produto>(produto));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new RetornoViewModel<Produto>("Falha ao remover o produto."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoViewModel<Produto>("Erro interno."));
            }
        }
    }
}
