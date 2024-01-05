using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Models
{
    public class Reporte{
        public string Id {get;set; }
        public string? IdAjustador { get; set; }
        public string IdConductor { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaIncidente { get; set; }
        public Ubicacion Ubicacion { get; set;}
        public Involucrado? Involucrado { get; set; }
        public Dictamen? Dictamen { get; set; }
        public ICollection <Imagen> Imagenes{ get; set; }
    }
}