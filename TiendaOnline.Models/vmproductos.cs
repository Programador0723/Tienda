using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;

namespace TiendaOnline.Models.Models
{
   public class vmproductos
    {
        public Producto producto { get; set; }
        public IEnumerable<SelectListItem> ListaVmVende { get; set; }
    }
}
