using AtividadeCrud.Model;

namespace AtividadeCrud.Repositorio.Interfaces
{
    public interface ICategoriasRepositorio
    {
        Task<List<CategoriasModel>> BuscarTodasCategorias();
        Task<CategoriasModel> BuscarId(int id);
        Task<CategoriasModel> Adicionar(CategoriasModel pedido);
        Task<CategoriasModel> Atualizar(CategoriasModel pedido, int id);
        Task<bool> Apagar(int id);
    }
}
