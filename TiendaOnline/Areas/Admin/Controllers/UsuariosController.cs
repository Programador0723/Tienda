using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TiendaOnline.Data.InterfacesRepositorios;

namespace TiendaOnline.Areas.Admin.Controllers
{[Area("Admin")]
    public class UsuariosController : Controller
    {
        private readonly IContenedor _contenedor;
        public UsuariosController(IContenedor contenedor)
        {
            _contenedor = contenedor;

        }
        public IActionResult Index()
        {
            var ClaimsIndenty = (ClaimsIdentity)this.User.Identity;
            var UsuariActual = ClaimsIndenty.FindFirst(ClaimTypes.NameIdentifier);
            return View(_contenedor.usuario.GetTAll(x => x.Id != UsuariActual.Value));
        }
        public IActionResult Bloquear(string id)
        {
            if (id == null) 
            {
                return NotFound();
            }
            _contenedor.usuario.BloquearUsuario(id);
            return RedirectToAction(nameof(Index));
        
        }
        public IActionResult Desbloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _contenedor.usuario.DesbloquearUsuario(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
