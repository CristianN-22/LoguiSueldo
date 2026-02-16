using System.ComponentModel.DataAnnotations;

namespace LoguiSueldo.Models
{
    public class EmpresaOnline
    {
        [Key]
        public int EmpresaOnlineID { get; set; }

        public string UsuarioOnline { get; set; }

        public DateTime UltimoIngreso { get; set; }

        public int EmpresaID { get; set; }
    }
}
