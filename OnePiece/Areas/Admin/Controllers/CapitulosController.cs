using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePiece.Models;
using OnePiece.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace OnePiece.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CapitulosController : Controller
    {
        public onepieceContext Context { get; }

        public CapitulosController(onepieceContext context)
        {
            Context = context;
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
        public IActionResult Agregar(CapitulosAggViewModel vm)
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
                Context.Add(vm.Capitulos);
                Context.SaveChanges();
                return RedirectToAction("IndexCapitulos");
            }
            return View(vm);
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
