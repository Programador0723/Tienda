using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnline.Models.Models;

namespace TiendaOnline.Data.InterfacesRepositorios
{
  public  interface IVendedorRepository:IRepository<Vendedor>
    {
        IEnumerable<SelectListItem> ListaVendedor();
        void Update(Vendedor vendedor);
    }
}
