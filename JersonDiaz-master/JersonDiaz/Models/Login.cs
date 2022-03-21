using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace JersonDiaz.Models
{
    public class Login
    {
        [Key]
        public int IdUsuario { get; set; }

        public string Usuario { get; set; }

        public string Contraseña { get; set; }

        public int Estado { get; set; }
    }
}
