using AtividadeCrud.Model;
using AtividadeCrud.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtividadeCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidosController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosModel>>> BuscarTodosPedidos()
        {
            List<PedidosModel> pedido = await _pedidoRepositorio.BuscarTodosPedidos();
            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidosModel>> BuscarId(int id)
        {
            PedidosModel pedido = await _pedidoRepositorio.BuscarId(id);
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<PedidosModel>> Adicionar([FromBody] PedidosModel pedidosModel)
        {
            PedidosModel pedido = await _pedidoRepositorio.Adicionar(pedidosModel);
            return Ok(pedido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidosModel>> Atualizar(int id, [FromBody] PedidosModel pedidoModel)
        {
            pedidoModel.Id = id;
            PedidosModel pedido = await _pedidoRepositorio.Atualizar(pedidoModel, id);
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidosModel>> Apagar(int id)
        {
            bool apagado = await _pedidoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
