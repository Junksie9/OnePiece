using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePiece.Models;
using OnePiece.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace OnePiece.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CapitulosController : Controller
    {
        public onepieceContext Context { get; }
        public IWebHostEnvironment Host { get; }

        public CapitulosController(onepieceContext context, IWebHostEnvironment host)
        {
            Context = context;
            Host = host;
        }
        public IActionResult IndexCapitulos()
        {
            CapitulosViewModel vm = new CapitulosViewModel();
            vm.Arcos = Context.Arcos.OrderBy(x => x.NumArco);
            vm.Capitulos = Context.Capitulos.Include(x => x.IdArcoNavigation).OrderBy(x => x.NumCap);
            return View(vm);
        }

        [HttpPost]
        public IActionResult IndexCapitulos(int idArco)
        {
            CapitulosViewModel vm = new CapitulosViewModel();
            vm.Arcos = Context.Arcos.OrderBy(x => x.NumArco);
            vm.Capitulos = Context.Capitulos.Include(x => x.IdArcoNavigation).Where(x => x.IdArco == idArco).OrderBy(x => x.NumCap);
            return View(vm);
        }


        public IActionResult Agregar()
        {
            CapitulosAggViewModel vm = new CapitulosAggViewModel();
            vm.Arcos = Context.Arcos.OrderBy(x => x.NombreArco);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Agregar(CapitulosAggViewModel vm, IFormFile archivo1)
        {
            vm.Arcos = Context.Arcos.OrderBy(x => x.NombreArco);
            if (string.IsNullOrWhiteSpace(vm.Capitulos.NombreCapitulo))
            {
                ModelState.AddModelError("", "No debe dejar en blanco ningun espacio");
            }
            else if (vm.Capitulos.NumCap == 0)
            {
                ModelState.AddModelError("", "El numero del capitulo no debe ir en 0");
            }
            else if ((string.IsNullOrWhiteSpace(vm.Capitulos.Descripcion)))
            {
                ModelState.AddModelError("", "La descripcion no debe ir en blanco");
            }
            else
            {
                if (archivo1 != null)
                {
                    if (archivo1.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("", "Solo se permiten subidas de archivos jpg");
                        return View(vm);
                    }
                    if (archivo1.Length > 1024 * 1024 * 5)
                    {
                        ModelState.AddModelError("", "Solo se permite archivos menores a 5MB");
                        return View(vm);
                    }
                }
                Context.Add(vm.Capitulos);
                if (vm.Capitulos.NombreCapitulo == vm.Capitulos.NombreCapitulo)
                {
                    ModelState.AddModelError("", "Ya existe un capitulo con el mismo nombre");
                }
                Context.SaveChanges();
                if (archivo1 != null)
                {
                    var path = Host.WebRootPath + "/img_capitulos/" + vm.Capitulos.Id + ".jpg";
                    FileStream fs = new FileStream(path, FileMode.Create);
                    archivo1.CopyTo(fs);
                    fs.Close();
                }
                return RedirectToAction("IndexCapitulos");
            }
            return View(vm);
        }

        public IActionResult Editar(int id)
        {

            CapitulosAggViewModel vm = new CapitulosAggViewModel();
            var capitulos = Context.Capitulos.FirstOrDefault(x => x.Id == id);
            if (capitulos == null)
            {
                return RedirectToAction("IndexCapitulos");
            }
            vm.Capitulos = capitulos;
            vm.Arcos = Context.Arcos.OrderBy(x => x.NombreArco);

            return View(vm);
        }
        [HttpPost]
        public IActionResult Editar(CapitulosAggViewModel vm, IFormFile archivo1)
        {
            vm.Arcos = Context.Arcos.OrderBy(x => x.NombreArco);
            if (string.IsNullOrWhiteSpace(vm.Capitulos.NombreCapitulo))
            {
                ModelState.AddModelError("", "No debe dejar en blanco ningun espacio");
            }
            else if (vm.Capitulos.NumCap == 0)
            {
                ModelState.AddModelError("", "El numero del capitulo no debe ir en 0");
            }
            else if ((string.IsNullOrWhiteSpace(vm.Capitulos.Descripcion)))
            {
                ModelState.AddModelError("", "La descripcion no debe ir en blanco");
            }
            else
            {
                if (archivo1 != null)
                {
                    if (archivo1.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("", "Solo se permiten subidas de archivos jpg");
                        return View(vm);
                    }
                    if (archivo1.Length > 1024 * 1024 * 5)
                    {
                        ModelState.AddModelError("", "Solo se permite archivos menores a 5MB");
                        return View(vm);
                    }
                    var caps = Context.Capitulos.FirstOrDefault(x => x.Id == vm.Capitulos.Id);
                    if (caps == null)
                    {
                        return RedirectToAction("IndexCapitulos");
                    }
                    caps.IdArco = vm.Capitulos.IdArco;
                    caps.NombreCapitulo = vm.Capitulos.NombreCapitulo;
                    caps.Descripcion = vm.Capitulos.Descripcion;
                    caps.NumCap = vm.Capitulos.NumCap;
                    Context.Update(caps);
                    Context.SaveChanges();
                    if (archivo1 != null)
                    {
                        var path = Host.WebRootPath + "/img_capitulos/" + vm.Capitulos.Id + ".jpg";
                        FileStream fs = new FileStream(path, FileMode.Create);
                        archivo1.CopyTo(fs);
                        fs.Close();
                    }
                    return RedirectToAction("IndexCapitulos");
                }
            }
            return View(vm);
        }
        public IActionResult Eliminar(int id)
        {
            var cap = Context.Capitulos.FirstOrDefault(x => x.Id == id);
            if (cap==null)
            {
                return RedirectToAction("IndexCapitulos");
            }
            return View(cap);
        }
        [HttpPost]
        public IActionResult Eliminar(Capitulos c,IFormFile archivo1, Arcos a)
        {
            var cap = Context.Capitulos.FirstOrDefault(x => x.Id == c.Id);
            var arc = Context.Arcos.FirstOrDefault(x => x.Id == a.Id);
            if (cap == null)
            {
                ModelState.AddModelError("", "El capitulo ha sido borrado");
            }
            else
            {
                Context.Remove(arc);
                Context.Remove(cap);
                Context.SaveChanges();

                var path = Host.WebRootPath + "/img_capitulos/" + c.Id + ".jpg";
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return RedirectToAction("IndexCapitulos");
            }
            return View(c);
        }
    }
}
