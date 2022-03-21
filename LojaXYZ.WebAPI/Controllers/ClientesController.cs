using LojaXYZ.Application.Interfaces;
using LojaXYZ.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LojaXYZ.WebAPI.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/clientes/[action]")]
   
    public class ClientesController : ControllerBase
    {
        private readonly IApplicationCliente _applicationCliente;
        public ClientesController(IApplicationCliente applicationCliente)
        {
            _applicationCliente = applicationCliente;
        }


        [HttpGet("", Name = "Clientes")]
        public async Task<IActionResult> Index()
        {
            var list = await _applicationCliente.GetClientesAsync();
            return Ok(list);
        }

        [HttpGet("{id}", Name = "Cliente")]
        public async Task<IActionResult> Obter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _applicationCliente.FindByIdAsync(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _applicationCliente.InsertAsync(cliente);
            return Ok();

        }

        [HttpPut("{id}", Name = "AtualizarCliente")]
        public ActionResult Atualizar(int id, [FromBody] Cliente cliente)
        {
            var obj = _applicationCliente.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            if (cliente == null)
                return BadRequest();

            _applicationCliente.UpdateAsync(cliente);
            return Ok(cliente);
        }

        [HttpDelete("{id}", Name = "ExcluirCliente")]

        public ActionResult Deletar(int id)
        {
            var obj = _applicationCliente.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            _applicationCliente.DeleteAsync(id);

            return NoContent();
        }

    }
}

