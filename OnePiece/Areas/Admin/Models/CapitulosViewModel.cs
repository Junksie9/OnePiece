using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePiece.Models;

namespace OnePiece.Areas.Admin.Models
{
    public class CapitulosViewModel
    {
        public Capitulos Capitulo { get; set; }
        public IEnumerable<Arcos> Arcos { get; set; }
        public IEnumerable<Capitulos> Capitulos { get; set; }
    }
}
