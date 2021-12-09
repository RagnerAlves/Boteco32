using Boteco32.Extensions;
using Boteco32.Interfaces;
using Boteco32.Models;
using Boteco32.ViewModels.ProdutoViewModel;
using Boteco32.ViewModels.RetornoViewModel;
using Microsoft.AspNetCore.Http;
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
                    Preco = produtoViewModel.Preco
                };

                await _produtoService.Adicionar(produto);

                return Created($"/{produto.Id}", new RetornoViewModel<Produto>(produto));
            }
            catch (Exception ex)
            { 
                return StatusCode(500, new RetornoViewModel<List<Produto>>("Erro interno"));
            }

        }
    }
}
