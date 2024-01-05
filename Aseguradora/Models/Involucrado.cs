namespace Aseguradora.Models
{
    public class Involucrado{
        public string Id { get; set; }
        public string Nombres {get;set;} 
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string NombreCompleto  { get; set; }
        public Vehiculo? Vehiculo { get; set; }
    }
}