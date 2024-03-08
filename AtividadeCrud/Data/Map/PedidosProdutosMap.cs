using AtividadeCrud.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AtividadeCrud.Data.Map
{
    public class PedidosProdutosMap : IEntityTypeConfiguration<PedidosProdutosModel>
    {
        public void Configure(EntityTypeBuilder<PedidosProdutosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProdutoId);
            builder.HasOne(x => x.Produto);
            builder.Property(x => x.CategoriaId);
            builder.HasOne(x => x.Categoria);
            builder.Property(x => x.Quantidade).IsRequired();
        }
    }
}
