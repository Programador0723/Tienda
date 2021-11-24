using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Data;
using TiendaOnline.Data.InterfacesRepositorios;
using TiendaOnline.Models;

namespace TiendaOnline.Controllers
{[Area("cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedor _contenedor;
        private readonly ApplicationDbContext _contex;

        public HomeController(IContenedor contenedor, ApplicationDbContext context)
        {
            _contenedor = contenedor;
            _contex = context;
        }

        public IActionResult Index()
        {
           
           


                HomeVm Hvm = new HomeVm()
                {
                    productos = _contenedor.producto.GetTAll(),
                    vendedors = _contenedor.vendedor.GetTAll()
                };
                return View(Hvm);
           
            
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
