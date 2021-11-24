using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaOnline.Data.InterfacesRepositorios;
using TiendaOnline.Models.Models;

namespace TiendaOnline.Data.ClasesRepositorios
{
    public class UsuarioRepository : Repositorio<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context):base(context)
        {
            _context = context;

        }
        public void BloquearUsuario(string usuario)
        {
            var basedatos = _context.Usuarios.FirstOrDefault(x => x.Id == usuario);
            basedatos.LockoutEnd = DateTime.Now.AddYears(10);
            _context.SaveChanges();
        }

        public void DesbloquearUsuario(string usuario)
        {
            var basedatos = _context.Usuarios.FirstOrDefault(x => x.Id == usuario);
            basedatos.LockoutEnd = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
