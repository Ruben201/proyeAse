using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Models
{
    public class Dictamen{
        public string Id { get; set; }
        public string Folio { get; set; }
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
    }
}