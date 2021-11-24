using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using TiendaOnline.Data;
using TiendaOnline.Data.InterfacesRepositorios;
using TiendaOnline.Models.Models;

namespace TiendaOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VendedoresController : Controller
    { 
        private readonly IContenedor _contenedor;
        private readonly IWebHostEnvironment _host;
       
        public VendedoresController(IContenedor contenedor, IWebHostEnvironment Host)
        {
            _contenedor = contenedor;
            _host = Host;

        }
        [HttpGet]
        public IActionResult Index(string nombreVendedor)
        {
            ViewData["searNONBRE"] = nombreVendedor;
            var vendedor = from s in _contenedor.vendedor.Todo() select s;
            if (!String.IsNullOrEmpty(nombreVendedor)) 
            {
                vendedor = vendedor.Where(s => s.Nombre.Contains(nombreVendedor));
                return View(vendedor);
            }
          
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Vendedor vendedor)
        {
            string nombreArchivo = _host.WebRootPath;
                var Archivo = HttpContext.Request.Form.Files;
            if (ModelState.IsValid)
            { string Nombre = Guid.NewGuid().ToString();
                var subida = Path.Combine(nombreArchivo, @"imagenes\vendedor");
                var extension = Path.GetExtension(Archivo[0].FileName);

                using (var filestream = new FileStream(Path.Combine(subida, Nombre + extension), FileMode.Create))
                {
                    Archivo[0].CopyTo(filestream);
                
                }
                vendedor.imagen = @"\imagenes\vendedor" + Nombre + extension;
                    _contenedor.vendedor.add(vendedor);
                _contenedor.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Vendedor vende = new Vendedor();
            vende = _contenedor.vendedor.Get(id);
            if (vende == null) 
            {
                return NotFound();
            
            }
            return View(vende);
            
        }
        [HttpPost]
        public IActionResult Edit(Vendedor vendedor)
        {
            if (ModelState.IsValid) 
            {
                string Directorio = _host.WebRootPath;
                var Archivo = HttpContext.Request.Form.Files;
                var vende = _contenedor.vendedor.Get(vendedor.Id);
                if (Archivo.Count() > 0)
                {
                    string NombreArchivo = Guid.NewGuid().ToString();
                    var subida = Path.Combine(Directorio, @"imagenes\vendedor");
                    var extension = Path.GetExtension(Archivo[0].FileName);
                    var newextension = Path.GetExtension(Archivo[0].FileName);
                    var rutaimagen = Path.Combine(Directorio, vende.imagen.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaimagen))
                    {
                        System.IO.File.Delete(rutaimagen);

                    }
                    using (var file = new FileStream(Path.Combine(subida, NombreArchivo + newextension), FileMode.Create))
                    {
                        Archivo[0].CopyTo(file);

                    }
                    vende.imagen = @"\imagenes\vendedor\" + NombreArchivo + newextension;
                    _contenedor.vendedor.Update(vendedor);
                    _contenedor.Save();
                    RedirectToAction(nameof(Index));


                }
                else 
                {
                   
                    vendedor.imagen = vende.imagen;
                   

                }
                _contenedor.vendedor.Update(vendedor);
                _contenedor.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(vendedor);
        }
      
        #region
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Json(new { data = _contenedor.vendedor.GetTAll() });
        
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        { var db = _contenedor.vendedor.Get(id);
            string directorioPrincipal = _host.WebRootPath;
            var ruta =Path.Combine(directorioPrincipal, db.imagen.TrimStart('\\'));
            if (System.IO.File.Exists(ruta)) 
            {
                System.IO.File.Delete(ruta);
            }
          if(db ==  null)
            {
                return Json(new { success = false, message = "No se pudo eliminar" }); 
            }
            _contenedor.vendedor.Remove(db);
            _contenedor.Save();
            return Json(new { success = true, message = "se elimino" });
            

        }
        #endregion
    }
}
