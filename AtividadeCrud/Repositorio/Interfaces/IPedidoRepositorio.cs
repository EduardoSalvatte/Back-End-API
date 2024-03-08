using AtividadeCrud.Model;

namespace AtividadeCrud.Repositorio.Interfaces
{
    public interface IPedidoRepositorio
    {
            Task<List<PedidosModel>> BuscarTodosPedidos();
            Task<PedidosModel> BuscarId(int id);
            Task<PedidosModel> Adicionar(PedidosModel pedido);
            Task<PedidosModel> Atualizar(PedidosModel pedido, int id);
            Task<bool> Apagar(int id);
        
    }
}
