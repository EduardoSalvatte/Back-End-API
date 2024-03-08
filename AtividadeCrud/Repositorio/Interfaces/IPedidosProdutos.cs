using AtividadeCrud.Model;

namespace AtividadeCrud.Repositorio.Interfaces
{
    public interface IPedidosProdutos
    {
        Task<List<PedidosProdutosModel>> BuscarPedidosProdutos();
        Task<PedidosProdutosModel> BuscarPorId(int id);
        Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel produto);
        Task<bool> Apagar(int id);
        Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel produto, int id);
    }
}
