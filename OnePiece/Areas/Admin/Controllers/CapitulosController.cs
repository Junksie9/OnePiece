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
            vm.Capitulos = Context.Capitulos.Include(x=>x.IdArcosToCapNavigation).OrderBy(x => x.NumCap);
            return View(vm);
        }

        [HttpPost]
        public IActionResult IndexCapitulos(int idArco)
        {
            CapitulosViewModel vm = new CapitulosViewModel();
            vm.Arcos = Context.Arcos.OrderBy(x => x.NumArco);
            vm.Capitulos = Context.Capitulos.Include(x => x.IdArcosToCapNavigation).Where(x => x.IdArcosToCap == idArco).OrderBy(x => x.NumCap);
            return View(vm);
        }


        public IActionResult Agregar()
        {
            return View();
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
