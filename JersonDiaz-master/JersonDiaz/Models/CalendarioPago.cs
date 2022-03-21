using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace JersonDiaz.Models

{
    public class CalendarioPago
    {
        [Key]
        public int IdPrestamo { get; set; }

 
        [Column(TypeName = "decimal(18,2)")]
        public decimal NumCuota { get; set; }
          
       [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoInicial { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Interes { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Seguro { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Deslizamiento { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCuota { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Capital { get; set; }
        public System.DateTime FechaPago { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SaldoFinal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MontoPagado { get; set; }

        public string Estado { get; set; }
      
    }
}
