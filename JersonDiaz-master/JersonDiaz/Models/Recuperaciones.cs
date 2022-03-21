using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JersonDiaz.Models

{
    public class Recuperaciones
    {
        [Key]
        public int IdPago { get; set; }

        public int IdPrestamo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoPagado { get; set; }

       
        public System.DateTime FechaPago { get; set; }

    }
}
