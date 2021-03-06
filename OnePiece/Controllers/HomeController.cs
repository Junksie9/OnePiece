using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePiece.Models;
using Microsoft.EntityFrameworkCore;

namespace OnePiece.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(onepieceContext context)
        {
            Context = context;
        }

        public onepieceContext Context { get; }


        public IActionResult Index()
        { 
            
            var cap = Context.Capitulos.Include(x=>x.IdArcoNavigation).OrderBy(x => x.NumCap);
            return View(cap);
        }
        [Route("/{arco}")]
        public IActionResult Arco(string arco)
        {
            arco = arco.Replace("-", " ");
            var arc = Context.Arcos
                .Include(x => x.Capitulos).OrderBy(x=>x.NumArco)
                .FirstOrDefault(x => x.NombreArco == arco); 
            if (arc == null)
            {
                return RedirectToAction("Index");
            }
            return View(arc);
        }

        [Route("/{arco}/{capitulo}")]
        public IActionResult InfoCap(string arco, string capitulo)
        {
            arco = arco.Replace("-", " ");
            capitulo = capitulo.Replace("-", " ");

            var cap = Context.Capitulos.Include(x => x.IdArcoNavigation).FirstOrDefault(x => x.NombreCapitulo == capitulo);
            if (cap == null)
            {
                return RedirectToAction("Index");
            }
            return View(cap);
        }
    }
}
