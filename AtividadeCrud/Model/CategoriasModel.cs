using AtividadeCrud.Enums;

namespace AtividadeCrud.Model
{
    public class CategoriasModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusCategoria Status { get; set; }
    }
}
