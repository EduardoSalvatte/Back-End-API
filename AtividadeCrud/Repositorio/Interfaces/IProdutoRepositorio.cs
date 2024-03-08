using AtividadeCrud.Model;

namespace AtividadeCrud.Repositorio.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutosModel>> BuscarTodosProdutos();
        Task<ProdutosModel> BuscarPorId(int id);
        Task<ProdutosModel> Adicionar(ProdutosModel produto);
        Task<bool> Apagar(int id);
        Task<ProdutosModel> Atualizar(ProdutosModel produto, int id);
    }
}
