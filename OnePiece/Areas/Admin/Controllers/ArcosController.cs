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

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Eliminar()
        {
            return View();
        }
    }
}
