using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Models
{
    public class Imagen{
        public string Id { get;set; }
        public string IdReporte { get; set; }
        public string Formato { get; set; }
        public string Datos { get; set; }
    }
}