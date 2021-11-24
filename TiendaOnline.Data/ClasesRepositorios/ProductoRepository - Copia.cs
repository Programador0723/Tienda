using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

using TiendaOnline.Data.InterfacesRepositorios;
using TiendaOnline.Data;
using TiendaOnline.Models.Models;
using System.Linq;

namespace TiendaOnline.Data.ClasesRepositorios
{
    class ProductoRepository : Repositorio<Producto>, IProductoRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductoRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> ListaProducto()
        {
            return _context.Producto.Select(x => new SelectListItem()
            {
                Text = x.Nombre,
                Value = x.Id.ToString()
            }); ;
        }

        public IEnumerable<Producto> NombreProducto(string nombre)
        {
            var objeto = from u in _context.Producto
                         where u.Nombre.Equals("%"+nombre+"%")
                         select u;
            return objeto;
        }

        public void Update(Producto producto)
        {
            var ObjetoDdDb = _context.Producto.FirstOrDefault(x => x.Id == producto.Id);
            ObjetoDdDb.Nombre = producto.Nombre;
            ObjetoDdDb.Precio = producto.Precio;
            ObjetoDdDb.Negociable = producto.Negociable;

            _context.SaveChanges();

        }
    }
}
