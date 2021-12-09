using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePiece.Models;
using Microsoft.AspNetCore.Authorization;

namespace OnePiece.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrador")]
    public class ArcosController : Controller
    {
        public onepieceContext Context { get; }

        public ArcosController(onepieceContext context)
        {
            Context = context;
        }
    
        public IActionResult IndexArcos()
        {
            var arco = Context.Arcos.OrderBy(x => x.NombreArco);
            return View(arco);
        }

        public IActionResult Agregar()
        {
            return View(new Arcos());
        }

        [HttpPost]
        public IActionResult Agregar(Arcos a)
        {
            if (string.IsNullOrWhiteSpace(a.NombreArco))
            {
                ModelState.AddModelError("","Agregue Nombre del arco");
            }
            else if (string.IsNullOrWhiteSpace(a.Descripcion))
            {
                ModelState.AddModelError("", "Agregue una Descripcion");
            }
            else if (a.NumArco == 0)
            {
                ModelState.AddModelError("", "Agregue un numero de arco");
            }
            else if (Context.Arcos.Any(x=>x.NombreArco==a.NombreArco))
            {
                ModelState.AddModelError("", "Ya existe un arco con ese nombre");
            }
            else
            {
                Context.Add(a);
                Context.SaveChanges();
                return RedirectToAction("IndexArcos");
            }
            return View(a);
        }

        public IActionResult Editar(int id)
        {
            var arco = Context.Arcos.FirstOrDefault(x => x.Id == id);
            if (arco==null)
            {
                return RedirectToAction("IndexArcos");
            }
            return View(arco);
        }
        [HttpPost]
        public IActionResult Editar(Arcos a)
        {
            var arc = Context.Arcos.FirstOrDefault(x => x.Id == a.Id);
            if (arc == null)
            {
                ModelState.AddModelError("", "El arco ya no existe o se elimino");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(a.NombreArco))
                {
                    ModelState.AddModelError("", "Agregue Nombre del arco");
                }
                else if (string.IsNullOrWhiteSpace(a.Descripcion))
                {
                    ModelState.AddModelError("", "Agregue una Descripcion");
                }
                else if (a.NumArco == 0)
                {
                    ModelState.AddModelError("", "El numero de arco no puede ir en 0 ");
                }
                else if (Context.Arcos.Any(x => x.NombreArco == a.NombreArco && x.Id!=a.Id))
                {
                    ModelState.AddModelError("", "Ya existe un arco con ese nombre");
                }
                else
                {
                    arc.NombreArco = a.NombreArco;
                    arc.Descripcion = a.Descripcion;
                    arc.NumArco = a.NumArco;
                    Context.SaveChanges();
                    return RedirectToAction("IndexArcos");
                }
            }
            return View(a);
        }

        public IActionResult Eliminar(int id)
        {
            var arc = Context.Arcos.FirstOrDefault(x => x.Id == id);
            if (arc==null)
            {
                return RedirectToAction("IndexArcos");
            }
            return View(arc);
        }
        [HttpPost]
        public IActionResult Eliminar(Arcos a,)
        {
            var arc = Context.Arcos.FirstOrDefault(x => x.Id == a.Id);
            //Agregar error de existe un capitulo en el arco.
            if (arc == null)
            {
                return RedirectToAction("IndexArcos");
            }
            else
            {
                foreach (var p in arc.Capitulos)
                {
                    Context.Remove(p);
                }
                Context.Remove(arc);
                Context.SaveChanges();
                return RedirectToAction("IndexArcos");
            }
            return View(a);
        }
    }
}
