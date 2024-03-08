namespace AtividadeCrud.Model
{
    public class PedidosProdutosModel
    {
        public int Id { get; set; }
        
        public int ProdutoId { get; set; }
        public ProdutosModel? Produto { get; set; }
        public int CategoriaId { get; set; }
        public CategoriasModel? Categoria { get; set; }
        public int Quantidade { get; set; }
    }
}
