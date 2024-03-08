using AtividadeCrud.Model;
using AtividadeCrud.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtividadeCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedProdutosController : Controller
    {
        private readonly IPedidosProdutos _pedidosProdutosRepo;

        public PedProdutosController(IPedidosProdutos pedidosProdutosRepo)
        {
            _pedidosProdutosRepo = pedidosProdutosRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosProdutosModel>>> BuscarTodosPedidosProdutos()
        {
            List<PedidosProdutosModel> pedidosProdutos = await _pedidosProdutosRepo.BuscarPedidosProdutos();
            return Ok(pedidosProdutos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosProdutosModel>> BuscarId(int id)
        {
            PedidosProdutosModel pedidoProduto = await _pedidosProdutosRepo.BuscarPorId(id);
            return Ok(pedidoProduto);
        }

        [HttpPost]
        public async Task<ActionResult<PedidosProdutosModel>> Adicionar([FromBody] PedidosProdutosModel pedidosProdutosModel)
        {
            PedidosProdutosModel pedidoProduto = await _pedidosProdutosRepo.Adicionar(pedidosProdutosModel);
            return Ok(pedidoProduto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidosProdutosModel>> Atualizar(int id, [FromBody] PedidosProdutosModel pedidosProdutosModel)
        {
            pedidosProdutosModel.Id = id;
            PedidosProdutosModel pedidoProduto = await _pedidosProdutosRepo.Atualizar(pedidosProdutosModel, id);
            return Ok(pedidoProduto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidosProdutosModel>> Apagar(int id)
        {
            bool apagado = await _pedidosProdutosRepo.Apagar(id);
            return Ok(apagado);
        }
    }
}
