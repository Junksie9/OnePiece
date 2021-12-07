using System;
using System.Collections.Generic;

#nullable disable

namespace OnePiece.Models
{
    public partial class Arco
    {
        public Arco()
        {
            Capitulos = new HashSet<Capitulo>();
        }

        public int IdArco { get; set; }
        public string NombreArco { get; set; }
        public string Descripcion { get; set; }
        public int? NumArco { get; set; }

        public virtual ICollection<Capitulo> Capitulos { get; set; }
    }
}
