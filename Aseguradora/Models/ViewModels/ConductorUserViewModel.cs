using System.ComponentModel.DataAnnotations;

namespace Aseguradora.Models
{
    public class ConductorUserViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string Nombrecompleto { get; set; }
        [Range(1, 150)]
        public int Edad { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Nombre { get; set; }
        public string Licencia { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
