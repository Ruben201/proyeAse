namespace Aseguradora.Models
{
    public class LoginResponse{
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string rol { get; set; }
        public string IdConductor { get; set; }
        public string AcessToken { get; set; }
    }
}