using AtividadeCrud.Data;
using AtividadeCrud.Model;
using AtividadeCrud.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtividadeCrud.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly AtividadeCrudDbContext _dbContext;
        public UsuarioRepositorio(AtividadeCrudDbContext atividadeCrubDbContext)
        {
            _dbContext = atividadeCrubDbContext;
        }
        public async Task<UsuarioModel> BuscarId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário do ID: {id} não foi encontrado");

            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário do ID: {id} não foi encontrado");

            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.DataNascimento = usuario.DataNascimento;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }
    }
}
