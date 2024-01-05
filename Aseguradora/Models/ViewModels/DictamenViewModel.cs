using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Models
{
    public class DictamenViewModel{
        public string Id { get; set; }
        public string Folio { get; set; }
        public string Descripcion { get; set; }
        [DataType(DataType.Date)]
        public DateOnly Fecha { get; set; }
        public string Hora { get; set; }
    }
}