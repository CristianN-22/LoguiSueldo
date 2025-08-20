using System.ComponentModel.DataAnnotations;

namespace LoguiSueldo.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public decimal Sueldo_basico { get; set; }
        public int TipoUnidad {  get; set; }
        public decimal CantUnidades { get; set; }
    }
}
