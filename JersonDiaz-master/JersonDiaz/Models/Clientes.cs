using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace JersonDiaz.Models

{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage ="El Campo Nombre es Requerido")]
        public string Nombre { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "El Campo Apellido es Requerido")]
        public string Apellido { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "El Campo Telefono es Requerido")]
        public string Telefono { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "El Campo Direccion es Requerido")]
        public string Direccion { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "El Campo Cedula es Requerido")]
        public string Cedula { get; set; }


        [StringLength(100)]
        [Required(ErrorMessage = "El Campo Genero es Requerido")]
        public string Genero { get; set; }

        public int IdUsuario { get; set; }

        public System.DateTime FechaCreacion { get; set; }

        //public virtual ICollection<Credito> Credito { get; set; }
    }
}
