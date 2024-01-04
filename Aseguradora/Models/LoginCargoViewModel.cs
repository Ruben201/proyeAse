using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Models
{
    public class LoginCargoViewModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatoriooooo.")]
        [Display(Name = "Nombre de usuario")]

        public string UserName { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorixxxxx.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]

        public string Password { get; set; }
    }
}
