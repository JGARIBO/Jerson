using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace JersonDiaz.Models

{
    public class PlanPagoGenerado
    {
        [Key]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NUM_CUOTA { get; set; }
          
       [Column(TypeName = "decimal(18,2)")]
        public decimal SALDO_INICIAL { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal INTERES { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SEGURO { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DESLI { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TOTAL_CUOTA { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CAPITAL { get; set; }
        public string FECHA_PAGO { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SALDO_FINAL { get; set; }

        public string Estado { get; set; }
      
    }
}
