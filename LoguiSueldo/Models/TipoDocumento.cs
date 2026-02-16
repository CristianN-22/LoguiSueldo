using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoguiSueldo.Models
{
    public class TipoDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Tipo de Documento")]
        public int TipoDocumentoID { get; set; }

        [Display(Name = "Tipo de Documento")]
        [Required]
        public string TipoDocumentoNombre { get; set; }

        public bool Visible { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }

        public virtual ICollection<Empresa> Empresa { get; set; }

        public virtual ICollection<Administracion.ClientesLogui> ClientesLoguiSoft { get; set; }

    }
}
