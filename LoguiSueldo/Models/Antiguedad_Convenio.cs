using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoguiSueldo.Models
{
    public class Antiguedad_Convenio
    {
        [Key]
        public int AntiguedadConvenioID { get; set; }
        public int ConvenioID { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal Desde { get; set; }
        public decimal Hasta { get; set; }
        public bool CalculaPorAnio { get; set; }
    }
}
