using System;
using System.Collections.Generic;

using TiendaOnline.Models.Models;

namespace TiendaOnline.Models
{
   public class HomeVm
    {
        public IEnumerable<Producto> productos { get; set; }
        public IEnumerable<Vendedor> vendedors { get; set; }
    }
}
