using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

using TiendaOnline.Data.InterfacesRepositorios;
using TiendaOnline.Data;
using TiendaOnline.Models.Models;
using System.Linq;

namespace TiendaOnline.Data.ClasesRepositorios
{
    class VendedorRepository : Repositorio<Vendedor>, IVendedorRepository
    {
        private readonly ApplicationDbContext _context;
        public VendedorRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> ListaVendedor()
        {
            return _context.Vendedor.Select(x => new SelectListItem() {
            Text=x.Nombre,
            Value=x.Id.ToString()
            
            });
          
        }

        public void Update(Vendedor vendedor)
        {
            var actualizar = _context.Vendedor.FirstOrDefault(x => x.Id == vendedor.Id);
            actualizar.Nombre = vendedor.Nombre;
            actualizar.Cedula = vendedor.Cedula;
            actualizar.Telefono = vendedor.Telefono;

            _context.SaveChanges();
        }
    }
}
