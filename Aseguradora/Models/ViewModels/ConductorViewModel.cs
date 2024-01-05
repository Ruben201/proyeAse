using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Models
{
    public class ConductorViewModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string Nombrecompleto { get; set; }
        public string Licencia { get; set; }
        [Range (1, 150) ]
        public int Edad { get; set; }
    }
}