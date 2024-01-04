using System.ComponentModel.DataAnnotations;

namespace Aseguradora.Models
{
    public class LoginConductorViewModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatoriooooo.")]
        [Display(Name = "Número de celular (Nombre)")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorixxxxx.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]

        public string Password { get; set; }
    }
}
