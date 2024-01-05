using System.ComponentModel.DataAnnotations;

namespace Aseguradora.Models
{
    public class PolizaSeguroViewModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Serie")]
        public string Serie { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Año")]
        public string Ano { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Placas")]
        public string Placas { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string TipoPoliza { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string TipoCobertura { get; set; }
    }
}
