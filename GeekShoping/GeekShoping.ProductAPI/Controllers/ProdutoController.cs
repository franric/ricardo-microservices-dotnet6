using GeekShoping.ProductAPI.Models.InputModel;
using GeekShopping.ProductAPI.Infra.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShoping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _repositorio;

        public ProdutoController(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoInputModel>> BuscarPorId([FromRoute] long id)
        {
            var produto = await _repositorio.FindById(id);
            if (produto == null) return NotFound();

            return Ok(produto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoInputModel>>> BuscarTodos()
        {
            var produto = await _repositorio.FindAll();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoInputModel>> Cadastrar([FromBody] ProdutoInputModel produto)
        {
            if (produto == null) return BadRequest();

            var novoProduto = await _repositorio.Create(produto);

            return Ok(novoProduto);
        }

        [HttpPut]
        public async Task<ActionResult<ProdutoInputModel>> Atualizar([FromBody] ProdutoInputModel produto)
        {
            if (produto == null) return BadRequest();

            var novoProduto = await _repositorio.Update(produto);

            return Ok(novoProduto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            var status = await _repositorio.Delete(id);
            if (!status) return BadRequest();

            return Ok(status);
        }

    }
}
