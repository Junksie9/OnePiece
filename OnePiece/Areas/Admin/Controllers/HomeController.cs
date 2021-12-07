using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnePiece.Areas.Admin.Controllers
{
    
    public class HomeController : Controller
    {
        [Area("Admin")]
        [Route("admin")]
        [Route("admin/Home")]
        [Route("admin/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
