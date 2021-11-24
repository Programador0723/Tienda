using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaOnline.Models.Models
{
    public class Producto
    {[Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "*")]

        public string Precio { get; set; }
        [Required(ErrorMessage = "*")]
        public bool Negociable { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }

        public int VendedorId { get; set; }
        
        [ForeignKey("VendedorId")]
        public Vendedor vendedor { get; set; }
    }
}
