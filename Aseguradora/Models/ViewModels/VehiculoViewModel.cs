using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Models
{
    public class VehiculoViewModel
    {
        public string Id { get; set; }
        [StringLength(4)]
        public string Anio { get; set; }
        public string Matricula { get; set; }
        public string Color { get; set; }
        public string Serie { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }
}