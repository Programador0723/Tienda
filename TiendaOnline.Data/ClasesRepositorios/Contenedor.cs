using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnline.Data.InterfacesRepositorios;

namespace TiendaOnline.Data.ClasesRepositorios
{
    public class Contenedor : IContenedor
    {
        private readonly ApplicationDbContext _context;
        public Contenedor(ApplicationDbContext context)
        {
            _context = context;
            vendedor = new VendedorRepository(_context);
            producto = new ProductoRepository(_context);
            usuario = new UsuarioRepository(_context);
        }
        public IVendedorRepository vendedor { get; private set; }

        public IProductoRepository producto { get; private set; }

        public IUsuarioRepository usuario { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
