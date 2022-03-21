using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JersonDiaz.Models

{
    public class Estados
    {
        [Key]
        public int IdEstado { get; set; }

        public string Descripcion { get; set; }
                     
        public int Estado { get; set; }

   

    }
}
