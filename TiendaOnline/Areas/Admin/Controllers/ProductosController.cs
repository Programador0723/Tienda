using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TiendaOnline.Data.InterfacesRepositorios;
using TiendaOnline.Models.Models;

namespace TiendaOnline.Areas.Admin.Controllers
{[Area("Admin")]
    public class ProductosController : Controller
    {
        private readonly IContenedor _contenedor;
        private readonly IWebHostEnvironment _host;
        public ProductosController(IContenedor contenedor,IWebHostEnvironment host)
        {
            _contenedor = contenedor;
            _host = host;

        }
        [HttpGet]
        public IActionResult Index()
        {
            vmproductos Vm = new vmproductos()
            {
                producto = new Models.Models.Producto(),
                ListaVmVende = _contenedor.vendedor.ListaVendedor()

            };
            return View(Vm);
         
        }
        [HttpGet]
        public IActionResult Create()
        {
            vmproductos Vm = new vmproductos()
            { producto = new Models.Models.Producto(),
            ListaVmVende=_contenedor.vendedor.ListaVendedor()

            };
            return View(Vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(vmproductos productos)
        {
            if (ModelState.IsValid) 
            {
                string NombreArchivo = _host.WebRootPath;
                var Archivo = HttpContext.Request.Form.Files;

                if (productos.producto.Id == 0) 
                {
                    string nombre = Guid.NewGuid().ToString();
                    var subida = Path.Combine(NombreArchivo,  @"imagenes\producto");
                    var extension = Path.GetExtension(Archivo[0].FileName);

                    using (var file=new FileStream(Path.Combine(subida, nombre + extension), FileMode.Create)) 
                    {
                        Archivo[0].CopyTo(file);

                    }
                    productos.producto.Imagen = @"\imagenes\producto\" + nombre + extension;
                    _contenedor.producto.add(productos.producto);
                    _contenedor.Save();
                    return RedirectToAction(nameof(Index));

                
                
                }
            }productos.ListaVmVende = _contenedor.vendedor.ListaVendedor();
            
            return View(productos);
            
        }
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            vmproductos VM = new vmproductos()
            {producto=new Models.Models.Producto(),
            ListaVmVende=_contenedor.producto.ListaProducto()

            };
            if (id != null)
            {

                VM.producto = _contenedor.producto.Get(id.GetValueOrDefault());
                return View(VM);
            }
            else
            {

                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(vmproductos vm) 
        {
            if (ModelState.IsValid) 
            {
              
                string nombre = _host.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var desdebase = _contenedor.producto.Get(vm.producto.Id);
                if (vm.producto.Id == 0)
                {
                    string ruta = Guid.NewGuid().ToString();
                    var subida = Path.Combine(nombre, @"imagenes\producto");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    var neextension = Path.GetExtension(archivos[0].FileName);

                    using (var filemo = new FileStream(Path.Combine(subida, ruta + neextension), FileMode.Create))
                    {

                        archivos[0].CopyTo(filemo);
                    }
                    vm.producto.Imagen = @"\imagenes\productos\" + subida + neextension;
                    _contenedor.producto.Update(vm.producto);
                    return RedirectToAction(nameof(Index));



                }
                else {
                    vm.producto.Imagen = desdebase.Imagen;
                   
                }
                _contenedor.producto.Update(vm.producto);

                return RedirectToAction(nameof(Index));
            }
           
            
                return View();
            
        
        }
        #region
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objeto = _contenedor.producto.Get(id);
            string directorio = _host.WebRootPath;
            string ruta = objeto.Imagen;
            if (System.IO.File.Exists(ruta)) 
            {
                System.IO.File.Delete(ruta);
            
            }
            if (objeto == null)
            {
                return Json(new { success=false, message="No se eliminó" });
            }
            _contenedor.producto.Remove(objeto);
            _contenedor.Save();
            return Json(new { success = true, message = "Se eliminó" });
        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Json(new { data = _contenedor.producto.GetTAll(includeProperty:"vendedor") });
        }
        #endregion
    }
}
