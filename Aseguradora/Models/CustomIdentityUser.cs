using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Aseguradora.Models
{
    public class CustomIdentityUser : IdentityUser
    {
        [PersonalData]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Display(Name = "ApellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "ApellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "FechaIngreso")]
        public DateTime FechaIngreso { get; set; }

        [Display(Name = "FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "NumeroDeLicencia")]
        public string NumeroDeLicencia { get; set; }


        /// <summary>
        /// //////////////////////////////////////////
        /// </summary>
        /// 

        [Display(Name = "NumeroSerie")]
        public string Serie { get; set; }

        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Display(Name = "Año")]
        public string Ano { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Placas")]
        public string Placas { get; set; }

        [Display(Name = "TipoPoliza")]
        public string TipoPoliza { get; set; }

        [Display(Name = "TipoCobertura")]
        public string TipoCobertura { get; set; }

        /// <summary>
        /// //////////////////////////////////////////
        /// </summary>
        /// 




    }
}
