using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePiece.Models;

namespace OnePiece.Areas.Admin.Models
{
    public class CapitulosViewModel
    {
        public IEnumerable<Arco> Arcos { get; set; }
        public IEnumerable<Capitulo> Capitulos { get; set; }
    }
}
