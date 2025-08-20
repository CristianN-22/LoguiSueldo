using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;


namespace LoguiSueldo.Models
{
    public class Conceptos
    {
        [Key]
        public int ConceptoID { get; set; }
        public int ConvenioID { get; set; }
        public string Descripcion { get; set; }
        public string NombreVariable { get; set; }
        public string Formula { get; set; }
        public int Nivel { get; set; }
        public int Asiento { get; set; }
        public int Bloque { get; set; }
        public bool Inamobible { get; set; }
        public bool Remunerable { get; set; }
        public bool sel { get; set; }
        public decimal Monto { get; set; }
    }
}
