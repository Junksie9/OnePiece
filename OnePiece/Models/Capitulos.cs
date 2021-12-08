using System;
using System.Collections.Generic;

#nullable disable

namespace OnePiece.Models
{
    public partial class Capitulos
    {
        public int Id { get; set; }
        public int IdArco { get; set; }
        public string NombreCapitulo { get; set; }
        public string Descripcion { get; set; }
        public int NumCap { get; set; }

        public virtual Arcos IdArcoNavigation { get; set; }
    }
}
