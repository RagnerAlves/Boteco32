using Boteco32.Repository;
using Boteco32.Services;
using Boteco32.ViewModels.ClienteViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Token;

namespace Boteco32.Controllers
{
    public class LoginController : Controller
    {
        private readonly ClienteRepository _clienteRepository;
         public LoginController(IClienteService clienteService, ClienteRepository clienteRepository)
        {
         
            _clienteRepository = clienteRepository;
        }

        [AllowAnonymous]
        //[Produces("application/json")]
        [HttpPost("/api/CriarToken")]
        public async Task<IActionResult> CriarToken([FromBody] LoginClienteViewModel login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
                return Unauthorized();

            var resultado = await _clienteRepository.ExisteUsuario(login.Email, login.Senha);
            if (resultado)
            {
                var idUsuario = await _clienteRepository.RetornaIdUsuario(login.Email);

                var token = new TokenJWTBuilder()
                     .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                 .AddSubject("Empresa - Canal Dev Net Core")
                 .AddIssuer("Teste.Securiry.Bearer")
                 .AddAudience("Teste.Securiry.Bearer")
                 .AddClaim("idUsuario", idUsuario.ToString())
                 .AddExpiry(5)
                 .Builder();

                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
