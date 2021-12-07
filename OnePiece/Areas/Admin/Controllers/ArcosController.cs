using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePiece.Models;

namespace OnePiece.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArcosController : Controller
    {
        public onepieceContext Context { get; }

        public ArcosController(onepieceContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            var arco = Context.Arcos.OrderBy(x => x.NombreArco);
            return View(arco);
        }


        public IActionResult Agregar()
        {
            return View(new Arco());
        }

        [HttpPost]
        public IActionResult Agregar(Arco a)
        {
            if (string.IsNullOrWhiteSpace(a.NombreArco))
            {
                ModelState.AddModelError("","Agregue Nombre del arco");
            }
            else if (string.IsNullOrWhiteSpace(a.Descripcion))
            {
                ModelState.AddModelError("", "Agregue una Descripcion");
            }
            else if (Context.Arcos.Any(x=>x.NombreArco==a.NombreArco))
            {
                ModelState.AddModelError("", "Ya existe un arco con ese nombre");
            }
            else
            {
                Context.Add(a);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(a);
        }

        public IActionResult Editar(int id)
        {
            var arco = Context.Arcos.FirstOrDefault(x => x.IdArco == id);
            if (arco==null)
            {
                return RedirectToAction("Index");
            }
            return View(arco);
        }
        [HttpPost]
        public IActionResult Editar(Arco a)
        {
            var arc = Context.Arcos.FirstOrDefault(x => x.IdArco == a.IdArco);
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
                else if (Context.Arcos.Any(x => x.NombreArco == a.NombreArco && x.IdArco!=a.IdArco))
                {
                    ModelState.AddModelError("", "Ya existe un arco con ese nombre");
                }
                else
                {
                    arc.NombreArco = a.NombreArco;
                    arc.Descripcion = a.Descripcion;
                    arc.NumArco = a.NumArco;
                    Context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(a);
        }

        public IActionResult Eliminar(int id)
        {
            var arc = Context.Arcos.FirstOrDefault(x => x.IdArco == id);
            if (arc==null)
            {
                return RedirectToAction("Index");
            }
            return View(arc);
        }
        [HttpPost]
        public IActionResult Eliminar(Arco a)
        {
            var arc = Context.Arcos.FirstOrDefault(x => x.IdArco == a.IdArco);
            if (arc == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var c in arc.Capitulos)
                {
                    Context.Remove(c);
                }
                Context.Remove(arc);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(a);
        }
    }
}
