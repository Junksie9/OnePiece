using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnePiece.Models;
namespace OnePiece.Areas.Admin.Models
{
    public class CapitulosAggViewModel
    {
        public IEnumerable<Arcos> Arcos { get; set; }
        public Capitulos Capitulos { get; set; }
        public Arcos Arco { get; set; }
    }
}
