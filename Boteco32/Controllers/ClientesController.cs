
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Boteco32.Models;
using Boteco32.Services;
using System.Linq;
using System.Collections.Generic;
using Boteco32.ViewModels.ClienteViewModel;
using Boteco32.ViewModels.RetornoViewModel;
using Boteco32.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Boteco32.Util;

namespace Boteco32.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        // GET: api/Clientes
        [Authorize]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            try
            {
                var listaDeClientes = await _clienteService.ListarTodos();
                if (listaDeClientes == null)
                {
                    return NotFound(new RetornoViewModel<ListaClienteViewModel>("Nenhum cliente na base de dados"));
                }
                return Ok(new RetornoViewModel<List<ListaClienteViewModel>>(listaDeClientes));
            }
            catch (Exception e)
            {
                return StatusCode(500, new RetornoViewModel<List<ListaClienteViewModel>>("Erro interno."));
            }
        }

        //GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListaClienteViewModel>> GetCliente(int id)
        {
            var cliente = await _clienteService.BuscaClientePorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }
        //POST: api/Clientes    
        [HttpPost]      
        public async Task<ActionResult<Cliente>> PostCliente(
                            [FromBody] CadastrarClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RetornoViewModel<Cliente>(ModelState.RecuperarErros()));
            }
            try
            {
              
                    if (Valida.ValidaEmail(clienteViewModel.Email))
                    {
                        Cliente cliente = new Cliente()
                        {
                            Nome = clienteViewModel.Nome,
                            Email = clienteViewModel.Email,
                            Senha = clienteViewModel.Senha,
                            Endereco = clienteViewModel.Endereco,
                            Telefone = clienteViewModel.Telefone
                        };
                        await _clienteService.Adicionar(cliente);

                        return Created($"/{cliente.Id}", new RetornoViewModel<Cliente>(cliente));
                    }
                    else
                    {
                        return StatusCode(500, new RetornoViewModel<List<Cliente>>("Email invalido"));
                    }
                
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new RetornoViewModel<List<Cliente>>("Falha ao atualizar o registro"));
            }
            catch (Exception)
            {
                return StatusCode(500, new RetornoViewModel<List<Cliente>>("Erro interno"));
            }

        }

        // PUT: api/Clientes
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id,
                        [FromBody] CadastrarClienteViewModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest(new RetornoViewModel<Cliente>(ModelState.RecuperarErros()));

            try
            {
                var cliente = await _clienteService.BuscarPorId(id);

                if (cliente == null)
                    return NotFound(new RetornoViewModel<Cliente>("Cliente não encontrado."));

                cliente.Nome = value.Nome;
                cliente.Endereco = value.Endereco;
                cliente.Telefone = value.Telefone;

                await _clienteService.Atualizar(cliente);

                return Ok(new RetornoViewModel<Cliente>(cliente));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new RetornoViewModel<Cliente>("Falha ao atualizar o cliente."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoViewModel<Cliente>("Erro interno."));
            }

        }

        // DELETE: api/Clientes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] int id)
        {
            try
            {
                var cliente = await _clienteService.BuscarPorId(id);

                if (cliente == null)
                    return NotFound(new RetornoViewModel<Produto>("Produto não encontrado."));

                await _clienteService.Excluir(cliente);

                return Ok(new RetornoViewModel<Cliente>(cliente));
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new RetornoViewModel<Cliente>("Falha ao remover o cliente."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new RetornoViewModel<Cliente>("Erro interno."));
            }
        }

    }
}
