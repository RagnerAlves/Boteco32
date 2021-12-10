
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

        // GET: api/Clientes teste 
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            try
            {
                var listaDeClientes = await _clienteService.BuscarClientes();
                if (listaDeClientes == null)
                {
                    return NotFound(new RetornoViewModel<Cliente>("Nenhum cliente na base de dados"));
                }
                return Ok(new RetornoViewModel<List<Cliente>>(listaDeClientes));
            }
            catch (Exception e)
            {
                return StatusCode(500, new RetornoViewModel<List<Cliente>>("Erro interno."));
            }
        } 
            /*
            // GET: api/Clientes/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Cliente>> GetCliente(int id)
            {
                var cliente = await _context.Clientes.FindAsync(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return cliente;
            }

            // PUT: api/Clientes/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCliente(int id, Cliente cliente)
            {
                if (id != cliente.Id)
                {
                    return BadRequest();
                }

                _context.Entry(cliente).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            // DELETE: api/Clientes/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCliente(int id)
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool ClienteExists(int id)
            {
                return _context.Clientes.Any(e => e.Id == id);
            }

             */

            // POST: api/Clientes
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
                    Cliente cliente = new Cliente()
                    {
                        Id = 0,
                        Codigo = clienteViewModel.Codigo,
                        Nome = clienteViewModel.Nome,
                        Endereco = clienteViewModel.Endereco,
                        Pedidos = null
                    };

                    await _clienteService.Adicionar(cliente);

                    //return Created($"/{aluno.Id}", aluno);
                    return Created($"/{cliente.Id}", new RetornoViewModel<Cliente>(cliente));
                }
                catch (DbUpdateException ex)
                {
                    //return StatusCode(500, "Falha ao atualizar o registro");
                    return StatusCode(500, new RetornoViewModel<List<Cliente>>("Falha ao atualizar o registro"));
                }
                catch (Exception ex)
                {
                    //return StatusCode(500, "Erro interno");
                    return StatusCode(500, new RetornoViewModel<List<Cliente>>("Erro interno"));
                }

            }
        }
    }
