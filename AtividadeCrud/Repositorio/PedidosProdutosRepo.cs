using AtividadeCrud.Data;
using AtividadeCrud.Model;
using AtividadeCrud.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace AtividadeCrud.Repositorio
{
    public class PedidosProdutosRepo : IPedidosProdutos
    {
        private readonly AtividadeCrudDbContext _dbContext;

        public PedidosProdutosRepo(AtividadeCrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidosProduto)
        {
            await _dbContext.PedidosProdutos.AddAsync(pedidosProduto);
            await _dbContext.SaveChangesAsync();
            return pedidosProduto;
        }

        public async Task<bool> Apagar(int id)
        {
            var pedidoProduto = await BuscarPorId(id);
            if (pedidoProduto == null)
            {
                return false; // PedidoProduto não encontrado
            }
            _dbContext.PedidosProdutos.Remove(pedidoProduto);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidosProduto, int id)
        {
            PedidosProdutosModel pedidoProdutoPorId = await BuscarPorId(id);
            if (pedidoProdutoPorId == null)
            {
                throw new Exception($"PedidoProduto com ID: {id} não foi encontrado");
            }
            pedidoProdutoPorId.Id = pedidosProduto.Id;
            pedidoProdutoPorId.CategoriaId = pedidosProduto.CategoriaId;
            pedidoProdutoPorId.ProdutoId = pedidosProduto.ProdutoId;
            pedidoProdutoPorId.Quantidade = pedidosProduto.Quantidade;

            _dbContext.PedidosProdutos.Update(pedidoProdutoPorId);
            await _dbContext.SaveChangesAsync();
            return pedidosProduto;
        }

        public async Task<List<PedidosProdutosModel>> BuscarPedidosProdutos()
        {
            return await _dbContext.PedidosProdutos.ToListAsync();
        }

        public async Task<PedidosProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.PedidosProdutos.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
