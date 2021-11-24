using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models.Models
{
    public class Usuario : IdentityUser
    {[Required(ErrorMessage ="El nombre es obligatorio")]
        public string  Nombre { get; set; }
        [Required(ErrorMessage = "La direccion es obligatorio")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Ciudad { get; set; }
        public string Pais { get; set; }
    }
}
