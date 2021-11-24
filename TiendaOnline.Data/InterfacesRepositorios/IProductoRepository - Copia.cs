using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnline.Models.Models;

namespace TiendaOnline.Data.InterfacesRepositorios
{
  public  interface IProductoRepository:IRepository<Producto>
    {
        IEnumerable<SelectListItem> ListaProducto();
        void Update(Producto producto);
        IEnumerable<Producto> NombreProducto(string nombre);
    }
}
