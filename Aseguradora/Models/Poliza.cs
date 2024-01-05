using System.ComponentModel.DataAnnotations;
namespace Aseguradora.Models
{
    public enum Cobertura{
        Basica,
        Estandar,
        Premium
    };
    public class Poliza{
        public string Id { get; set; }
        public Cobertura Cobertura {get;set;}
        [Range(0, 3)]
        public int Plazo {get;set;}
        public Vehiculo Vehiculo { get; set; }
    }
}