using AtividadeCrud.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AtividadeCrud.Data.Map
{
    public class CategoriasMap : IEntityTypeConfiguration<CategoriasModel>
    {
        public void Configure(EntityTypeBuilder<CategoriasModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(255);
        }
    }
}
