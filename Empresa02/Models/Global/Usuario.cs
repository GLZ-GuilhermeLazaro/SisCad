namespace SistemaCadastro.Models.Global
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string NomeUsuario { get; set; }
        public required string email { get; set; }
        public required string senha { get; set; }
    }
}
