using AtividadeCrud.Model;
using AtividadeCrud.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtividadeCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly ICategoriasRepositorio _categoriasRepositorio;

        public CategoriasController(ICategoriasRepositorio categoriasRepositorio)
        {
            _categoriasRepositorio = categoriasRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriasModel>>> BuscarTodasCategorias()
        {
            List<CategoriasModel> categoria = await _categoriasRepositorio.BuscarTodasCategorias();
            return Ok(categoria);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriasModel>> BuscarId(int id)
        {
            CategoriasModel categoria = await _categoriasRepositorio.BuscarId(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriasModel>> Adicionar([FromBody] CategoriasModel categoriasModel)
        {
            CategoriasModel categoria = await _categoriasRepositorio.Adicionar(categoriasModel);
            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriasModel>> Atualizar(int id, [FromBody] CategoriasModel categoriasModel)
        {
            categoriasModel.Id = id;
            CategoriasModel categoria = await _categoriasRepositorio.Atualizar(categoriasModel, id);
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriasModel>> Apagar(int id)
        {
            bool apagado = await _categoriasRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
