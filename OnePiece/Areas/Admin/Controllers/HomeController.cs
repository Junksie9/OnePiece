using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnePiece.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        [Route("admin")]
        [Route("admin/Home")]
        [Route("admin/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
