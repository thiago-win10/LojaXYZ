namespace LojaXYZ.WebAPI.Models
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int IdUsuario { get; set; }
    }
}
