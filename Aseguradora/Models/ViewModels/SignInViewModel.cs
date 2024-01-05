
namespace Aseguradora.Models
{
    
    public class SignInViewModel{
        public string UserName { get; set; }
        public string Email { get;set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<string> Roles {get;set;}
    }
}