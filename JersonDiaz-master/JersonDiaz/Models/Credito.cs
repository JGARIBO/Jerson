using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JersonDiaz.Models

{
    public class Credito
    {
        [Key]
        public int IdPrestamo { get; set; }

        public int IdCliente { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        
        public int IdFormaPago { get; set; }

       
        public int Plazo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Interes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Seguro { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Mora { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Deslizamiento { get; set; }
        public int IdUsuario { get; set; }

        public System.DateTime FechaCreacion { get; set; }

        public int Estado { get; set; }

        //public virtual Cliente Cliente { get; set; }

    }
}
