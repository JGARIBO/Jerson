using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JersonDiaz.Models

{
    public class FormaPago
    {
        [Key]
        public int IdFormaPago { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }

      

    }
}
