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
