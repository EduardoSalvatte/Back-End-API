using AtividadeCrud.Data;
using AtividadeCrud.Model;
using AtividadeCrud.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtividadeCrud.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly AtividadeCrudDbContext _dbContext;

        public ProdutoRepositorio(AtividadeCrudDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProdutosModel> Adicionar(ProdutosModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();
            return produto;
        }

        public async Task<bool> Apagar(int id)
        {
            var produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                return false; // Produto não encontrado
            }
            _dbContext.Produtos.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProdutosModel> Atualizar(ProdutosModel produto, int id)
        {
            var produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto com ID: {id} não foi encontrado");
            }
            produtoPorId.Nome = produto.Nome;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.Preco = produto.Preco;
            _dbContext.Produtos.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();
            return produtoPorId;
        }

        public async Task<ProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutosModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
    }
}
