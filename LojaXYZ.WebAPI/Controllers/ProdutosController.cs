using LojaXYZ.Application.Interfaces;
using LojaXYZ.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LojaXYZ.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/produtos/[action]")]

    public class ProdutosController : ControllerBase
    {
        private readonly IApplicationProduto _applicationProduto;
        public ProdutosController(IApplicationProduto applicationProduto)
        {
            _applicationProduto = applicationProduto;
        }

        [HttpGet("", Name = "Produtos")]
        public async Task<IActionResult> Index()
        {
            var list = await _applicationProduto.GetProdutosAsync();
            return Ok(list);
        }

        [HttpGet("{id}", Name = "Produto")]
        public async Task<IActionResult> Obter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _applicationProduto.FindByIdAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }


        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _applicationProduto.InsertAsync(produto);
            return Ok();

        }

        [HttpPut("{id}", Name = "AtualizarProduto")]
        public ActionResult Atualizar(int id, [FromBody] Produto produto)
        {
            var obj = _applicationProduto.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            if (produto == null)
                return BadRequest();

            _applicationProduto.UpdateAsync(produto);
            return Ok(produto);
        }

        [HttpDelete("{id}", Name = "ExcluirProduto")]

        public ActionResult Deletar(int id)
        {
            var obj = _applicationProduto.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            _applicationProduto.DeleteAsync(id);

            return NoContent();
        }

    }
}
