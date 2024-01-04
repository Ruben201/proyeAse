using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Aseguradora.Models
{
    public class ConductorViewModel
    {

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "ApellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "ApellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Numero de licencia")]
        public string NumeroDeLicencia { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Numero de teléfono")]
        public string PhoneNumber { get; set; }

        [DisplayName("Fecha de nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "El campo {0} debe ser una fecha")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Compare(otherProperty: "Password", ErrorMessage = "La contraseñas no coinciden.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme su contraseña")]
        public string ConfirmPassword { get; set; }
    }
}
