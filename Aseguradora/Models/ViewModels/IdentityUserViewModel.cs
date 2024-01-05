using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Models
{
    public class IdentityUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        [EmailAddress] 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdConductor { get; set; }
        public string Nombrecompleto { get; set; }
        public string Rol { get; set; }
    }
}