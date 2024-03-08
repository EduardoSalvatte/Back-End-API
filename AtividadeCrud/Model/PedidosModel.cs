namespace AtividadeCrud.Model
{
    public class PedidosModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
        public string EnderecoEntrega { get; set; }
    }
}
