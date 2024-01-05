using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Models
{
    public class CustomIdentityUser : IdentityUser
    {
        [PersonalData]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }
        public string? IdConductor { get; set; }
    }
}