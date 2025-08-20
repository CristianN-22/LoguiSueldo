using System.ComponentModel.DataAnnotations;

namespace LoguiSueldo.Models
{
    public class Leyes
    {  
        [Key]
        public int LeyID { get; set; }
        public string Nombre { get; set; }
    }
}
