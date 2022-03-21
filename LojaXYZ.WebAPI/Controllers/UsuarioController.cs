using LojaXYZ.Application.Interfaces;
using LojaXYZ.Entidades;
using LojaXYZ.WebAPI.Models;
using LojaXYZ.WebAPI.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaXYZ.WebAPI.Controllers
{

    [ApiController]
    [Route("api/usuario/[action]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IApplicationUsuario _applicationUsuario;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsuarioController(IApplicationUsuario applicationUsuario,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _applicationUsuario = applicationUsuario;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        //[Produces("application/json")]
        [HttpPost("", Name = "CriarTokenIdentity")]
        public async Task<IActionResult> CriarTokenIdentity([FromBody] Login login)
        {

            //Retornando o Id do Usuario logado
            var idUsuario = await _applicationUsuario.RetornaIdUsuario(login.email);

            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha))
                return Unauthorized();

            var resultado = await _signInManager.PasswordSignInAsync(login.email, login.senha, false, lockoutOnFailure: false);
            if (resultado.Succeeded)
            {
                var token = new TokenJWTBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                    .AddSubject("Empresa - Thiago Dev")
                    .AddIssuer("Task App DDD")
                    .AddAudience("Teste.Security.Bearer")
                    .AddClaim("idUsuario", idUsuario) // Pegando o Id do Usuario
                    .AddExpiry(5)
                    .Builder();
                return Ok(token.value);

            }
            else
            {
                return Unauthorized();
            }

        }

        [AllowAnonymous]
        //[Produces("application/json")]
        [HttpPost("", Name = "AdicionarusuarioIdentity")]
        public async Task<IActionResult> AdicionarUsuarioIdentity([FromBody] Login login)
        {

            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.senha))
                return Ok("Falta alguns dados");

            var user = new ApplicationUser
            {
                UserName = login.email,
                Email = login.email,
                Celular = login.celular,
                

            };
            var resultado = await _userManager.CreateAsync(user, login.senha);
            if (resultado.Errors.Any())
            {
                return BadRequest(resultado.Errors);
            }

            //Geração de confirmação caso precise
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            //retorno email
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var resultado2 = await _userManager.ConfirmEmailAsync(user, code);

            if (resultado2.Succeeded)
                return Ok("Usuario adicionado com Sucesso");
            else
                return BadRequest("Erro ao adicionar usuario");
        }



    }
}
