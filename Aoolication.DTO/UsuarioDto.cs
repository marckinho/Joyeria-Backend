namespace Application.DTO
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public bool Activo { get; set; }
        public string Token { get; set; }
    }
}
