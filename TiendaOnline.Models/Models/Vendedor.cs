using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.Models.Models
{
   public class Vendedor
    {[Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        public string Cedula { get; set; } 
        [Required(ErrorMessage = "*")]
        [Display(Name ="Nombre Vendedor")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "*")]
        public string Telefono { get; set; }
        [DataType(DataType.ImageUrl)]
        public string imagen { get; set; }
    }
}
