using System;
using System.Collections.Generic;

#nullable disable

namespace OnePiece.Models
{
    public partial class Arcos
    {
        public Arcos()
        {
            Capitulos = new HashSet<Capitulos>();
        }

        public int Id { get; set; }
        public string NombreArco { get; set; }
        public string Descripcion { get; set; }
        public int NumArco { get; set; }

        public virtual ICollection<Capitulos> Capitulos { get; set; }
    }
}
