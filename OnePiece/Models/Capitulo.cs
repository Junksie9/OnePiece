using System;
using System.Collections.Generic;

#nullable disable

namespace OnePiece.Models
{
    public partial class Capitulo
    {
        public int IdCapitulo { get; set; }
        public string NombreCapitulo { get; set; }
        public string Descripcion { get; set; }
        public int IdArcosToCap { get; set; }
        public int NumCap { get; set; }

        public virtual Arco IdArcosToCapNavigation { get; set; }
    }
}
