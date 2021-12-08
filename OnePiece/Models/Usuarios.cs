using System;
using System.Collections.Generic;

#nullable disable

namespace OnePiece.Models
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string NombreReal { get; set; }
    }
}
