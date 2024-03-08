using AtividadeCrud.Data;
using AtividadeCrud.Model;
using AtividadeCrud.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtividadeCrud.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly AtividadeCrudDbContext _dbContext;
        public PedidoRepositorio(AtividadeCrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PedidosModel> Adicionar(PedidosModel pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<bool> Apagar(int id)
        {
            var pedidoPorId = await BuscarId(id);
            if (pedidoPorId == null)
            {
                return false; // O pedido não foi encontrado
            }
            _dbContext.Pedidos.Remove(pedidoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidosModel> Atualizar(PedidosModel pedido, int id)
        {
            var pedidoPorId = await BuscarId(id);
            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido com ID: {id} não foi encontrado");
            }
            pedidoPorId.UsuarioId = pedido.UsuarioId;
            pedidoPorId.EnderecoEntrega = pedido.EnderecoEntrega;

            _dbContext.Pedidos.Update(pedidoPorId);
            await _dbContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<PedidosModel> BuscarId(int id)
        {
            return await _dbContext.Pedidos
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PedidosModel>> BuscarTodosPedidos()
        {
            return await _dbContext.Pedidos.ToListAsync();
        }
    }
}
