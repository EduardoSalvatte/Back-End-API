using AtividadeCrud.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AtividadeCrud.Data.Map
{
    public class PedidoMap : IEntityTypeConfiguration<PedidosModel>
    {
        public void Configure(EntityTypeBuilder<PedidosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UsuarioId);
            builder.HasOne(x => x.Usuario);
            builder.Property(x => x.EnderecoEntrega).IsRequired().HasMaxLength(255);
        }
    }
}
