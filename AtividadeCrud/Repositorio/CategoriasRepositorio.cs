using AtividadeCrud.Data;
using AtividadeCrud.Model;
using AtividadeCrud.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtividadeCrud.Repositorio
{
    public class CategoriasRepositorio : ICategoriasRepositorio
    {
        private readonly AtividadeCrudDbContext _dbContext;
        public CategoriasRepositorio(AtividadeCrudDbContext atividadeCrudDbContext)
        {
            _dbContext = atividadeCrudDbContext;
        }

        public async Task<CategoriasModel> BuscarId(int id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CategoriasModel>> BuscarTodasCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }

        public async Task<CategoriasModel> Adicionar(CategoriasModel categoria)
        {
            await _dbContext.Categorias.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();

            return categoria;
        }

        public async Task<bool> Apagar(int id)
        {
            CategoriasModel categoriaPorId = await BuscarId(id);

            if (categoriaPorId == null)
            {
                throw new Exception($"Tarefa do ID: {id} não foi encontrada");

            }

            _dbContext.Categorias.Remove(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CategoriasModel> Atualizar(CategoriasModel categoria, int id)
        {
            CategoriasModel categoriaPorId = await BuscarId(id);

            if (categoriaPorId == null)
            {
                throw new Exception($"Tarefa do ID: {id} não foi encontrada");

            }

            categoriaPorId.Nome = categoria.Nome;
            categoriaPorId.Status = categoria.Status;

            _dbContext.Categorias.Update(categoriaPorId);
            await _dbContext.SaveChangesAsync();

            return categoriaPorId;
        }
    }
}
