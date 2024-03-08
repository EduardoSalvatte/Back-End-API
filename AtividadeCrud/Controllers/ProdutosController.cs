using AtividadeCrud.Model;
using AtividadeCrud.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtividadeCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutosModel>>> BuscarTodosProdutos()
        {
            List<ProdutosModel> produtos = await _produtoRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosModel>> BuscarPorId(int id)
        {
            ProdutosModel produto = await _produtoRepositorio.BuscarPorId(id);
            if (produto == null)
            {
                return NotFound(); // Produto não encontrado
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutosModel>> Adicionar([FromBody] ProdutosModel produtoModel)
        {
            try
            {
                ProdutosModel produto = await _produtoRepositorio.Adicionar(produtoModel);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao adicionar o produto: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutosModel>> Atualizar(int id, [FromBody] ProdutosModel produtoModel)
        {
            try
            {
                produtoModel.Id = id;
                ProdutosModel produto = await _produtoRepositorio.Atualizar(produtoModel, id);
                if (produto == null)
                {
                    return NotFound(); // Produto não encontrado
                }
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao atualizar o produto: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            try
            {
                bool apagado = await _produtoRepositorio.Apagar(id);
                if (!apagado)
                {
                    return NotFound(); // Produto não encontrado
                }
                return Ok(apagado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro ao apagar o produto: {ex.Message}");
            }
        }
    }
}
